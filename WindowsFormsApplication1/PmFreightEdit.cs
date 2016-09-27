using System;
using System.Windows.Forms;
using posb = PosBusiness;
using UtilitiesForm.Extensions;
using System.Text;
using Microsoft.Win32;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public partial class PmFreightEdit : FormBase
    {
        #region Members

        public delegate void Communication(int IdPM, int IdClient, decimal UnitPrice, double Amount);

        public event Communication Result;

        private int? Id = null;

        private int ClientId;

        private double? Amount = null;

        private decimal? Price = null;

        private int SelectedIndex = 5;

        private posb.Client GlobalClient = new posb.Client();

        #endregion

        #region Builder

        public PmFreightEdit(int Id, int ClientId, double Amount)
        {
            InitializeComponent();

            this.Id = Id;
            this.ClientId = ClientId;
            this.Amount = Amount;

            using (posb.PM pm = new posb.PM())
            {
                pm.Get(Id, true);

                this.Price = pm.Price;
            }
        }

        #endregion

        #region Events

        private void MeasureEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.cmbTipo;

            this.LoadData(this.Id);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            decimal up = decimal.Parse(this.txtTotal.Text) / decimal.Parse(this.txtAmount.Text);

            this.Result(this.Id.Value, int.Parse(this.cmbClient.SelectedValue.ToString()), up, double.Parse(this.txtAmount.Text));

            this.Close();
        }

        #endregion

        #region Methodss

        private void GetDestinations()
        {
            using (posb.Freight Freight = new posb.Freight())
            {
                this.cmDestination.Fill(Freight.ListDestination());

                this.cmDestination.SelectedIndex = this.SelectedIndex;
            }
        }

        private void Getaddress()
        {
            using (posb.Client client = new posb.Client
            {
                Id = int.Parse(this.cmbClient.SelectedValue.ToString())
            })
            {
                client.Get();

                this.txtAddress.Text = client.Address;
                this.txtOthers.Text = client.Others.Replace("N/A", string.Empty);

                string street = string.Empty,
                       city = string.Empty,
                       state = string.Empty,
                       zip = string.Empty;

                this.VerificarRegistroWebBrowser();

                StringBuilder queryAddress = new StringBuilder();

                queryAddress.Append("https://www.google.com.mx/maps/dir/19.3726766,-98.9416265/");

                if (!string.IsNullOrEmpty(client.Street))
                {
                    street = client.Street.Trim() + "+" + client.Number1.Trim();

                    street = street.Replace(' ', '+');
                    queryAddress.Append(street + ',' + '+');
                }

                if (!string.IsNullOrEmpty(client.Colony))
                {
                    city = client.Colony.Trim() + "+" + client.Municipality.Trim();

                    city = city.Replace(' ', '+');
                    queryAddress.Append(city + ',' + '+');
                }


                if (!string.IsNullOrEmpty(client.State))
                {
                    state = client.State.Trim();

                    state = state.Replace(' ', '+');
                    queryAddress.Append(state + ',' + '+');
                }

                if (!string.IsNullOrEmpty(client.Zip))
                {
                    zip = client.Zip.Trim();
                    queryAddress.Append(zip);
                }

                webBrowser1.Navigate(queryAddress.ToString());

            }
        }

        private void LoadData(int? Id)
        {
            this.GetClients(this.ClientId);

            this.txtAmount.Text = String.Format("{0:0.00}", this.Amount);

            this.txtPrice2.Text = String.Format("{0:0.00}", (this.Amount * double.Parse(this.Price.ToString())));

            this.GetDestinations();

            this.cmbTipo.SelectedIndex = 0;

            this.GetPrice();

            this.Getaddress();
        }

        private void Save(bool Exist = true)
        {
            using (posb.Brand Entity = new posb.Brand
            {
                Name = this.txtPrice.Text,
                Id = this.Id
            })
            {
                if (Exist && Entity.Exist())
                    this.Alert("Ya se encuentra registrada la marca [" + Entity.Name + "]");
                else
                {
                    Entity.Save();

                    this.Close();
                }
            }
        }

        private void GetClients(int Id)
        {
            using (posb.Client client = new posb.Client())
            {
                this.cmbClient.Fill(client.List(), AddFirstOption: false);

                this.cmbClient.SelectedValue = Id;
            }
        }

        #endregion

        private void cmDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmDestination.SelectedIndex > 0)
            {
                this.GetPrice();
            }
        }

        public void GetPrice()
        {
            var idDestination = int.Parse(this.cmDestination.SelectedValue.ToString());

            using (posb.PM pm = new posb.PM
            {
                Id = this.Id
            })
            {
                double amount = double.Parse(this.txtAmount.Text);
                decimal price = 0, price2, priceUnit;
                int parts, parts2;

                if (this.cmbTipo.SelectedIndex == 0)
                {
                    if (amount > 1000)
                    {
                        price = pm.GetPricePMFreight(idDestination, 1000);

                        parts = (int)(amount / 1000);
                        price2 = parts * price;

                        parts2 = (int)(amount % 1000);
                        priceUnit = price / 1000;

                        price2 = price2 + (parts2 * priceUnit);

                        price = price2;
                    }
                    else
                    {
                        price = pm.GetPricePMFreight(idDestination, amount);
                    }
                }
                else if (this.cmbTipo.SelectedIndex == 1)
                {
                    if (amount > 1000)
                    {
                        price = pm.GetPricePMFreight(idDestination, 1000);

                        parts = (int)(amount / 1000);
                        price2 = parts * price;

                        parts2 = (int)(amount % 1000);
                        priceUnit = pm.GetPricePMFreight(idDestination, parts2);

                        price2 = price2 + priceUnit;

                        price = price2;
                    }
                    else
                    {
                        price = pm.GetPricePMFreight(idDestination, amount);
                    }
                }
                else if (this.cmbTipo.SelectedIndex == 2)
                {
                    price = pm.GetPricePMFreight(idDestination, 1000);
                    priceUnit = price / 1000;

                    price = decimal.Parse(amount.ToString()) * priceUnit;
                }

                this.txtPrice.Text = String.Format("{0:0.00}", price);

                this.txtTotal.Text = String.Format("{0:0.00}", double.Parse(this.txtPrice.Text) + double.Parse(this.txtPrice2.Text));
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmDestination.SelectedIndex > 0)
            {
                this.GetPrice();
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (this.cmDestination.SelectedIndex > 0 && !string.IsNullOrEmpty(this.txtAmount.Text))
            {
                this.txtPrice2.Text = String.Format("{0:0.00}", (decimal.Parse(this.txtAmount.Text) * this.Price));

                this.GetPrice();
            }
        }

        public void VerificarRegistroWebBrowser()
        {
            string subclave = "Software\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION\\";

            //intentamos abrir la subclave
            RegistryKey clave = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default).OpenSubKey(subclave, true);
            if ((clave == null))
            {
                //Interaction.MsgBox("No se encontro la subclave FEATURE_BROWSER_EMULATION en el registro de Windows");
            }
            else
            {
                //si el valor "*" no existe lo creamos 
                if ((clave.GetValue("*") == null))
                {
                    clave.SetValue("*", GetWebBrowserRegistryValue(this.webBrowser1), RegistryValueKind.DWord);
                }
                else
                {
                    //si existe "*" pero el valor es diferente, lo modificamos
                    if (clave.GetValue("*").ToString() != GetWebBrowserRegistryValue(this.webBrowser1))
                    {
                        clave.SetValue("*", GetWebBrowserRegistryValue(this.webBrowser1), RegistryValueKind.DWord);
                    }
                }
            }
        }

        public string GetWebBrowserRegistryValue(WebBrowser WebBrowser)
        {
            string ValReg = "";
            //obtenemos el valor correspondiente del webbrowser (solo para IExplorer 7,8,9,10,11)
            switch (WebBrowser.Version.Major)
            {
                case 11:
                    ValReg = "00011000";
                    break;
                case 10:
                    ValReg = "00010000";
                    break;
                case 9:
                    ValReg = "00009000";
                    break;
                case 8:
                    ValReg = "00008000";
                    break;
                case 7:
                    ValReg = "00007000";
                    break;
            }
            return ValReg;
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            if (this.btnMap.Text == "Ver mapa")
            {
                this.btnMap.Text = "Ocultar mapa";

                this.Height = 391;
                this.Width = 1202;
            }
            else
            {
                this.btnMap.Text = "Ver mapa";

                this.Height = 391;
                this.Width = 449;
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {


        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            using (Bitmap bitmap = new Bitmap(webBrowser1.Width, webBrowser1.Height))
            {
                Rectangle bounds = new Rectangle(new Point(0, 0), webBrowser1.Size);
                webBrowser1.DrawToBitmap(bitmap, bounds);

                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                bitmap.Save(path + "\\WebsiteScreenshot.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmDestination.SelectedIndex > 0)
            {
                this.Getaddress();
            }
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            ClientEdit ClientEdit = new ClientEdit();

            ClientEdit.Result += new ClientEdit.Communication(ResultEmployee);

            ClientEdit.ShowDialog();
        }

        private void ResultEmployee(bool IsCorrect, String ErrorMessage, int Id)
        {
            this.GetClients(Id);
        }
    }
}
