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
using Utilities.Extensions;
using PosBusiness;
using System.Text.RegularExpressions;
using System.Drawing.Printing;
using Utilities;
using System.Drawing;
using tessnet2;
//using tessnet2;

namespace WindowsFormsApplication1
{
    public partial class Refill : FormBase
    {
        #region Properties

        private double CommissionForRecharge = 0;

        private int index = 0;

        private int index2 = 0;

        private List<TransactionDetails> lTd = new List<TransactionDetails>();

        private System.Windows.Forms.CheckBox CheckBoxHeader = new System.Windows.Forms.CheckBox();

        private bool LoadAllCompany = false;

        private string GlobalComboName = string.Empty;

        private string GlobalCompanyName = string.Empty;

        private string GlobalIdCompany = string.Empty;

        private string GlobalARecargasDiv1 = string.Empty;

        private string GlobalARecargasDiv2 = string.Empty;

        private bool FirstCharge1 = false;

        private bool FirstCharge2 = false;

        private int TimerGeneral = 0;

        #endregion

        #region Builder

        public Refill()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void timer3_Tick(object sender, EventArgs e)
        {
            this.TimerGeneral++;

            if (TimerGeneral.Equals(2))
            {

                TimerGeneral = 0;
            }
        }

        private void cbFolio_CheckedChanged(object sender, EventArgs e)
        {
            this.txtFolio.Enabled = this.cbFolio.Checked;

            if (!this.cbFolio.Checked)
            {
                this.txtFolio.Clear();
                this.txtPago.Focus();
            }
            else
            {
                this.txtFolio.Focus();
                this.txtPago.Text = this.txtTotal.Text;
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }


        }

        private void txtPago_LostFocus(object sender, EventArgs e)
        {
            txtCambio.Text = (decimal.Parse(txtPago.Text) - decimal.Parse(txtTotal.Text)).ToString();
        }

        private void Measure_Load(object sender, EventArgs e)
        {
            if (this.AppSet<bool>("AutomaticLoginRefill"))
            {
                this.Enabled = false;
            }

            this.Width = 230;
            this.Height = 200;

            this.txtUser.Text = this.AppSet<string>("UserForRecharge");
            this.txtPassword.Text = this.AppSet<string>("PasswordForRecharge");

            this.CommissionForRecharge = this.AppSet<double>("CommissionForRecharge");

            //TelephoneRecharge recharge = new TelephoneRecharge
            //{
            //    Phone = "5559661108",
            //    CompanyName = "Telcel",
            //    Amount = "Sin límite 300 |800 Megas| SMS, Redes Sociales ilimitado| Vigencia 30 días",
            //    Successful = true,
            //    Message = "",
            //    Folio = "467437"
            //};



            //this.Print(149, recharge, 300, 500,new Numalet().Convert("301"));

            txtPago.LostFocus += new EventHandler(txtPago_LostFocus);


            webBrowser1.Navigate("http://www.recargamarcas.com");
            //webBrowser2.Navigate("http://www.misaldotelcel.com");

            var lCompany = new { Id = string.Empty, Name = string.Empty }.ToList();

            lCompany.Add(new { Id = "Telcel|cantidadt|6", Name = "Telcel" });
            lCompany.Add(new { Id = "Movistar|cantidadm|1", Name = "Movistar" });
            lCompany.Add(new { Id = "Iusacell|cantidadius|2", Name = "Iusacell" });
            lCompany.Add(new { Id = "Nextel|cantidadnex|4", Name = "Nextel" });
            lCompany.Add(new { Id = "Unefon|cantidadune|3", Name = "Unefon" });
            lCompany.Add(new { Id = "Virgin|cantidadv|5", Name = "Virgin" });
            lCompany.Add(new { Id = "Maztiempo|cantidadmaz|8", Name = "Maztiempo" });
            lCompany.Add(new { Id = "Cierto|cantidadcie|9", Name = "Cierto" });
            lCompany.Add(new { Id = "Alo|cantidada|7", Name = "Alo" });

            cmbCompany.FillStrings(lCompany);

            this.LoadAllCompany = true;

            this.pnlLogin.Visible = true;

            this.ActiveControl = this.txtCode;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }

