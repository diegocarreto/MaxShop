using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using UtilitiesForm.Extensions;
using Utilities.Extensions;
using posb = PosBusiness;

namespace WindowsFormsApplication1
{
    public partial class Purchase : FormBase
    {
        #region Properties

        private decimal EntityPrice
        {
            get
            {
                return decimal.Parse(gvList[3, this.SelectRowIndex].Value.ToString());
            }
        }

        private string EntityName
        {
            get
            {
                return gvList[1, this.SelectRowIndex].Value.ToString();
            }
        }

        private int EntityId
        {
            get
            {
                return int.Parse(gvList[0, this.SelectRowIndex].Value.ToString());
            }
        }

        private double EntityAmount
        {
            get
            {
                return double.Parse(gvList[2, this.SelectRowIndex].Value.ToString());
            }
        }

        private int SelectRowIndex
        {
            get
            {
                return gvList.CurrentRow.Index;
            }
        }

        private int IdPM { get; set; }

        private posb.PM Entity { get; set; }

        private List<posb.ProductForAction> Products { get; set; }


        private int? IdPurchase { get; set; }

        #endregion

        #region Builder

        public Purchase(int? IdPurchase = null)
        {
            InitializeComponent();

            this.IdPurchase = IdPurchase;
        }

        #endregion

        #region Events

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (ofdDocument.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofdDocument.FileName;
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtBuscar.Text))
            {
                double code;

                if (txtBuscar.Text.Length.Equals(5) && double.TryParse(txtBuscar.Text, out code))
                {
                    List<posb.PM> pms = this.Entity.List((int)code, true);

                    if (pms.Count.Equals(1))
                    {
                        txtBuscar.Text = pms[0].Aux;
                        this.txtCantidad.Focus();
                    }
                }
                else if ((txtBuscar.Text.Length > 6 && double.TryParse(txtBuscar.Text, out code)) || double.TryParse(txtBuscar.Text.Substring(1, txtBuscar.Text.Length - 1), out code))
                {
                    List<posb.PM> pms = this.Entity.List(null, true, txtBuscar.Text);

                    if (pms.Count.Equals(1))
                    {
                        txtBuscar.Text = pms[0].Aux;
                        this.txtCantidad.Focus();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Products.Count > 0)
            {
                if (this.Confirm("¿Realmente deseas quitar el producto [" + this.EntityName + "]?"))
                {
                    try
                    {
                        this.Products.RemoveAll(p => p.Id.Equals(this.EntityId));

                        this.SetGrid(false);
                    }
                    catch (Exception ex)
                    {
                        this.Alert("Ocurrió un error al intentar quitar el producto [" + this.EntityName + "]. \r\nDescripcion: " + ex.Message, eForm.TypeError.Error);
                    }
                }

                this.CleanControls();
            }
            else
            {
                this.Alert("No tiene productos seleccionados.");

                this.CleanControls();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Products.Count > 0)
            {
                if (this.Confirm("¿Realmente deseas cancelar la compra?"))
                    this.CleanControls(true);
            }
            else
                this.CleanControls();

            this.SetAutoCompleteProducts();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.Products.Count > 0)
            {
                if (this.Confirm("¿Realmente deseas salir del módulo de compras?"))
                    this.Close();
            }
            else
                this.Close();
        }

        private void Sale_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtName;

            this.gvList.AutoGenerateColumns = false;

            this.Products = new List<posb.ProductForAction>();

            this.Entity = new posb.PM();

            this.SetAutoCompleteProducts();

            this.ConfigureOpenFileDialog();

            this.ConfigureDateTimePicker();

            this.GetCompanies();

            if (this.IdPurchase.HasValue)
            {
                this.LoadData(this.IdPurchase);
            }

            this.menuStrip1.BackColor = ColorTranslator.FromHtml(this.AppSet<string>("BackColorForm"));
            this.wizardToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.W;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.AddProduct();

