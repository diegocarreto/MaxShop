using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using posb = PosBusiness;
using UtilitiesForm.Extensions;
using System.IO;
using System.Net;
using System.Globalization;

namespace WindowsFormsApplication1
{
    public partial class PMEdit : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage);

        public event Communication Result;

        private int? Id = null;

        private bool IsCopy = false;

        private int Index = 0;

        private bool HasImage = false;

        private bool LoadComplete = false;

        #endregion

        #region Builder

        public PMEdit(int? Id = null, bool IsCopy = false)
        {
            InitializeComponent();
            this.Id = Id;
            this.IsCopy = IsCopy;
        }

        #endregion

        #region Events

        private void btnAccept_Click(object sender, EventArgs e)
        {
            double val = 0;

            if (!double.TryParse(this.txtStockMin.Text, out val))
            {
                this.Alert("Debe indicar el stock minimo");

                this.txtStockMin.Focus();

                return;
            }
            //else if (val.Equals(0))
            //{
            //    this.Alert("El stock minimo debe ser mayor a 0");

            //    this.txtStockMin.Focus();

            //    return;
            //}

            if (!double.TryParse(this.txtStockMax.Text, out val))
            {
                this.Alert("Debe indicar el stock maximo");

                this.txtStockMax.Focus();

                return;
            }
            //else if (val.Equals(0))
            //{
            //    this.Alert("El stock maximo debe ser mayor a 0");

            //    this.txtStockMax.Focus();

            //    return;
            //}

            //if (this.cmBrand.SelectedIndex > 0)
            //{
            if (cmbProduct.SelectedIndex > 0)
            {
                if (this.cmbMeasure2.SelectedIndex > 0 && string.IsNullOrEmpty(this.txtAmount.Text))
                {
                    this.Alert("Debe indicar la cantidad de la medida B");

                    this.txtAmount.Focus();

                    return;
                }

                if (!string.IsNullOrEmpty(this.txtAmount.Text) && this.cmbMeasure2.SelectedIndex == 0)
                {
                    this.Alert("Debe indicar la medida B");

                    this.cmbMeasure2.Focus();

                    return;
                }

                if (!string.IsNullOrEmpty(txtPrice.Text))
                {
                    this.Save();

                    using (posb.PM pm = new posb.PM
                    {
                        Id = this.Id
                    })
                    {
                        if (!this.HasImage && pbPhoto.Image != null)
                        {
                            pm.SaveImage(this.ImageToByte(pbPhoto.Image));
                        }

                        var isColor = this.cbColor.Checked;
                        var color = pbColor.BackColor;
                        var hex = isColor ? ColorTranslator.ToHtml(Color.FromArgb(color.ToArgb())) : string.Empty;

                        if (hex == "#BEDAFE")
                        {
                            hex = "";
                            isColor = false;
                        }

                        pm.SaveColor(isColor, hex);
                    }

                    this.Result(true, "");

                    this.Close();
                }
                else
                    this.Alert("Debe indicar el precio");
            }
            else
                this.Alert("Debe indicar el producto");
            //}
            //else
            //    this.Alert("Debe indicar la marca");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PMEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.cmbProduct;

            this.GetCompanies();

            this.GetProducts();

            this.GetMeasures();

            this.GetPMs();

            this.GetBrands();

            this.GetLocations();

            if (this.Id.HasValue)
            {
                this.LoadData(this.Id);
            }

            this.LoadComplete = true;

            if (this.IsCopy)
            {
                this.Id = null;
                this.HasImage = false;

                //this.txtPrice.Clear();
                this.txtCodigoProveedor.Clear();
                this.txtCodigo.Clear();
            }
        }

        private void Result2(bool IsCorrect, String ErrorMessage, int Id, Image Img)
        {
            this.pbPhoto.Image = Img;
        }

        private void pbPhoto_Click(object sender, EventArgs e)
        {
            ImageCapture ImageCapture = new ImageCapture(this.Id);

            ImageCapture.Result += new ImageCapture.Communication(Result2);

            ImageCapture.ShowDialog();
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = false;
            }
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            BarCode BarCode = new BarCode(this.Id.Value);

            BarCode.Result += new BarCode.Communication(Result2);

            BarCode.ShowDialog();
        }

        private void Result2(bool IsCorrect, string ErrorMessage, string BarCode)
        {
            this.txtCodigo.Text = BarCode;
        }

        private void txtCodigoProveedor_TextChanged(object sender, EventArgs e)
        {
            if (this.LoadComplete)
            {
                int code;
                string url = string.Empty;

                using (posb.Brand Brand = new posb.Brand
                {
                    Id = int.Parse(this.cmBrand.SelectedValue.ToString())
                })
                {
                    url = Brand.GetUrlSearch();
                }

                if (!string.IsNullOrEmpty(url))
                {
                    if (int.TryParse(this.txtCodigoProveedor.Text.Trim(), out code))
                    {
                        wbGetImagen.Navigate(string.Format(url, code.ToString().Trim()));
                    }
                }
            }
        }

        private void wbGetImagen_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Index++;

            if (this.Index.Equals(1))
            {
                HtmlElementCollection tables = this.wbGetImagen.Document.GetElementsByTagName("table");

                int index = 1;

                foreach (HtmlElement table in tables)
                {
                    if (index.Equals(3))
                    {
                        HtmlElementCollection anchors = table.GetElementsByTagName("a");

                        string url = "https://www.truper.com.mx/catvigente/";

                        foreach (HtmlElement anchor in anchors)
                        {
                            try
                            {
                                string[] parts = anchor.OuterHtml.Split(new[] { "MM_openBrWindow" }, StringSplitOptions.None);

                                string[] parts2 = parts[1].Split(')');

                                string[] parts3 = parts2[0].Split(',');

                                string myUrl = parts3[0].Replace("'", String.Empty).Replace("(", String.Empty);

                                url += myUrl;

                                var request = WebRequest.Create(url);

                                using (var response = request.GetResponse())
                                using (var stream = response.GetResponseStream())
                                {
                                    this.pbPhoto.Image = Bitmap.FromStream(stream);
                                }

                                break;
                            }
                            catch (Exception)
                            {
                                this.pbPhoto.Image = null;
                                break;
                            }
                        }
                    }

                    index++;
                }

                this.Index = 0;
            }
        }

        #endregion

        #region Methods

        private void GetLocations()
        {
            using (posb.Location Location = new posb.Location())
            {
                this.cmbLocation.Fill(Location.List());
            }
        }

        private void GetProducts()
        {
            using (posb.Product Product = new posb.Product())
            {
                this.cmbProduct.Fill(Product.List());
            }
        }

        private void GetBrands()
        {
            using (posb.Brand Brand = new posb.Brand())
            {
                this.cmBrand.Fill(Brand.List());
            }
        }

        private void GetCompanies()
        {
            using (posb.Company company = new posb.Company())
            {
                this.cmbCompany.Fill(company.List());
            }
        }

        private void GetMeasures()
        {
            using (posb.Measure Measure = new posb.Measure())
            {
                List<posb.Measure> lMeasure = Measure.List();

                this.cmbMeasure.Fill(lMeasure);

            }
        }

        private void GetPMs()
        {
            using (posb.PM pm = new posb.PM())
            {
                List<posb.PM> lPm = pm.ListForCombo();

                this.cmbMeasure2.Fill(lPm);
            }
        }

        private void LoadData(int? Id)
        {
            using (posb.PM Entity = new posb.PM
            {
                Id = this.Id,
                Name = this.Id.ToString()
            })
            {
                Entity.Get();

                int? idMeasure = Entity.IdMeasure == null ? 0 : Entity.IdMeasure,
                     idMeasure2 = Entity.IdMeasure2 == null ? 0 : Entity.IdMeasure2,
                     idBrand = Entity.IdBrand == null ? 0 : Entity.IdBrand,
                     idLocation = Entity.IdLocation == null ? 0 : Entity.IdLocation,
                     idCompany = Entity.IdCompany == null ? 0 : Entity.IdCompany;

                this.cmbProduct.SelectedValue = Entity.IdProduct;
                this.cmbMeasure.SelectedValue = idMeasure;
                this.cmbMeasure2.SelectedValue = idMeasure2;
                this.cmBrand.SelectedValue = idBrand;
                this.cmbLocation.SelectedValue = idLocation;
                this.cmbCompany.SelectedValue = idCompany;

                this.txtName.Text = Entity.Alias.Replace("N/A", string.Empty);
                this.txtPrice.Text = String.Format("{0:0.00}", Entity.Price);
                this.txtCodigo.Text = Entity.BarCode.Replace("N/A", string.Empty);
                this.txtCodigoProveedor.Text = Entity.CodeVendor.Replace("N/A", string.Empty);

                this.txtStockMax.Text = String.Format("{0:0}", Entity.Max);
                this.txtStockMin.Text = String.Format("{0:0}", Entity.Min);

                if (Entity.AmountMeasure2.HasValue && Entity.AmountMeasure2 > 0)
                    this.txtAmount.Text = Entity.AmountMeasure2.ToString();
                else
                    this.txtAmount.Text = string.Empty;

                this.cbActive.Checked = Entity.Active.Value;

                this.cbFreight.Checked = Entity.Freight.Value;

                byte[] picture = Entity.GetImage();

                if (picture != null)
                {
                    this.pbPhoto.Image = Image.FromStream(new MemoryStream(picture));
                    this.pbPhoto.Refresh();

                    this.HasImage = true;
                }

                if (Entity.Highlight.Value)
                {
                    this.cbColor.Checked = true;

                    this.pbColor.BackColor = System.Drawing.ColorTranslator.FromHtml(Entity.ColorHex);
                }
            }
        }

        private void Save()
        {
            using (posb.PM Entity = new posb.PM
            {
                IdProduct = int.Parse(this.cmbProduct.SelectedValue.ToString()),
                IdMeasure = int.Parse(this.cmbMeasure.SelectedValue.ToString()),
                IdMeasure2 = int.Parse(this.cmbMeasure2.SelectedValue.ToString()),
                IdBrand = int.Parse(this.cmBrand.SelectedValue.ToString()),
                IdLocation = int.Parse(this.cmbLocation.SelectedValue.ToString()),
                IdCompany = int.Parse(this.cmbCompany.SelectedValue.ToString()),
                Price = decimal.Parse(this.txtPrice.Text),
                BarCode = this.txtCodigo.Text,
                CodeVendor = this.txtCodigoProveedor.Text.Trim(),
                Active = this.cbActive.Checked,
                Id = this.Id,
                Freight = this.cbFreight.Checked,
                Name = this.txtName.Text,
                Max = int.Parse(this.txtStockMax.Text),
                Min = int.Parse(this.txtStockMin.Text)
            })
            {
                if (Entity.IdMeasure.Equals(0))
                    Entity.IdMeasure = null;

                if (Entity.IdMeasure2.Equals(0))
                    Entity.IdMeasure2 = null;

                double amountMeasure2 = 0;

                if (double.TryParse(txtAmount.Text, out amountMeasure2))
                {
                    Entity.AmountMeasure2 = amountMeasure2;
                }
                else
                {
                    Entity.AmountMeasure2 = null;
                }

                if (Entity.IdBrand.Equals(0))
                    Entity.IdBrand = null;

                if (Entity.Exist())
                    this.Alert("Ya se encuentra registrado el producto [" + this.cmbProduct.Text + " " + this.cmbMeasure.Text + "]");
                else
                {
                    Entity.Save();
                }
            }
        }

        private byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            int? id = null;

            //if (this.cmbMeasure.SelectedIndex > 0 && this.cbUpdate.Checked)
            //    id = int.Parse(this.cmbMeasure.SelectedValue.ToString());

            MeasureEdit MeasureEdit = new MeasureEdit(id);

            MeasureEdit.Result += new MeasureEdit.Communication(ResultEditMeasures);

            MeasureEdit.ShowDialog();
        }

        private void ResultEditMeasures(bool IsCorrect, String ErrorMessage, int Id)
        {
            this.GetMeasures();

            this.cmbMeasure.SelectedValue = Id;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (cbColor.Checked)
            {

                DialogResult result = colorDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.pbColor.BackColor = colorDialog1.Color;
                }
            }
        }

        private void cbColor_CheckedChanged(object sender, EventArgs e)
        {
            this.pbColor.Enabled = cbColor.Checked;

            if(!this.pbColor.Enabled)
                this.pbColor.BackColor = System.Drawing.ColorTranslator.FromHtml("#BEDAFE");
        }
    }
}
