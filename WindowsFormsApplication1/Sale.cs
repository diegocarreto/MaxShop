using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitiesForm.Extensions;
using Utilities.Extensions;
using posb = PosBusiness;
using Utilities;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using PosBusiness;

namespace WindowsFormsApplication1
{
    public partial class Sale : FormBase
    {
        #region Members

        private SearchProducts sp;

        private AutoCompleteTextBox txtBuscar = new AutoCompleteTextBox();

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreatedDate { get; set; }

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
                return double.Parse(gvList[4, this.SelectRowIndex].Value.ToString());
            }
        }

        private decimal EntityPrice
        {
            get
            {
                return decimal.Parse(gvList[5, this.SelectRowIndex].Value.ToString());
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

        private int? IdSale { get; set; }

        public bool Cancellation { get; set; }

        private posb.PM Entity { get; set; }

        private List<posb.ProductForAction> Products { get; set; }

        public static int Instances = 0;

        private bool ItsFirst = false;

        public int? IdSaleFather { get; set; }

        #endregion

        #region Builder

        public Sale(int? IdSale = null, bool Cancellation = false, int? IdFhater = null)
        {
            this.IdSale = IdSale;
            this.Cancellation = Cancellation;
            this.IdSaleFather = IdFhater;

            InitializeComponent();

            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(238, 47);
            this.txtBuscar.Size = new System.Drawing.Size(847, 29);
            this.txtBuscar.MaxLength = 100;

            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);
            this.txtBuscar.Result += new AutoCompleteTextBox.Communication(Result);

            this.Controls.Add(this.txtBuscar);

            Instances++;
        }

        #endregion

        #region Events

        private void Result()
        {
            this.txtCantidad.Focus();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            this.ShowClient();
        }

        private void ResultEmployee(bool IsCorrect, String ErrorMessage, int Id)
        {
            this.GetClients();

            this.cmbClient.SelectedValue = Id;
        }

        private void toolStripComboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.toolStripComboBoxClient.SelectedIndex != 1)
            {
                this.lblRef.Visible = true;
                this.txtRef.Visible = true;
            }
            else
            {
                this.lblRef.Visible = false;
                this.txtRef.Visible = false;
                this.txtRef.Clear();
            }
        }

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Add();
            }
        }

        private void wizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wizard Wizard = new Wizard();

            Wizard.Result += new Wizard.Communication(ResultWizard);

            Wizard.IsActive = false;

            Wizard.ShowDialog();
        }

        private void ResultWizard(bool IsCorrect, String ErrorMessage, int IdPm, TextBox TxtFocus)
        {
            using (posb.PM pm = new posb.PM { Id = IdPm })
            {
                this.SetAutoCompleteProducts();

                this.txtBuscar.Text = pm.List(IdPm, true).First().Aux;

                this.BuscarImagenUbicacion();

                this.Activate();

                this.txtCantidad.Focus();
            }
        }

        private void busquedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.sp = ShowOrActiveForm(this.sp, typeof(SearchProducts)) as SearchProducts;

            this.sp.Result += new SearchProducts.Communication(ResultWizard);
        }

        private void pbPhoto_Click(object sender, EventArgs e)
        {
            if (this.pbPhoto.Image != null)
            {
                ImageShow ImageShow = new ImageShow(this.Entity.Id);

                ImageShow.ShowDialog();
            }
        }

        private void Sale_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                this.ShowClient();
            }
            else if (e.KeyCode == Keys.F12)
            {
                if (!string.IsNullOrEmpty(this.txtPago.Text) && double.Parse(this.txtPago.Text) > 0)
                {
                    if (double.Parse(this.txtPago.Text) - double.Parse(this.txtACuenta.Text) >= 0)
                    {
                        this.Charge();
                    }
                    else
                    {
                        this.Alert("El monto pagado no puede ser menor al monto que se deja a cuenta");

                        this.txtPago.Clear();
                        this.txtCambio.Text = "0.00";

                        this.txtPago.Focus();
                    }
                }
                else
                {
                    this.txtPago.Clear();
                    this.txtCambio.Text = "0.00";

                    this.txtPago.Focus();
                }
            }
            else if (e.KeyValue.Equals(118))
            {
                if (string.IsNullOrEmpty(this.txtCantidad.Text))
                {
                    this.txtCantidad.Text = "0";
                }
                else
                {
                    int val = 0;

                    int.TryParse(this.txtCantidad.Text, out val);

                    val++;

                    this.txtCantidad.Text = val.ToString();
                }
            }
            else if (e.KeyValue.Equals(117))
            {
                if (string.IsNullOrEmpty(this.txtCantidad.Text))
                {
                    this.txtCantidad.Text = "0";
                }
                else
                {
                    double val = 0;

                    double.TryParse(this.txtCantidad.Text, out val);

                    val--;

                    if (val < 0.5)
                    {
                        val = 0.5;
                    }
                    else if (val < 1)
                    {
                        val = 0.5;
                    }

                    this.txtCantidad.Text = val.ToString();
                }
            }
            else if (e.KeyValue.Equals(119))
            {
                if (!string.IsNullOrEmpty(this.txtBuscar.Text))
                {
                    this.Add();
                }
            }
            else if (e.KeyValue.Equals(116))
            {
                this.CleanControls();
            }
        }

        private void btnBorra_Click(object sender, EventArgs e)
        {
            this.CleanControls();
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            this.BuscarImagenUbicacion();
        }

        private void BuscarImagenUbicacion()
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                string aux = txtBuscar.Text.Split('|')[0].Trim();

                this.Entity.Name = aux;

                this.txtLocation.Text = this.Entity.GetLocationByName();

                this.Entity.GetIdByName();

                byte[] picture = Entity.GetImage();

                this.pbPhoto.Image = null;

                if (picture != null)
                {
                    this.pbPhoto.Image = Image.FromStream(new MemoryStream(picture));
                    this.pbPhoto.Refresh();

                    this.pbPhoto.Cursor = Cursors.Hand;
                }
                else
                    this.pbPhoto.Cursor = Cursors.No;
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

                        this.SetGrid();
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
            if (this.btnCancelar.Text.Equals("Cerrar"))
            {
                this.Close();
            }
            else
            {
                if (this.Products.Count > 0)
                {
                    if (this.Confirm("¿Realmente deseas cancelar la venta?"))
                        this.CleanControls(true);
                }
                else
                    this.CleanControls(true);

                this.SetAutoCompleteProducts();
                this.SetAutoCompleteClient();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sale_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtBuscar;

            this.GetClients();

            this.Products = new List<posb.ProductForAction>();

            this.txtPago.LostFocus += new EventHandler(txtPago_LostFocus);

            this.Entity = new posb.PM();

            this.SetAutoCompleteProducts();
            this.SetAutoCompleteClient();

            this.SetPaymentType();

            this.gvList.Columns["Id"].Visible = false;

            if (Sale.Instances.Equals(1))
            {
                this.ItsFirst = true;

                this.SetTitle();
            }

            if (this.IdSale.HasValue)
            {
                this.LoadData(this.IdSale);
            }

            this.menuStrip1.BackColor = ColorTranslator.FromHtml(this.AppSet<string>("BackColorForm"));
            this.wizardToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.W;
            this.busquedaToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.B;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Add();
        }

        private void txtPago_LostFocus(object sender, EventArgs e)
        {
            decimal pago = 0;

            decimal.TryParse(this.txtPago.Text, out pago);

            this.txtCambio.Text = (pago - decimal.Parse(this.txtACuenta.Text)).ToString();
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
            this.Charge();
        }

        private void Result(bool IsCorrect, int Id, Double Amount, String ErrorMessage)
        {
            if (this.ValidateStock(Id, Amount))
            {
                this.IdPM = Id;

                posb.ProductForAction product = this.GeCurrentSale();

                product.Amount = Amount;

                product.Price = (decimal)product.Amount * product.Unitary;

                this.SetGrid();
            }
        }

        private void Result2(bool IsCorrect, int Id, decimal Unitary, String ErrorMessage)
        {
            this.IdPM = Id;

            posb.ProductForAction product = this.GeCurrentSale();

            product.Unitary = Unitary;

            product.Price = (decimal)product.Amount * product.Unitary;

            this.SetGrid();
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

        private void button3_Click(object sender, EventArgs e)
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
                        txtCantidad.Text = "1";
                    }

                    this.AddProduct();
                    this.SetAutoCompleteProducts();
                    this.SetAutoCompleteClient();
                }
                else if ((txtBuscar.Text.Length > 6 && double.TryParse(txtBuscar.Text, out code)) || double.TryParse(txtBuscar.Text.Substring(1, txtBuscar.Text.Length - 1), out code))
                {
                    List<posb.PM> pms = this.Entity.List(null, true, txtBuscar.Text);

                    if (pms.Count.Equals(1))
                    {
                        txtBuscar.Text = pms[0].Aux;
                        txtCantidad.Text = "1";
                    }
                    else
                    {
                        //this.Alert("Existen " + pms.Count + " productos con el mismo código de barras");

                        SelectByBarCode selectByBarCode = new SelectByBarCode(pms);

                        selectByBarCode.TxtFocus = this.txtCantidad;

                        selectByBarCode.Result += new SelectByBarCode.Communication(ResultSelectBYCodeBar);

                        selectByBarCode.ShowDialog();

                        return;
                    }

                    this.AddProduct();
                    this.SetAutoCompleteProducts();
                    this.SetAutoCompleteClient();
                }
                else
                {
                    this.txtCantidad.Focus();
                }
            }
        }

        private void ResultSelectBYCodeBar(bool IsCorrect, String ErrorMessage, int IdPm, TextBox TxtFocus)
        {
            using (posb.PM pm = new posb.PM { Id = IdPm })
            {
                this.txtBuscar.Text = pm.List(IdPm, true).First().Aux;

                this.BuscarImagenUbicacion();

                this.AddProduct();
            }
        }

        private void txtCliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cmbClient.Text))
                this.Text = "Venta - " + this.cmbClient.Text;
            else
                this.Text = "Venta";
        }

        private void Sale_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Products.Count > 0 && !this.IdSale.HasValue && this.gvList.Enabled)
            {
                if (this.Confirm("¿Realmente deseas salir del módulo de ventas?"))
                {
                    if (sp != null)
                        sp.Close();
                    e.Cancel = false;

                }
                else
                    e.Cancel = true;
            }
            else
            {
                e.Cancel = false;

                if (sp != null)
                    sp.Close();
            }

            Instances--;
        }

        private void gvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex.Equals(4))
            {
                this.QuantityEdit();
            }
            else if (e.ColumnIndex.Equals(5))
            {
                this.PriceEdit();
            }
            else if (e.ColumnIndex.Equals(6))
            {
                if (gvList[6, this.SelectRowIndex].Value.ToString().Equals("S", StringComparison.InvariantCultureIgnoreCase))
                {
                    this.FreightEdit();
                }
            }
        }

        private void gvList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            gvList.Cursor = Cursors.Default;
        }

        private void gvList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex.Equals(4) || e.ColumnIndex.Equals(5) || e.ColumnIndex.Equals(6))
                gvList.Cursor = Cursors.Hand;
            else
                gvList.Cursor = Cursors.Default;
        }

        #endregion

        #region Methods

        private void ShowClient()
        {
            ClientEdit ClientEdit = new ClientEdit();

            ClientEdit.Result += new ClientEdit.Communication(ResultEmployee);

            ClientEdit.ShowDialog();
        }

        private void GetClients()
        {
            using (posb.Client client = new posb.Client())
            {
                this.cmbClient.Fill(client.List(), AddFirstOption: false);

                this.cmbClient.SelectedValue = this.AppSet<int>("DefaultClientId");
            }
        }

        private Form ShowOrActiveForm(Form form, Type t, bool Dialog = false)
        {
            if (form == null)
            {
                form = (Form)Activator.CreateInstance(t);
                form.StartPosition = FormStartPosition.CenterScreen;

                if (!Dialog)
                {
                    form.MdiParent = this.MdiParent;
                    form.Show();
                }
                else
                {
                    form.MdiParent = null;
                    form.ShowDialog();
                }
            }
            else
            {
                form.StartPosition = FormStartPosition.CenterScreen;

                if (form.IsDisposed)
                {
                    form = (Form)Activator.CreateInstance(t);
                    form.MdiParent = this.MdiParent;

                    if (!Dialog)
                    {
                        form.MdiParent = this.MdiParent;
                        form.Show();
                    }
                    else
                    {
                        form.MdiParent = null;
                        form.ShowDialog();
                    }
                }
                else
                {
                    if (!Dialog)
                    {
                        form.Activate();
                    }
                    else
                    {
                        form.MdiParent = null;
                        form.ShowDialog();
                    }

                }
            }
            return form;
        }

        private void Disable(bool Enabled = false)
        {
            this.txtBuscar.Enabled = Enabled;
            this.txtRef.Enabled = Enabled;
            this.txtCantidad.Enabled = Enabled;

            this.btnOk.Enabled = Enabled;
            this.cmbClient.Enabled = Enabled;
            this.txtTotal.Enabled = Enabled;
            this.txtACuenta.Enabled = Enabled;
            this.txtPago.Enabled = Enabled;
            this.txtCambio.Enabled = Enabled;
            this.toolStripComboBoxClient.Enabled = Enabled;
            this.gvList.Enabled = Enabled;

            this.button4.Visible = Enabled;
            this.button1.Visible = Enabled;
            this.button3.Visible = Enabled;
            this.button2.Visible = Enabled;
            this.btnBorra.Visible = Enabled;

            this.btnUser.Enabled = Enabled;
        }

        private void Add()
        {
            this.AddProduct();

            this.SetAutoCompleteProducts();
            this.SetAutoCompleteClient();
        }

        private void Charge()
        {
            if (btnCobrar.Text.Equals("Ticket (F12)"))
            {
                if (this.Confirm("¿Deseas imprimir el ticket?"))
                {
                    new Ticket().Print(this.IdSale.Value,
                                       this.Products,
                                       double.Parse(txtPago.Text),
                                       lblTotalLetter.Text,
                                       this.cmbClient.Text,
                                       this.toolStripComboBoxClient.Text,
                                       double.Parse(this.txtACuenta.Text),
                                       this.CreatedDate.Value.ToString("dd/MM/yyyy hh:mm:ss"));
                }

                return;
            }
            else if (!this.gvList.Enabled)
            {
                this.Disable(true);
                this.CleanControls(true);
                this.btnCancelar.Enabled = true;

                return;
            }
            else if (this.Products.Count > 0)
            {
                if (double.Parse(this.txtTotal.Text) >= double.Parse(this.txtACuenta.Text))
                {
                    if (!string.IsNullOrEmpty(txtPago.Text) && double.Parse(txtPago.Text) > 0)
                    {
                        if (double.Parse(this.txtPago.Text) - double.Parse(this.txtACuenta.Text) >= 0)
                        {
                            if (this.Confirm("¿Deseas realizar la venta?"))
                            {
                                using (posb.Sale sale = new posb.Sale())
                                {
                                    var oneTicket = this.AppSet<bool>("OneTicket");
                                    var printTicket = this.Confirm("¿Deseas imprimir el ticket?");

                                    var ids = this.Products.Select(x => x.IdCompany).Distinct().ToList();
                                    var idSale = 0;

                                    var pagoParcial = double.Parse(this.txtACuenta.Text);
                                    var print = (!oneTicket && printTicket);

                                    double acuenta = double.Parse(this.txtACuenta.Text);
                                    double pago = double.Parse(txtPago.Text);
                                    double acuentaEstatico = acuenta;

                                    double aCuentaPorNegocio = 0;
                                    double cambioPorNegocio = 0;
                                    double pagoPorNegocio = 0;

                                    for (var i = 0; i < ids.Count; i++)
                                    {
                                        var id = ids[i];

                                        var products = this.Products.FindAll(p => p.IdCompany.Equals(id));
                                        double precioProductosPorNegocio = (double)products.Sum(p => p.Price);

                                        if (ids.Count.Equals(1))
                                        {
                                            aCuentaPorNegocio = acuenta;
                                            pagoPorNegocio = pago;
                                            cambioPorNegocio = pago - acuenta;
                                        }
                                        else
                                        {
                                            if (precioProductosPorNegocio <= acuenta)
                                            {
                                                aCuentaPorNegocio = precioProductosPorNegocio;
                                                pagoPorNegocio = precioProductosPorNegocio;
                                                cambioPorNegocio = 0;
                                            }
                                            else
                                            {
                                                aCuentaPorNegocio = acuenta;
                                                pagoPorNegocio = acuenta;
                                                cambioPorNegocio = acuenta - precioProductosPorNegocio;
                                            }

                                            acuenta -= aCuentaPorNegocio;
                                        }

                                        idSale = this.Charge2(products,
                                                              int.Parse(this.cmbClient.SelectedValue.ToString()),
                                                              this.toolStripComboBoxClient.Text,
                                                              pagoPorNegocio,
                                                              aCuentaPorNegocio,
                                                              cambioPorNegocio,
                                                              false,
                                                              id,
                                                              Print: (!oneTicket && printTicket),
                                                              Reference: this.txtRef.Text);

                                    }

                                    if (oneTicket && printTicket)
                                    {
                                        new Ticket().Print(idSale,
                                                           this.Products,
                                                           double.Parse(txtPago.Text),
                                                           lblTotalLetter.Text,
                                                           this.cmbClient.Text,
                                                           this.toolStripComboBoxClient.Text,
                                                           double.Parse(this.txtACuenta.Text),
                                                           IdCompany: null,
                                                           Principal: true,
                                                           ExtraSale: this.Products.Count - 1);
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.Alert("El monto pagado no puede ser menor al monto que se deja a cuenta.");

                            this.txtPago.Text = "0.00";
                            this.txtCambio.Text = "0.00";

                            this.txtPago.Focus();
                        }
                    }
                    else
                    {
                        this.Alert("Debe indicar el pago.");

                        this.txtPago.Text = "0.00";
                        this.txtCambio.Text = "0.00";

                        this.txtPago.Focus();
                    }
                }
                else
                {
                    this.Alert("El monto del campo a cuenta no puede ser mayor al total de la venta.");

                    this.txtACuenta.Text = this.txtTotal.Text;
                    this.txtACuenta.Focus();
                }
            }
            else
            {
                this.Alert("No tiene productos seleccionados.");

                this.CleanControls();
            }

            this.SetAutoCompleteProducts();
            this.SetAutoCompleteClient();
        }

        private int Charge2(List<ProductForAction> Products, int IdClient, string PaymentType, double Payment, double ACuenta, double Cambio, bool Freight = false, int? IdCompany = null, bool Print = true, string Reference = "")
        {
            using (posb.Sale sale = new posb.Sale())
            {
                if (sale.Charge(Products, IdClient, PaymentType, Payment, ACuenta, Cambio, Freight, IdCompany, Reference))
                {
                    if (Print)
                    {
                        double total = (double)Products.Sum(item => item.Price);

                        string ltr = new Numalet().Convert(total.ToString());

                        new Ticket().Print(sale.Id.Value,
                                           Products,
                                           Payment,
                                           ltr,
                                           this.cmbClient.Text,
                                           PaymentType,
                                           double.Parse(this.txtACuenta.Text),
                                           IdCompany: IdCompany,
                                           Principal: null);
                    }

                    this.Disable();
                    this.btnCancelar.Enabled = false;
                }
                else
                {
                    this.Alert("Ocurrió un error al guardar la venta.\r\nDescripción: " + sale.ErrorMessage, eForm.TypeError.Error);

                    this.CleanControls();
                }

                if (this.Cancellation)
                {
                    sale.AddFather(sale.Id.Value, this.IdSaleFather.Value);
                }

                return sale.Id.Value;
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

        private void FreightEdit()
        {
            PmFreightEdit FreightEdit = new PmFreightEdit(this.EntityId, int.Parse(this.cmbClient.SelectedValue.ToString()), this.EntityAmount);

            FreightEdit.Result += new PmFreightEdit.Communication(ResultFreightEdit);

            FreightEdit.ShowDialog();

            //this.CleanControls();
        }

        private void ResultFreightEdit(int IdPM, int IdClient, decimal Unitary, double Amount)
        {
            this.IdPM = IdPM;

            this.cmbClient.SelectedValue = IdClient;

            posb.ProductForAction product = this.GeCurrentSale();

            product.Unitary = Unitary;

            product.Amount = Amount;

            product.Price = (decimal)product.Amount * product.Unitary;

            this.SetGrid();

            this.txtBuscar.Focus();
        }

        private void SetTitle()
        {
            if (this.ItsFirst || Sale.Instances.Equals(1))
            {
                if (!string.IsNullOrEmpty(this.cmbClient.Text))
                    this.Text = "Venta - " + this.cmbClient.Text;
                else
                    this.Text = "Venta";

                this.ItsFirst = true;
            }
        }

        private void CleanControls(bool All = false)
        {
            this.txtBuscar.Text = string.Empty;
            this.txtCantidad.Text = "1";
            this.txtLocation.Text = string.Empty;
            this.pbPhoto.Image = null;

            this.pbPhoto.Cursor = Cursors.No;

            if (All)
            {
                this.txtTotal.Text = "0.00";
                this.lblTotalLetter.Text = "Cero Pesos 00/100 M.N.";
                this.txtPago.Text = "0.00";
                this.txtCambio.Text = "0.00";
                this.txtACuenta.Text = "0.00";
                this.GetClients();

                this.toolStripComboBoxClient.SelectedIndex = 1;

                this.Products.Clear();
                this.SetGrid();

                this.SetTitle();
            }

            this.txtBuscar.Focus();
        }

        private void ConfigureGridView()
        {
            this.gvList.AutoGenerateColumns = false;

            this.gvList.AllowUserToResizeColumns = false;

            this.gvList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public void SetAutoCompleteProducts()
        {
            List<posb.PM> pms = this.Entity.List(IsItForSale: true);

            List<AuxAutoCompleteTextBox> lproducts3 = new List<AuxAutoCompleteTextBox>();

            foreach (posb.PM pm in pms)
            {
                lproducts3.Add(new AuxAutoCompleteTextBox
                {
                    Prop1 = pm.Aux,
                    Prop2 = pm.Name,
                    Prop3 = pm.Aux,
                    Highlight = pm.Highlight,
                    ColorHex = pm.ColorHex
                });
            }

            this.txtBuscar.Content = lproducts3;
        }

        private void SetAutoCompleteClient()
        {
            //List<posb.PM> pms = this.Entity.ListClients();

            //AutoCompleteStringCollection data = new AutoCompleteStringCollection();

            //foreach (posb.PM pm in pms)
            //{
            //    data.Add(pm.ClientName);
            //}

            //txtCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            //txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txtCliente.AutoCompleteCustomSource = data;
        }

        private void SetPaymentType()
        {
            this.toolStripComboBoxClient.Items.Add("Cheque");
            this.toolStripComboBoxClient.Items.Add("Efectivo");
            this.toolStripComboBoxClient.Items.Add("Tarjeta de crédito");
            this.toolStripComboBoxClient.Items.Add("Tarjeta de debito");

            this.toolStripComboBoxClient.SelectedIndex = 1;
        }

        private void AddProduct()
        {
            if (string.IsNullOrEmpty(txtBuscar.Text.TrimStart().TrimEnd()))
            {
                this.Alert("Indique el producto.");

                txtBuscar.Clear();
                txtBuscar.Focus();

                return;
            }

            string aux = txtBuscar.Text.TrimStart().TrimEnd().Split('|')[0].Trim();

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
                    posb.ProductForAction product = this.GeCurrentSale();

                    if (product != null)
                    {
                        product.Amount = product.Amount + amount;

                        product.Price = (decimal)product.Amount * product.Unitary;
                    }
                    else
                    {
                        string stringForPrice = aux.Split('$')[1].Trim();
                        string productName = aux.Split('$')[0].Trim();

                        if (stringForPrice.Contains('/'))
                        {
                            productName += "  / " + stringForPrice.Split('/')[1].Trim();

                            stringForPrice = stringForPrice.Split('/')[0].Trim();
                        }

                        posb.ProductForAction venta = new posb.ProductForAction
                        {
                            Id = this.IdPM,
                            Location = this.Entity.GetLocationByName(),
                            IdCompany = this.Entity.GetIdCompany(),
                            Name = productName,
                            Amount = amount,
                            Unitary = decimal.Parse(stringForPrice),
                            Code = this.IdPM.ToString().PadLeft(5, '0'),
                            Freight = new posb.PM { Id = this.IdPM }.RequireFreight()
                        };

                        venta.Price = (decimal)venta.Amount * venta.Unitary;

                        this.Products.Add(venta);
                    }

                    this.SetGrid();

                    this.CleanControls();

                    decimal pago = 0;
                    decimal.TryParse(this.txtPago.Text, out pago);

                    if (decimal.Parse(this.txtACuenta.Text) <= pago)
                        this.txtCambio.Text = (pago - decimal.Parse(this.txtACuenta.Text)).ToString();
                    else
                        this.txtPago.Text = "0.00";
                }
            }
        }

        private void SetGrid(bool Revert = true)
        {
            this.gvList.AutoGenerateColumns = false;
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

            double amount = Amount.HasValue ? Amount.Value : this.GetAmount(),
                   stock = this.Entity.GetStock(true);

            if (!Amount.HasValue)
            {
                posb.ProductForAction product = this.GeCurrentSale();

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
            {
                if (this.AppSet<bool>("CheckStock"))
                {
                    if (amount > stock)
                    {
                        if (this.Confirm("El producto [" + this.Entity.Name.Split('$')[0] + "] no cuenta con stock suficiente.\r\n" +
                                         "Cantidad solicitada:" + amount.ToString() + "\r\n" +
                                         "Stock disponible: " + stock.ToString() + "\r\n" +
                                         "¿Deseas cancelar la agregación del producto?"))
                        {
                            txtCantidad.Text = "1";
                            txtCantidad.Focus();

                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                        return true;
                }
                else
                {
                    return true;
                }
            }
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
        /// Obtiene el producto en caso de que ya exista en la venta actual.
        /// </summary>
        /// <returns>Producto de venta.</returns>
        private posb.ProductForAction GeCurrentSale()
        {
            return Products.Find(p => p.Id.Equals(this.IdPM));
        }

        private void GetTotalSales()
        {
            this.txtTotal.Text = String.Format("{0:0.00}", this.Products.Sum(item => item.Price));

            this.txtACuenta.Text = this.txtTotal.Text;

            lblTotalLetter.Text = new Numalet().Convert(txtTotal.Text);
        }

        private void LoadData(int? Id)
        {
            using (posb.Sale Entity = new posb.Sale())
            {
                Entity.Get(Id);

                this.txtCantidad.Clear();

                this.cmbClient.SelectedValue = Entity.IdClient;
                this.txtTotal.Text = String.Format("{0:0.00}", Entity.Total);
                this.txtRef.Text = Entity.Reference;

                this.toolStripComboBoxClient.SelectedText = Entity.PaymentType.Trim();

                this.CreatedDate = Entity.CreatedDate;

                this.lblRef.Visible = true;
                this.txtRef.Visible = true;

                switch (Entity.PaymentType.Trim())
                {
                    case "Cheque":

                        this.toolStripComboBoxClient.SelectedIndex = 0;

                        break;

                    case "Efectivo":

                        this.toolStripComboBoxClient.SelectedIndex = 1;

                        this.lblRef.Visible = false;
                        this.txtRef.Visible = false;

                        break;

                    case "Tarjeta de crédito":

                        this.toolStripComboBoxClient.SelectedIndex = 2;

                        break;

                    case "Tarjeta de debito":

                        this.toolStripComboBoxClient.SelectedIndex = 3;

                        break;

                    default:

                        this.toolStripComboBoxClient.SelectedIndex = 1;

                        break;
                }

                this.toolStripComboBoxClient.SelectedText = Entity.PaymentType.Trim();

                foreach (var ele in Entity.Products)
                {
                    ele.Code = ele.Code.PadLeft(5, '0');
                }

                this.Products = Entity.Products;

                if (!this.Cancellation)
                {
                    this.Disable();

                    this.btnCancelar.Text = "Cerrar";
                    this.btnCancelar.Location = new Point(855, 557);

                    this.ActiveControl = this.btnCancelar;

                    this.btnCobrar.Text = "Ticket (F12)";
                    this.btnCobrar.Width = 150;
                    this.btnCobrar.Location = new Point(1005, 557);
                }
                else
                {
                    this.IdSale = null;

                    //this.txtPago.Text = "0.00";
                    //this.txtCambio.Text = "0.00";
                    this.txtCantidad.Text = "1";

                    this.ActiveControl = this.txtBuscar;

                    foreach (var product in this.Products)
                    {
                        product.Id = int.Parse(product.Code);
                    }
                }

                this.SetGrid(false);

                this.txtACuenta.Text = String.Format("{0:0.00}", Entity.Amount);
                this.txtPago.Text = String.Format("{0:0.00}", Entity.Cash);
                this.txtCambio.Text = String.Format("{0:0.00}", Entity.Change);
            }
        }

        #endregion
    }
}