            this.SetAutoCompleteProducts();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (this.cmbCompany.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    if (this.Products.Count > 0)
                    {
                        if (this.Confirm("¿Realmente deseas guardar la compra?"))
                        {
                            using (posb.Purchase purchase = new posb.Purchase())
                            {
                                purchase.Name = txtName.Text;
                                purchase.CreatedDate = dtpDate.Value;
                                purchase.Id = this.IdPurchase;
                                purchase.IdCompany = int.Parse(this.cmbCompany.SelectedValue.ToString());

                                if (purchase.Charge(this.Products))
                                {
                                    if (!string.IsNullOrEmpty(txtPath.Text))
                                    {
                                        string path = this.CopyFile(purchase.Id.Value);

                                        if (!string.IsNullOrEmpty(path))
                                        {
                                            purchase.Path = path;

                                            if (!purchase.SaveFile())
                                                this.Alert("Ocurrió un error al intentar guardar el comprobante indicado.");
                                        }
                                        else
                                        {
                                            this.Alert("Ocurrió un error al intentar copiar el comprobante indicado.");
                                        }

                                        this.CleanControls(true);
                                    }
                                    else
                                    {
                                        this.CleanControls(true);
                                    }

                                    if (purchase.Id.HasValue)
                                        this.Close();
                                }
                                else
                                {
                                    this.Alert(purchase.ErrorMessage);
                                }
                            }

                        }
                    }
                    else
                    {
                        this.Alert("No tiene productos seleccionados.");

                        this.CleanControls();
                    }
                }
                else
                {
                    this.Alert("Debe indicar un nombre para la compra.");

                    this.CleanControls();
                }