            this.GetTotal();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            this.GetTotal();
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            this.GetTotal();
        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            this.GetTotal();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearFrm();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (this.btnView.Text.Equals("Ver", StringComparison.InvariantCultureIgnoreCase))
            {
                this.btnView.Text = "Ocultar";
                this.Width = 1236;
            }
            else
            {
                this.btnView.Text = "Ver";
                this.Width = 805;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtUser.Text))
            {
                if (this.txtUser.Text.Length.Equals(10))
                {
                    if (!string.IsNullOrEmpty(this.txtPassword.Text))
                    {
                        if (!string.IsNullOrEmpty(this.txtCode.Text))
                        {
                            if (this.txtCode.Text.Length.Equals(4))
                            {
                                //if (!string.IsNullOrEmpty(this.txtCode2.Text))
                                //{
                                //    if (this.txtCode2.Text.Length.Equals(5))
                                //    {
                                this.Login();
                                //    }
                                //    else
                                //    {
                                //        this.Alert("El codigo 2 debe tener 5 caracteres");
                                //        this.txtCode2.Clear();
                                //        this.txtCode2.Focus();
                                //    }
                                //}
                                //else
                                //{
                                //    this.Alert("Ingrese el codigo 2");
                                //    this.txtCode2.Focus();
                                //}
                            }
                            else
                            {
                                this.Alert("El código debe tener 4 caracteres");
                                this.txtCode.Clear();
                                this.txtCode.Focus();
                            }
                        }
                        else
                        {
                            this.Alert("Ingrese el código");
                            this.txtCode.Focus();
                        }
                    }
                    else
                    {
                        this.Alert("Ingrese la contraseña");
                        this.txtPassword.Focus();
                    }
                }
                else
                {
                    this.Alert("El usuario debe tener 10 caracteres");
                    this.txtUser.Clear();
                    this.txtUser.Focus();
                }
            }
            else
            {
                this.Alert("Ingrese el usuaro");
                this.txtUser.Focus();
            }
        }

        private void btnRecharging_Click(object sender, EventArgs e)
        {
            if (!this.cmbCompany.SelectedIndex.Equals(0))
            {
                if (!this.cmbAmount.SelectedIndex.Equals(0))
                {
                    if (!string.IsNullOrEmpty(this.txtPhone.Text))
                    {
                        if (!string.IsNullOrEmpty(this.txtConfirm.Text))
                        {
                            if (this.txtConfirm.Text.Length.Equals(10))
                            {
                                if (this.txtPhone.Text.Equals(this.txtConfirm.Text))
                                {
                                    if (!double.Parse(txtPago.Text).Equals(0))
                                    {
                                        if (double.Parse(txtCambio.Text) >= 0)
                                        {
                                            if (this.cbFolio.Checked)
                                            {
                                                if (!string.IsNullOrEmpty(this.txtFolio.Text))
                                                {
                                                    this.SaveRecarga3();

                                                    return;
                                                }
                                                else
                                                {
                                                    this.Alert("Indique el folio");
                                                    this.txtFolio.Focus();

                                                    return;
                                                }
                                            }

                                            WebBrowser wb = webBrowser1;

                                            //if (this.GlobalCompanyName.Equals("Telcel", StringComparison.InvariantCultureIgnoreCase))
                                            //{
                                            //    wb = webBrowser2;
                                            //}

                                            HtmlElement htmlElement = wb.Document.GetElementsByTagName("input")["telefono"];
                                            HtmlElement htmlElement2 = wb.Document.GetElementsByTagName("input")["confirmaciontelefono"];

                                            if (htmlElement != null)
                                            {
                                                htmlElement.SetAttribute("value", this.txtPhone.Text);
                                            }

                                            if (htmlElement2 != null)
                                            {
                                                htmlElement2.SetAttribute("value", this.txtConfirm.Text);
                                            }

                                            if (this.Confirm("¿Realmente desea realizar la recarga de " + this.cmbAmount.Text + ".00 al numero " + this.cmbCompany.Text + " " + this.txtPhone.Text + "?"))
                                            {
                                                //if (this.GlobalCompanyName.Equals("Telcel", StringComparison.InvariantCultureIgnoreCase))
                                                //{
                                                //    this.InvokeJsFunction("validarecarga", this.webBrowser2);

                                                //    this.timer2.Enabled = true;
                                                //}
                                                //else
                                                //{
                                                this.InvokeJsFunction("validarecarga", this.webBrowser1);

                                                this.timer1.Enabled = true;
                                                //}
                                            }
                                            else
                                            {
                                                this.Alert("La recarga fue cancelada");
                                                this.cmbCompany.Focus();
                                            }
                                        }
                                        else
                                        {
                                            this.Alert("El cambio no puede ser menor a cero.");

                                            this.txtPago.Text = "0.00";
                                            this.txtCambio.Text = "0.00";

                                            this.txtPago.Focus();
                                        }
                                    }
                                    else
                                    {
                                        this.Alert("El pago no puede ser cero.");

                                        this.txtPago.Text = "0.00";
                                        this.txtCambio.Text = "0.00";

                                        this.txtPago.Focus();
                                    }
                                }
                                else
                                    this.Alert("Los numeros telefonicos no coinciden");
                            }
                            else
                                this.Alert("El numero telefonico debe tener 10 digitos");
                        }
                        else
                            this.Alert("Confirme el numero telefonico");
                    }
                    else
                        this.Alert("Ingrese el numero telefonico");
                }
                else
                    this.Alert("Indique el monto");
            }
            else
                this.Alert("Indique la compañia");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            index++;

            if (index.Equals(1))
            {
                this.GetImage();
                this.txtCode.Focus();
            }
            else if (this.webBrowser1.Url.AbsoluteUri.Equals("http://www.recargamarcas.com/index.php"))
            {
                this.GetImage();

                this.txtCode.Focus();

                this.Alert("Ingrese nuevamente el código");
            }
            else if (this.webBrowser1.Url.AbsoluteUri.Equals("http://www.recargamarcas.com/inicio.php"))
            {
                if (!this.FirstCharge1)
                {
                    this.FirstCharge1 = true;
                    this.txtCode.Enabled = false;

                    this.ViewRecarga();
                }

                this.GetSaldo();
            }
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            index2++;

            if (index2.Equals(1))
            {
                this.GetCaptcha2();
                this.txtCode2.Focus();
            }
            else if (this.webBrowser2.Url.AbsoluteUri.Equals("https://www.misaldotelcel.com/index.php"))
            {
                this.GetCaptcha2();

                this.Alert("Ingrese nuevamente el codigo 2");

                this.txtCode2.Focus();
            }
            else if (this.webBrowser2.Url.AbsoluteUri.Equals("https://www.misaldotelcel.com/inicio.php"))
            {
                if (!this.FirstCharge2)
                {
                    this.FirstCharge2 = true;
                    this.txtCode2.Enabled = false;

                    this.ViewRecarga();
                }

                this.GetSaldo();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string text = this.GetARecargasDiv1();

            if (!text.Equals("cargando...") && !this.GlobalARecargasDiv1.Equals(text, StringComparison.InvariantCultureIgnoreCase))
            {
                this.timer1.Enabled = false;

                this.SaveRecarga1(text);

                this.InvokeJsFunction("muestra", this.webBrowser1, "4");
                this.InvokeJsFunction("muestra", this.webBrowser2, "4");

                this.webBrowser1.Refresh();
                this.webBrowser2.Refresh();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string text = this.GetARecargasDiv2();

            if (!text.Contains("esperando respuesta telcel...") && !this.GlobalARecargasDiv2.Equals(text, StringComparison.InvariantCultureIgnoreCase))
            {
                this.timer2.Enabled = false;

                this.SaveRecarga2(text);

                this.InvokeJsFunction("muestra", this.webBrowser1, "4");
                this.InvokeJsFunction("muestra", this.webBrowser2, "4");

                this.webBrowser1.Refresh();
                this.webBrowser2.Refresh();
            }
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.LoadAllCompany)
            {
                if (this.cmbCompany.SelectedIndex != 0)
                {
                    this.GetAmounts();
                    this.btnView.Enabled = true;
                }
                else
                {
                    this.cmbCompany.SelectedIndex = 0;

                    this.webBrowser1.Visible = false;
                    //this.webBrowser2.Visible = false;

                    this.btnView.Enabled = false;

                    this.Width = 805;

                    this.btnView.Text = "Ver";
                }
            }
        }

        private void cmbAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectAmount();
        }

        #endregion

        #region Methods

        public void GetTotal()
        {
            double val = 0;

            if (double.TryParse(txtAmount.Text, out val))
            {
                txtTotal.Text = String.Format("{0:0.00}", val + this.CommissionForRecharge);

                lblTotalLetter.Text = new Numalet().Convert(txtTotal.Text);
            }
        }

        private void InvokeJsFunction(string functionName, WebBrowser Browser, params object[] values)
        {
            Action action = () =>
            {
                // Your control and document 
                var htmlDocument = Browser.Document;
                if (htmlDocument != null)
                {
                    htmlDocument.InvokeScript(functionName, values);
                }
            };

            if (this.InvokeRequired) this.Invoke(action);
            else action();
        }

        private void GetImage()
        {
            mshtml.HTMLWindow2 w2 = webBrowser1.Document.Window.DomWindow as mshtml.HTMLWindow2;
            w2.execScript("var ctrlRange = document.body.createControlRange();ctrlRange.add(document.getElementById('captcha'));ctrlRange.execCommand('Copy');", "javascript");
            Image image2 = Clipboard.GetImage();
            pictureBox1.Image = image2;

            this.SetUserAndPassword1();

            this.txtCode.Clear();

            this.GetCaptcha();
        }

        private void GetCaptcha()
        {
            var bmp = new Bitmap(pictureBox1.Image);
            var ocr = new Tesseract();
            var path = System.AppDomain.CurrentDomain.BaseDirectory + "tessdata";

            ocr.SetVariable("tessedit_char_whitelist", "0123456789");
            ocr.Init(path, "eng", true);

            var result = ocr.DoOCR(bmp, Rectangle.Empty);

            foreach (var word in result)
            {
                this.txtCode.Text = word.Text.Trim();

                break;
            }

            HtmlElement htmlElement = this.webBrowser1.Document.GetElementsByTagName("input")["cap"];

            if (htmlElement != null)
            {
                htmlElement.SetAttribute("value", this.txtCode.Text);
            }

            if (this.AppSet<bool>("AutomaticLoginRefill"))
            {
                this.Enabled = true;
                this.Login();
            }
        }

        private void SetUserAndPassword1()
        {
            HtmlElement htmlElement = webBrowser1.Document.GetElementsByTagName("input")["usuario"];

            if (htmlElement != null)
            {
                htmlElement.SetAttribute("value", this.txtUser.Text);
            }

            HtmlElement htmlElement2 = webBrowser1.Document.GetElementsByTagName("input")["clave"];

            if (htmlElement2 != null)
            {
                htmlElement2.SetAttribute("value", this.txtPassword.Text);
            }
        }

        private void GetCaptcha2()
        {
            mshtml.HTMLWindow2 w2 = webBrowser2.Document.Window.DomWindow as mshtml.HTMLWindow2;
            w2.execScript("var ctrlRange = document.body.createControlRange();ctrlRange.add(document.getElementById('captcha'));ctrlRange.execCommand('Copy');", "javascript");
            Image image2 = Clipboard.GetImage();
            pictureBox2.Image = image2;

            this.SetUserAndPassword2();

            this.txtCode2.Clear();
        }

        private void SetUserAndPassword2()
        {
            HtmlElement htmlElement3 = webBrowser2.Document.GetElementsByTagName("input")["usuario"];

            if (htmlElement3 != null)
            {
                htmlElement3.SetAttribute("value", this.txtUser.Text);
            }

            HtmlElement htmlElement4 = webBrowser2.Document.GetElementsByTagName("input")["clave"];

            if (htmlElement4 != null)
            {
                htmlElement4.SetAttribute("value", this.txtPassword.Text);
            }
        }

        private void GetAmounts()
        {
            string[] elements = this.cmbCompany.SelectedValue.ToString().Split('|');

            string company = elements[0];
            string comboName = elements[1];
            string comboNumber = elements[2];

            this.GlobalCompanyName = company;
            this.GlobalComboName = comboName;
            this.GlobalIdCompany = comboNumber;

            //if (company.Equals("Telcel", StringComparison.InvariantCultureIgnoreCase))
            //{
            //    webBrowser1.Visible = false;
            //    webBrowser2.Visible = true;

            //    HtmlElement htmlElement = webBrowser2.Document.GetElementsByTagName("select")[comboName];

            //    if (htmlElement != null)
            //    {
            //        this.FillComboAmount(htmlElement);
            //    }
            //}
            //else
            //{
            webBrowser1.Visible = true;
            //webBrowser2.Visible = false;

            var btns = webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement btn in btns)
            {
                string value = btn.GetAttribute("value");

                if (value.Equals(company))
                {
                    btn.InvokeMember("click");

                    HtmlElement htmlElement = webBrowser1.Document.GetElementsByTagName("select")[comboName];

                    if (htmlElement != null)
                    {
                        this.FillComboAmount(htmlElement);
                    }
                }
            }
            //}
        }

        private void FillComboAmount(HtmlElement htmlElement)
        {
            var optionsHTML = htmlElement.GetElementsByTagName("option");

            var lAmount = new { Id = string.Empty, Name = string.Empty }.ToList();

            foreach (HtmlElement optionHTML in optionsHTML)
            {
                string option = optionHTML.InnerText.Trim();
                string value = optionHTML.GetAttribute("value").Trim();

                if (!string.IsNullOrEmpty(option) && !option.Equals("seleccione", StringComparison.InvariantCultureIgnoreCase))
                {
                    lAmount.Add(new { Id = value, Name = option });
                }
            }

            cmbAmount.FillStrings(lAmount);
        }

        private void SelectAmount()
        {

            if (this.cmbAmount.SelectedIndex != 0)
            {
                int amount = 0;
                string value = cmbAmount.Text.ToString();

                if (int.TryParse(value, out amount))
                {
                    this.txtAmount.Text = String.Format("{0:0.00}", amount);
                }
                else
                {
                    if (value.ToLower().Contains("sin límite"))
                    {
                        List<string> lElement = value.Split('|').ToList<string>();

                        string val = lElement[0].Replace("Sin límite", string.Empty).Trim();

                        int valInt = 0;

                        if (int.TryParse(val, out valInt))
                        {
                            this.txtAmount.Text = String.Format("{0:0.00}", valInt);
                        }
                        else
                            this.txtAmount.Clear();
                    }
                    else
                    {
                        List<string> lElement = value.Split('x').ToList<string>();

                        List<string> lElement2 = lElement[1].Split('|').ToList<string>();

                        string val = lElement2[0].Replace("$", string.Empty).Trim();

                        this.txtAmount.Text = val;
                    }
                }

                this.GetTotal();
            }
            else
                this.txtAmount.Clear();

            WebBrowser wb = webBrowser1;

            //if (this.GlobalCompanyName.Equals("Telcel", StringComparison.InvariantCultureIgnoreCase))
            //{
            //    wb = webBrowser2;
            //}

            HtmlElement htmlElement = wb.Document.GetElementsByTagName("select")[this.GlobalComboName];

            if (htmlElement != null)
            {
                htmlElement.SetAttribute("value", cmbAmount.SelectedValue.ToString());

                this.InvokeJsFunction("cambiamonto", this.webBrowser1, this.GlobalIdCompany);
            }
        }

        private void GetSaldo()
        {
            HtmlElement htmlElement = webBrowser1.Document.GetElementById("actualsaldo");

            if (htmlElement != null)
            {
                this.txtSaldoActual.Text = htmlElement.InnerText;
            }
            else
            {
                this.txtSaldoActual.Text = "No disponible";
            }
        }

        private void Login()
        {
            if (this.webBrowser1.Url.AbsoluteUri.Equals("http://www.recargamarcas.com/") ||
                this.webBrowser1.Url.AbsoluteUri.Equals("http://www.recargamarcas.com/index.php"))
            {
                this.SetUserAndPassword1();
                //this.SetUserAndPassword2();

                HtmlElement htmlElement3 = webBrowser1.Document.GetElementsByTagName("input")["cap"];

                if (htmlElement3 != null)
                {
                    htmlElement3.SetAttribute("value", this.txtCode.Text);
                }

                HtmlElement htmlElement4 = webBrowser1.Document.GetElementsByTagName("input")["button"];

                if (htmlElement4 != null)
                {
                    htmlElement4.InvokeMember("click");
                }
            }

            //if (this.webBrowser2.Url.AbsoluteUri.Equals("https://www.misaldotelcel.com/") ||
            //    this.webBrowser2.Url.AbsoluteUri.Equals("https://www.misaldotelcel.com/index.php"))
            //{
            //    HtmlElement htmlElement5 = webBrowser2.Document.GetElementsByTagName("input")["cap"];

            //    if (htmlElement5 != null)
            //    {
            //        htmlElement5.SetAttribute("value", this.txtCode2.Text);
            //    }

            //    var htmlElement6 = webBrowser2.Document.GetElementsByTagName("input");

            //    int indexElement = 0;

            //    foreach (HtmlElement input in htmlElement6)
            //    {
            //        indexElement++;

            //        if (indexElement.Equals(4))
            //        {
            //            input.InvokeMember("click");
            //        }
            //    }
            //}
        }

        private void ViewRecarga()
        {
            if (this.FirstCharge1)// && this.FirstCharge2)
            {
                this.pnlLogin.Visible = false;
                this.pnlRecargas.Visible = true;

                this.Width = 805;
                this.Height = 410;

                this.cmbCompany.Focus();

                this.GetSaldo();

                this.GlobalARecargasDiv1 = this.GetARecargasDiv1();

                //this.GlobalARecargasDiv2 = this.GetARecargasDiv2();

                this.AcceptButton = this.btnRecharging;

                this.timer3.Enabled = true;
            }
        }

        private string GetARecargasDiv1()
        {
            HtmlElement htmlElement = webBrowser1.Document.GetElementById("arecargas");

            if (htmlElement != null)
            {
                return htmlElement.InnerText.ToLower().Trim();
            }
            else
                return string.Empty;
        }

        private string GetARecargasDiv2()
        {
            HtmlElement htmlElement = webBrowser2.Document.GetElementById("arecargas");

            if (htmlElement != null)
            {
                if (string.IsNullOrEmpty(htmlElement.InnerText))
                {
                    return string.Empty;
                }
                else
                {
                    return htmlElement.InnerText.ToLower().Trim();
                }
            }
            else
                return string.Empty;
        }

        public void SaveRecarga1(string Message)
        {
            bool? successful = null;
            string folio = string.Empty;

            if (Message.ToLower().Contains("recarga exitosa"))
            {
                List<string> lResult = Regex.Split(Message, "\r\n").ToList<string>();

                folio = lResult[2].Split(':')[1];

                successful = true;

                this.Alert("¡Recarga Exitosa!\r\nFolio: " + folio);
            }
            else
            {
                folio = "Error";
                successful = false;

                this.Alert("¡Recarga fallida!\r\nDescripción: " + Message);
            }

            TelephoneRecharge recharge = new TelephoneRecharge
            {
                Phone = this.txtPhone.Text,
                CompanyName = this.cmbCompany.Text,
                Amount = decimal.Parse(this.txtTotal.Text),
                Plan = this.cmbAmount.Text,
                Successful = successful,
                Message = Message,
                Folio = folio
            };

            int id = recharge.Save();

            if (successful.Value && this.Confirm("¿Deseas imprimir el ticket?"))
            {
                this.Print(id, recharge, double.Parse(this.txtAmount.Text), double.Parse(this.txtPago.Text), lblTotalLetter.Text);
            }

            this.ClearFrm();
        }

        public void SaveRecarga2(string Message)
        {
            bool? successful = null;
            string folio = string.Empty;

            if (Message.ToLower().Contains("recarga exitosa"))
            {
                List<string> lResult = Regex.Split(Message, "\r\n").ToList<string>();

                folio = lResult[2].Split(':')[1];

                successful = true;

                this.Alert("¡Recarga Exitosa!\r\nFolio: " + folio);
            }
            else if (string.IsNullOrEmpty(Message))
            {
                Message = "No se encontró un mensaje de error";
                folio = "Error";
                successful = false;

                this.Alert("¡Recarga fallida!\r\nDescripción: " + Message);
            }
            else
            {
                folio = "Error";
                successful = false;

                this.Alert("¡Recarga fallida!\r\nDescripción: " + Message);
            }

            TelephoneRecharge recharge = new TelephoneRecharge
             {
                 Phone = this.txtPhone.Text,
                 CompanyName = this.cmbCompany.Text,
                 Amount = decimal.Parse(this.txtTotal.Text),
                 Plan = this.cmbAmount.Text,
                 Successful = successful,
                 Message = Message,
                 Folio = folio
             };

            int id = recharge.Save();

            if (successful.Value && this.Confirm("¿Deseas imprimir el ticket?"))
            {
                this.Print(id, recharge, double.Parse(this.txtAmount.Text), double.Parse(this.txtPago.Text), lblTotalLetter.Text);
            }

            this.ClearFrm();
        }

        public void SaveRecarga3()
        {
            TelephoneRecharge recharge = new TelephoneRecharge
            {
                Phone = this.txtPhone.Text,
                CompanyName = this.cmbCompany.Text,
                Amount = decimal.Parse(this.txtTotal.Text),
                Plan = this.cmbAmount.Text,
                Successful = true,
                Message = "Recarga realizada por otro medio",
                Folio = this.txtFolio.Text
            };

            int id = recharge.Save();

            if (this.Confirm("¿Deseas imprimir el ticket?"))
            {
                this.Print(id, recharge, double.Parse(this.txtAmount.Text), double.Parse(this.txtPago.Text), lblTotalLetter.Text);
            }

            this.ClearFrm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Recharge"></param>
        private void Print(int Id, TelephoneRecharge Recharge, double Amount, double Cash, string ChashLetter)
        {
            PrintDocument p = new PrintDocument();

            p.PrintPage += delegate(object sender1, PrintPageEventArgs e1)
            {
                string font = "Times New Roman";
                SolidBrush brush = new SolidBrush(Color.Black);

                Font f14 = new Font(font, 14, FontStyle.Bold),
                     f11 = new Font(font, 11),
                     f10 = new Font(font, 10),
                     f09 = new Font(font, 09),
                     f08 = new Font(font, 08),
                     f04 = new Font(font, 04);

                e1.Graphics.DrawString(this.AppSet<string>("ShopName").Replace("°", " "), f14, brush, 10, 20);
                e1.Graphics.DrawString(this.AppSet<string>("TicketAddress1"), f09, brush, 10, 45);
                e1.Graphics.DrawString(this.AppSet<string>("TicketAddress2"), f09, brush, 10, 60);
                e1.Graphics.DrawString("Tel. " + this.AppSet<string>("TicketPhoneNumber"), f09, brush, 10, 75);

                e1.Graphics.DrawString("Folio: " + Id.ToString().PadLeft(8, '0') + "            " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), f10, new SolidBrush(Color.Black), 10, 95);

                e1.Graphics.DrawString("==================================", f10, brush, 10, 105);

                e1.Graphics.DrawString("Servicio", f09, brush, 10, 115);
                e1.Graphics.DrawString("Referencia", f09, brush, 10, 125);
                e1.Graphics.DrawString("Compañia", f09, brush, 80, 125);
                e1.Graphics.DrawString("Número", f09, brush, 150, 125);
                e1.Graphics.DrawString("Importe", f09, brush, 230, 125);

                e1.Graphics.DrawString("==================================", f10, brush, 10, 133);

                int amount = 0;
                string service = string.Empty;

                if (int.TryParse(Recharge.Plan, out amount))
                {
                    service = "Recarga $" + String.Format("{0:0.00}", amount);
                }
                else
                {
                    if (Recharge.Plan.Length > 48)
                    {
                        service = Recharge.Plan.Substring(0, 45) + "...";
                    }
                    else
                    {
                        service = Recharge.Plan;
                    }
                }

                e1.Graphics.DrawString(service, f09, brush, 10, 145);

                e1.Graphics.DrawString(Recharge.Folio, f09, brush, 10, 160);
                e1.Graphics.DrawString(Recharge.CompanyName, f09, brush, 80, 160);
                e1.Graphics.DrawString(Recharge.Phone, f09, brush, 150, 160);

                var valueXAmount = this.StartXPosition(Amount, 264);
                e1.Graphics.DrawString(String.Format("{0:0.00}", Amount), f09, brush, valueXAmount, 160);


                e1.Graphics.DrawString(Id.ToString().PadLeft(6, '0'), f09, brush, 10, 175);
                e1.Graphics.DrawString("Comisión por recarga", f09, brush, 80, 175);
                e1.Graphics.DrawString("", f09, brush, 150, 175);

                var valueXAmount2 = this.StartXPosition(1, 264);
                e1.Graphics.DrawString(String.Format("{0:0.00}", this.CommissionForRecharge), f09, brush, valueXAmount2, 175);


                e1.Graphics.DrawString("==================================", f10, brush, 10, 190);

                e1.Graphics.DrawString("Total:", new Font("Times New Roman", 10), brush, 150, 205);
                e1.Graphics.DrawString("Efectivo:", new Font("Times New Roman", 10), brush, 150, 220);
                e1.Graphics.DrawString("Cambio:", new Font("Times New Roman", 10), brush, 150, 235);

                var valueXTotal = this.StartXPosition(Amount + this.CommissionForRecharge, 260);
                e1.Graphics.DrawString(String.Format("{0:0.00}", Amount + this.CommissionForRecharge), f10, brush, valueXTotal, 205);

                var valueXCash = this.StartXPosition(Cash, 260);
                e1.Graphics.DrawString(String.Format("{0:0.00}", Cash), f10, brush, valueXCash, 220);

                double cambio = Cash - (Amount + this.CommissionForRecharge);

                var valueXCambio = this.StartXPosition(cambio, 260);
                e1.Graphics.DrawString(String.Format("{0:0.00}", cambio), f10, brush, valueXCambio, 235);

                e1.Graphics.DrawString(ChashLetter, f08, brush, 10, 252);

                e1.Graphics.DrawString("==================================", f10, brush, 10, 265);
                e1.Graphics.DrawString("Sucursal: " + this.AppSet<string>("branchOffice"), f10, brush, 10, 280);
                e1.Graphics.DrawString("Caja: " + this.AppSet<string>("CashRegister"), f10, brush, 170, 280);

                e1.Graphics.DrawString("¡Gracias por su preferencia!", f11, brush, 50, 295);
                e1.Graphics.DrawString("MaxShop V1.0.0 - Punto de venta", f04, brush, 95, 315);
            };

            try
            {
                p.PrinterSettings.PrinterName = this.AppSet<string>("Printer");

                p.Print();
            }
            catch (Exception ex)
            {
                this.Alert("Ocurrió un error al intentar imprimir el ticket.", eForm.TypeError.Error);
            }
        }

        private int StartXPosition(object Amount, int StartPosition, int Step = 6)
        {
            int len = String.Format("{0:0.00}", Amount).Length;
            int valueXAmount = StartPosition - (len * Step);

            return valueXAmount;
        }

        private void ClearFrm()
        {
            this.GetTotal();

            this.cmbCompany.SelectedIndex = 0;

            if (this.cmbAmount.SelectedIndex != -1)
                this.cmbAmount.SelectedIndex = 0;

            this.txtPhone.Clear();
            this.txtConfirm.Clear();

            this.txtAmount.Text = "0.00";
            this.txtPago.Text = "0.00";
            this.txtTotal.Text = "0.00";
            this.txtCambio.Text = "0.00";

            this.btnView.Text = "Ver";
            this.btnView.Enabled = false;

            this.cbFolio.Checked = false;

            this.cmbCompany.Focus();
        }

        #endregion
    }
}