                this.SetAutoCompleteProducts();
            }
            else
            {
                this.Alert("Debe indicar el negocio.");
            }
        }

        private void Result(bool IsCorrect, int Id, Double Amount, String ErrorMessage)
        {
            if (this.ValidateStock(Id, Amount))
            {
                this.IdPM = Id;

                posb.ProductForAction product = this.GeCurrentPurchase();

                product.Amount = Amount;

                product.Price = (decimal)product.Amount * product.Unitary;

                this.SetGrid(false);
            }
        }

        private void Result2(bool IsCorrect, int Id, decimal Unitary, String ErrorMessage)
        {
            this.IdPM = Id;

            posb.ProductForAction product = this.GeCurrentPurchase();

            product.Unitary = Unitary;

            product.Price = (decimal)product.Amount * product.Unitary;

            this.SetGrid(false);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (this.Products.Count > 0)
            {
                this.QuantityEdit();
            }
            else
            {
                this.Alert("No tiene productos seleccionados.");

                this.CleanControls();
            }
        }

        private void gvList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            gvList.Cursor = Cursors.Default;
        }

        private void gvList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex.Equals(2) || e.ColumnIndex.Equals(3))
                gvList.Cursor = Cursors.Hand;
            else
                gvList.Cursor = Cursors.Default;
        }

        private void gvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex.Equals(2))
            {
                this.QuantityEdit();
            }
            else if (e.ColumnIndex.Equals(3))
            {
                this.PriceEdit();
            }
        }

        private void btnPrecio_Click(object sender, EventArgs e)
        {
            if (this.Products.Count > 0)
            {
                this.PriceEdit();
            }
            else
            {
                this.Alert("No tiene productos seleccionados.");

                this.CleanControls();
            }
        }

        private void wizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wizard Wizard = new Wizard();

            Wizard.TxtFocus = this.txtCantidad;

            Wizard.IsActive = false;

            Wizard.Result += new Wizard.Communication(ResultWizard);

            Wizard.ShowDialog();
        }

        #endregion

        #region Methods

        private void GetCompanies()
        {
            using (posb.Company company = new posb.Company())
            {
                this.cmbCompany.Fill(company.List());
            }
        }

        private void ConfigureDateTimePicker()
        {
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "dd/MM/yyyy";
        }

        private void ConfigureOpenFileDialog()
        {
            ofdDocument.FileName = string.Empty;

            ofdDocument.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofdDocument.Title = "Seleccione el archivo que se usa como comprobante de compra";

            ofdDocument.DefaultExt = "jpg";
            ofdDocument.Filter = "Imagenes jpg (*.jpg)|*.jpg|Imagenes png (*.png)|*.png|Archivos pdf (*.pdf)|*.pdf|Archivos Word (*.docx)|*.docx|Archivos Excel (*.xlsx)|*.xlsx";
        }

        private string CopyFile(int Id)
        {
            try
            {
                int total;

                string directory = System.AppDomain.CurrentDomain.BaseDirectory + "\\Files", fileName;

                string[] filePaths;

                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                directory = System.AppDomain.CurrentDomain.BaseDirectory + "\\Files\\Purchase";

                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                directory = System.AppDomain.CurrentDomain.BaseDirectory + "\\Files\\Purchase" + "\\" + Id.ToString().PadLeft(10, '0');

                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                filePaths = Directory.GetFiles(directory, "*.*");

                total = filePaths.Length + 1;

                fileName = Path.GetFileName(txtPath.Text);

                fileName = total.ToString().PadLeft(4, '0') + "_" + fileName;

                directory += "\\" + fileName;

                File.Copy(txtPath.Text, directory);

                return directory;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public void SetAutoCompleteProducts()
        {
            List<posb.PM> pms = this.Entity.List(IsItForSale: true);

            AutoCompleteStringCollection data = new AutoCompleteStringCollection();

            foreach (posb.PM pm in pms)
            {
                data.Add(pm.Aux);
            }

            txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBuscar.AutoCompleteCustomSource = data;
        }

        private void CleanControls(bool All = false)
        {
            this.txtBuscar.Text = string.Empty;
            this.txtCost.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;

            this.txtBuscar.Focus();

            if (All)
            {
                this.txtTotal.Text = "0.00";
                this.lblTotalLetter.Text = "Cero Pesos 00/100 M.N.";
                this.txtPath.Text = string.Empty;
                this.txtName.Text = string.Empty;

                this.Products.Clear();
                this.SetGrid();

                this.txtName.Focus();
            }


        }

        private void ConfigureGridView()
        {
            this.gvList.AutoGenerateColumns = false;

            this.gvList.AllowUserToResizeColumns = false;

            this.gvList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void AddProduct()
        {
            string aux = txtBuscar.Text.Split('|')[0].Trim();

            this.Entity.Name = aux;

            this.IdPM = this.Entity.GetIdByName();

            if (this.IdPM.Equals(0))
            {
                this.Alert("No se encontró el producto " + this.txtBuscar.Text + ".");

                txtBuscar.Text = string.Empty;
                txtBuscar.Focus();
            }
            else
            {
                if (this.ValidateStock(this.IdPM))
                {
                    double amount = this.GetAmount();
                    posb.ProductForAction product = this.GeCurrentPurchase();

                    if (product != null)
                    {
                        product.Amount = product.Amount + amount;

                        product.Price = (decimal)product.Amount * product.Unitary;
                    }
                    else
                    {
                        string stringForPrice = aux.Split('$')[1].Trim(),
                               productName = aux.Split('$')[0].Trim();

                        decimal unitary = decimal.Parse(txtCost.Text);

                        if (stringForPrice.Contains('/'))
                        {
                            productName += "  / " + stringForPrice.Split('/')[1].Trim();
                        }

                        if (cbIva.Checked)
                        {
                            decimal unitaryIva = (unitary * this.AppSet<decimal>("Iva"));

                            unitary = unitary + unitaryIva;
                        }

                        posb.ProductForAction venta = new posb.ProductForAction
                        {
                            Id = this.IdPM,
                            Name = productName,
                            Amount = amount,
                            Unitary = unitary,
                            Code = this.IdPM.ToString().PadLeft(5, '0')
                        };

                        venta.Price = (decimal)venta.Amount * venta.Unitary;

                        this.Products.Add(venta);
                    }

                    this.SetGrid();

                    txtBuscar.Text = string.Empty;

                    this.CleanControls();
                }
            }
        }

        private void SetGrid(bool Revert = true)
        {
            this.gvList.DataSource = new List<posb.ProductForAction>();

            if (Revert)
            {
                List<posb.ProductForAction> lPreProduct = new List<posb.ProductForAction>();

                for (int i = this.Products.Count - 1; i >= 0; i--)
                {
                    lPreProduct.Add(Products[i]);
                }

                this.gvList.DataSource = lPreProduct;
            }
            else
            {
                this.gvList.DataSource = this.Products;
            }

            lblTotal.Text = this.gvList.RowCount.ToString();

            this.GetTotalSales();
        }

        /// <summary>
        /// Indica si el stock disponible es suficiente para la venta.
        /// </summary>
        /// <param name="IdPm">Identificador del producto.</param>
        /// <returns></returns>
        private bool ValidateStock(int IdPm, double? Amount = null)
        {
            this.Entity.Id = this.IdPM;

            double amount = Amount.HasValue ? Amount.Value : this.GetAmount();

            if (!Amount.HasValue)
            {
                posb.ProductForAction product = this.GeCurrentPurchase();

                if (product != null)
                    amount += product.Amount;
            }

            if (amount.Equals(0))
            {
                this.Alert("No puede agregar cero como cantidad de producto.");

                txtCantidad.Text = string.Empty;
                txtCantidad.Focus();

                return false;
            }
            else

                return true;
        }

        /// <summary>
        /// Obtiene la cantidad ingresada por el usuario.
        /// </summary>
        /// <returns></returns>
        private double GetAmount()
        {
            return double.Parse(txtCantidad.Text);
        }

        /// <summary>
        /// Obtiene el producto en caso de que ya exista en la compra actual.
        /// </summary>
        /// <returns>Producto de venta.</returns>
        private posb.ProductForAction GeCurrentPurchase()
        {
            return Products.Find(p => p.Code.Equals(this.IdPM.ToString().PadLeft(5, '0')));
        }

        private void GetTotalSales()
        {
            txtTotal.Text = String.Format("{0:0.00}", this.Products.Sum(item => item.Price));

            lblTotalLetter.Text = new Numalet().Convert(txtTotal.Text);
        }

        private void LoadData(int? Id)
        {
            using (posb.Purchase Entity = new posb.Purchase())
            {
                Entity.Get(Id);

                this.txtName.Text = Entity.Name;
                this.txtTotal.Text = Entity.Total.ToString();
                this.dtpDate.Value = Entity.Date.Value;

                int? idCompany = Entity.IdCompany == null ? 0 : Entity.IdCompany;
                this.cmbCompany.SelectedValue = idCompany;

                foreach (var ele in Entity.Products)
                {
                    ele.Code = ele.Code.PadLeft(5, '0');
                }

                this.Products = Entity.Products;

                this.SetGrid(false);

                //    this.txtBuscar.Enabled = false;

                //    this.txtCantidad.Enabled = false;
                //    this.txtCantidad.Clear();

                //    this.btnOk.Enabled = false;
                //    this.txtCliente.Enabled = false;
                //    this.txtTotal.Enabled = false;
                //    this.txtPago.Enabled = false;
                //    this.txtCambio.Enabled = false;
                //    this.cmbPaymentType.Enabled = false;
                //    this.gvList.Enabled = false;

                //    this.button4.Visible = false;
                //    this.button1.Visible = false;
                //    this.button3.Visible = false;
                //    this.button2.Visible = false;

                //    this.btnCancelar.Text = "Cerrar";
                //    this.ActiveControl = btnCancelar;

                //    this.btnCobrar.Text = "Ticket";

                //    this.txtCliente.Text = Entity.ClientName;
                //    this.txtTotal.Text = String.Format("{0:0.00}", Entity.Total);
                //    this.txtPago.Text = String.Format("{0:0.00}", Entity.Payment);
                //    this.txtCambio.Text = String.Format("{0:0.00}", (Entity.Payment - Entity.Total));

                //    this.cmbPaymentType.SelectedText = Entity.PaymentType.Trim();

                //    this.CreatedDate = Entity.CreatedDate;

                //    switch (Entity.PaymentType.Trim())
                //    {
                //        case "Cheque":

                //            this.cmbPaymentType.SelectedIndex = 0;

                //            break;

                //        case "Efectivo":

                //            this.cmbPaymentType.SelectedIndex = 1;

                //            break;

                //        case "Tarjeta de crédito":

                //            this.cmbPaymentType.SelectedIndex = 2;

                //            break;

                //        case "Tarjeta de debito":

                //            this.cmbPaymentType.SelectedIndex = 3;

                //            break;

                //        default:

                //            this.cmbPaymentType.SelectedIndex = 1;

                //            break;
                //    }

                //    this.cmbPaymentType.SelectedValue = Entity.PaymentType.Trim();

                //    foreach (var ele in Entity.Products)
                //    {
                //        ele.Code = ele.Code.PadLeft(5, '0');
                //    }

                //    this.Products = Entity.Products;

                //    this.SetGrid(false);
            }
        }

        private void QuantityEdit()
        {
            ChangeProductQuantity QuantityEdit = new ChangeProductQuantity(this.EntityId, this.EntityAmount, this.EntityName);

            QuantityEdit.Result += new ChangeProductQuantity.Communication(Result);

            QuantityEdit.ShowDialog();

            this.CleanControls();
        }

        private void PriceEdit()
        {
            ChangeProductPrice PriceEdit = new ChangeProductPrice(this.EntityId, this.EntityPrice, this.EntityName);

            PriceEdit.Result += new ChangeProductPrice.Communication(Result2);

            PriceEdit.ShowDialog();

            this.CleanControls();
        }

        private void ResultWizard(bool IsCorrect, String ErrorMessage, int IdPm, TextBox TxtFocus)
        {
            using (posb.PM pm = new posb.PM())
            {
                this.txtBuscar.Text = pm.List(IdPm, true).First().Aux;
            }
        }

        #endregion
    }
}