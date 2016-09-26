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

        private posb.PM Entity { get; set; }

        private List<posb.ProductForAction> Products { get; set; }

        public static int Instances = 0;

        private bool ItsFirst = false;

        #endregion

        #region Builder

        public Sale(int? IdSale = null)
        {
            this.IdSale = IdSale;

            InitializeComponent();

            Instances++;
        }

        #endregion

        #region Events

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
                if (!string.IsNullOrEmpty(txtPago.Text) && double.Parse(txtPago.Text) > 0)
                {
                    if (double.Parse(this.txtPago.Text) - double.Parse(txtTotal.Text) >= 0)
                    {
                        this.Charge();
                    }
                    else
                    {
                        this.Alert("El monto pagado no puede ser menor al monto total.");

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
                    this.CleanControls();

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

            txtPago.LostFocus += new EventHandler(txtPago_LostFocus);

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

            txtCambio.Text = (pago - decimal.Parse(txtTotal.Text)).ToString();
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

            this.txtCantidad.Enabled = Enabled;

            this.btnOk.Enabled = Enabled;
            this.cmbClient.Enabled = Enabled;
            this.txtTotal.Enabled = Enabled;
            this.txtPago.Enabled = Enabled;
            this.txtCambio.Enabled = Enabled;
            this.toolStripComboBoxClient.Enabled = Enabled;
            this.gvList.Enabled = Enabled;

            this.button4.Visible = Enabled;
            this.button1.Visible = Enabled;
            this.button3.Visible = Enabled;
            this.button2.Visible = Enabled;
            this.btnBorra.Visible = Enabled;
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
                    this.Print(this.IdSale.Value, this.Products, double.Parse(txtPago.Text), lblTotalLetter.Text, this.cmbClient.Text, this.toolStripComboBoxClient.Text, this.CreatedDate.Value.ToString("dd/MM/yyyy hh:mm:ss"));
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

            if (this.Products.Count > 0)
            {
                if (!string.IsNullOrEmpty(txtPago.Text) && double.Parse(txtPago.Text) > 0)
                {
                    //if (double.Parse(this.txtPago.Text) - double.Parse(txtTotal.Text) >= 0)
                    //{
                        if (this.Confirm("¿Deseas realizar la venta?"))
                        {
                            using (posb.Sale sale = new posb.Sale())
                            {
                                bool oneTicket = this.AppSet<bool>("OneTicket");
                                bool printTicket = this.Confirm("¿Deseas imprimir el ticket?");

                                var ids = this.Products.Select(x => x.IdCompany).Distinct().ToList();
                                var idSale = 0;

                                decimal pagoParcial = decimal.Parse(txtPago.Text);
                                var print = (!oneTicket && printTicket);

                                for (var i = 0; i < ids.Count; i++)
                                {
                                    var id = ids[i];

                                    var products = this.Products.FindAll(p => p.IdCompany.Equals(id));
                                    decimal precioProductosPorNegocio = products.Sum(p => p.Price);

                                    pagoParcial -= precioProductosPorNegocio;

                                    double pago = (double)precioProductosPorNegocio;

                                    if (i.Equals(ids.Count - 1))
                                    {
                                        pago = (double)(pagoParcial + precioProductosPorNegocio);
                                    }

                                    idSale = this.Charge2(products,
                                                          int.Parse(this.cmbClient.SelectedValue.ToString()),
                                                          this.toolStripComboBoxClient.Text,
                                                          pago,
                                                          false,
                                                          id,
                                                          Print: (!oneTicket && printTicket));
                                }

                                if (oneTicket)
                                {
                                    this.Print(idSale,
                                               this.Products,
                                               double.Parse(txtPago.Text),
                                               lblTotalLetter.Text,
                                               this.cmbClient.Text,
                                               this.toolStripComboBoxClient.Text,
                                               IdCompany: null,
                                               Principal: true,
                                               ExtraSale: this.Products.Count - 1);
                                }
                            }
                        }
                    //}
                    //else                                                                                           
                    //{
                    //    this.Alert("El monto pagado no puede ser menor al monto total.");

                    //    this.txtPago.Text = "0.00";
                    //    this.txtCambio.Text = "0.00";

                    //    this.txtPago.Focus();
                    //}
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
                this.Alert("No tiene productos seleccionados.");

                this.CleanControls();
            }

            this.SetAutoCompleteProducts();
            this.SetAutoCompleteClient();
        }

        private int Charge2(List<ProductForAction> Products, int IdClient, string PaymentType, double Payment, bool Freight = false, int? IdCompany = null, bool Print = true)
        {
            using (posb.Sale sale = new posb.Sale())
            {
                if (sale.Charge(Products, IdClient, PaymentType, Payment, Freight))
                {
                    if (Print)
                    {
                        double total = (double)Products.Sum(item => item.Price);

                        string ltr = new Numalet().Convert(total.ToString());

                        this.Print(sale.Id.Value, Products, Payment, ltr, this.cmbClient.Text, PaymentType, IdCompany: IdCompany, Principal: null);
                    }

                    this.Disable();
                    this.btnCancelar.Enabled = false;
                }
                else
                {
                    this.Alert("Ocurrió un error al guardar la venta.\r\nDescripción: " + sale.ErrorMessage, eForm.TypeError.Error);

                    this.CleanControls();
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
            this.txtBuscar.AutoCompleteMode = AutoCompleteMode.None;
            this.txtBuscar.AutoCompleteSource = AutoCompleteSource.None;

            List<posb.PM> pms = this.Entity.List(IsItForSale: true);

            AutoCompleteStringCollection data = new AutoCompleteStringCollection();

            List<string> lproducts = new List<string>();

            foreach (posb.PM pm in pms)
            {
                data.Add(pm.Aux);

                lproducts.Add(pm.Aux);

                //if (!string.IsNullOrEmpty(pm.Alias))
                //    data.Add(pm.Alias);
            }

            this.txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtBuscar.AutoCompleteCustomSource = data;

            return;

            AutoCompleteTextBox auct = new AutoCompleteTextBox();

            auct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.txtBuscar.Location = new System.Drawing.Point(238, 47);
            auct.MaxLength = 100;
            auct.Size = new System.Drawing.Size(847, 29);
            auct.TabIndex = 0;
            //this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            //this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            //this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);

            auct.Values = lproducts.ToArray();

            this.Controls.Add(auct);


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
            txtTotal.Text = String.Format("{0:0.00}", this.Products.Sum(item => item.Price));

            lblTotalLetter.Text = new Numalet().Convert(txtTotal.Text);
        }

        /// <summary>
        /// Imprime el ticket de venta.
        /// </summary>
        /// <param name="Id">Identificadot de la venta.</param>
        /// <param name="List">Productos vendidos.</param>
        private void Print(int Id, List<posb.ProductForAction> List, double Cash, string ChashLetter, string Client, string PaymentType, string Date = "", int? IdCompany = null, bool? Principal = null, int ExtraSale = 0)
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

                string tipoPago = "Pago hecho en una sola exhibición";

                double total = (double)List.Sum(item => item.Price),
                       cambio = Cash - total,
                       porPagar = 0,
                       iva = total * 0.16,
                       subTotal = total - iva;

                int numberOfProducts = List.Count;
                //double numberOfProducts = (double)List.Sum(item => item.Amount);

                using (posb.Company company = new Company
                {
                    Id = IdCompany
                })
                {
                    var ticket = company.GetTicket(Principal).First();

                    e1.Graphics.DrawString(ticket.ShopName.Replace("°", " "), f14, brush, 10, 20);
                    e1.Graphics.DrawString(ticket.TicketAddress1, f09, brush, 10, 45);
                    e1.Graphics.DrawString(ticket.TicketAddress2, f09, brush, 10, 60);
                    e1.Graphics.DrawString("Tel. " + ticket.TicketPhoneNumber, f09, brush, 10, 75);
                }

                var extra = "  ";

                if (ExtraSale > 0)
                    extra = "+" + ExtraSale.ToString();

                e1.Graphics.DrawString("Folio: " + Id.ToString().PadLeft(8, '0') + extra + "          " + (string.IsNullOrEmpty(Date) ? DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") : Date), f10, new SolidBrush(Color.Black), 10, 95);

                e1.Graphics.DrawString("==================================", f10, brush, 10, 105);

                e1.Graphics.DrawString("Nombre - Propiedades - Marca", f09, brush, 10, 115);
                e1.Graphics.DrawString("Código", f09, brush, 10, 125);
                e1.Graphics.DrawString("Cantidad", f09, brush, 80, 125);
                e1.Graphics.DrawString("Unitario", f09, brush, 150, 125);
                e1.Graphics.DrawString("Precio", f09, brush, 230, 125);

                e1.Graphics.DrawString("==================================", f10, brush, 10, 133);

                int i = 0;

                List<posb.ProductForAction> lPreProduct = new List<posb.ProductForAction>();

                for (int j = List.Count - 1; j >= 0; j--)
                {
                    lPreProduct.Add(List[j]);
                }

                foreach (posb.ProductForAction pfa in lPreProduct)
                {
                    string pp = pfa.Name.Replace(" / Marca:", "-");

                    if (pp.Length > 48)
                    {
                        pp = pp.Substring(0, 45) + "...";
                    }

                    e1.Graphics.DrawString(pp, f09, brush, 9, 145 + (i * 32));

                    e1.Graphics.DrawString(pfa.Code, f09, brush, 10, 157 + (i * 32));

                    var valueXAmount = this.StartXPosition(pfa.Amount, 120);
                    e1.Graphics.DrawString(String.Format("{0:0.00}", pfa.Amount), f09, brush, valueXAmount, 157 + (i * 32));

                    var valueXUnitary = this.StartXPosition(pfa.Unitary, 190);
                    e1.Graphics.DrawString(String.Format("{0:0.00}", pfa.Unitary), f09, brush, valueXUnitary, 157 + (i * 32));

                    var valueXPrice = this.StartXPosition(pfa.Price, 260);
                    e1.Graphics.DrawString(String.Format("{0:0.00}", pfa.Price), f10, brush, valueXPrice, 157 + (i * 32));

                    i++;
                }

                int newX = (i * 32) + 145;

                e1.Graphics.DrawString("==================================", f10, brush, 10, newX);

                e1.Graphics.DrawString("Total:", new Font("Times New Roman", 10), brush, 150, newX + 20);
                e1.Graphics.DrawString("Efectivo:", new Font("Times New Roman", 10), brush, 150, newX + 40);
                e1.Graphics.DrawString("Cambio:", new Font("Times New Roman", 10), brush, 150, newX + 60);

                if (cambio < 0)
                {
                    e1.Graphics.DrawString("Por pagar:", new Font("Times New Roman", 10), brush, 150, newX + 80);
                }

                e1.Graphics.DrawString("IVA:", new Font("Times New Roman", 10), brush, 150, newX + 105);

                var valueXTotal = this.StartXPosition(total, 260);
                e1.Graphics.DrawString(String.Format("{0:0.00}", total), f10, brush, valueXTotal, newX + 20);

                var valueXCash = this.StartXPosition(Cash, 260);
                e1.Graphics.DrawString(String.Format("{0:0.00}", Cash), f10, brush, valueXCash, newX + 40);

                if (cambio < 0)
                {
                    porPagar = cambio * -1;

                    var valueXPorPagar = this.StartXPosition(porPagar, 260);
                    e1.Graphics.DrawString(String.Format("{0:0.00}", porPagar), f10, brush, valueXPorPagar, newX + 80);

                    cambio = 0;

                    tipoPago = "Pago realizado en parcialidades";
                }

                var valueXCambio = this.StartXPosition(cambio, 260);
                e1.Graphics.DrawString(String.Format("{0:0.00}", cambio), f10, brush, valueXCambio, newX + 60);

                var valueXIva = this.StartXPosition(iva, 260);
                e1.Graphics.DrawString(String.Format("{0:0.00}", iva), f10, brush, valueXIva, newX + 105);

                e1.Graphics.DrawString(ChashLetter, f08, brush, 10, newX + 120);
                e1.Graphics.DrawString("# Arts. vendidos " + numberOfProducts.ToString(), f08, brush, 10, newX + 135);

                if (!string.IsNullOrEmpty(Date))
                {
                    e1.Graphics.DrawString("Reimpresión", f08, brush, 150, newX + 135);
                }

                e1.Graphics.DrawString("==================================", f10, brush, 10, newX + 150);
                e1.Graphics.DrawString(tipoPago, f10, brush, 10, newX + 170);
                e1.Graphics.DrawString("Tipo de pago: " + PaymentType, f10, brush, 10, newX + 185);
                e1.Graphics.DrawString("Sucursal: " + this.AppSet<string>("branchOffice"), f10, brush, 10, newX + 200);
                e1.Graphics.DrawString("Caja: " + this.AppSet<string>("CashRegister"), f10, brush, 170, newX + 200);

                if (!string.IsNullOrEmpty(Client))
                {
                    e1.Graphics.DrawString("Cliente: " + Client, f10, brush, 10, newX + 215);

                    e1.Graphics.DrawString("¡Gracias por su preferencia!", f11, brush, 50, newX + 235);
                    e1.Graphics.DrawString("MaxShop V1.0.0 - Punto de venta", f04, brush, 95, newX + 255);
                }
                else
                {
                    e1.Graphics.DrawString("¡Gracias por su preferencia!", f11, brush, 50, newX + 220);
                    e1.Graphics.DrawString("MaxShop V1.0.0 - Punto de venta", f04, brush, 95, newX + 240);
                }
            };

            try
            {
                p.PrinterSettings.PrinterName = this.AppSet<string>("Printer");

                p.Print();
            }
            catch (Exception ex)
            {
                this.Alert("Ocurrió un error al intentar imprimir el ticket. Descripcion: " + ex.Message, eForm.TypeError.Error);
            }
        }

        private int StartXPosition(object Amount, int StartPosition, int Step = 6)
        {
            int len = String.Format("{0:0.00}", Amount).Length;
            int valueXAmount = StartPosition - (len * Step);

            return valueXAmount;
        }

        private void LoadData(int? Id)
        {
            using (posb.Sale Entity = new posb.Sale())
            {
                Entity.Get(Id);

                this.Disable();
                this.txtCantidad.Clear();

                this.btnCancelar.Text = "Cerrar";
                this.btnCancelar.Location = new Point(855, 557);

                this.ActiveControl = btnCancelar;

                this.btnCobrar.Text = "Ticket (F12)";
                this.btnCobrar.Width = 150;
                this.btnCobrar.Location = new Point(1005, 557);

                this.cmbClient.SelectedValue = Entity.IdClient;
                this.txtTotal.Text = String.Format("{0:0.00}", Entity.Total);
                this.txtPago.Text = String.Format("{0:0.00}", Entity.Payment);
                this.txtCambio.Text = String.Format("{0:0.00}", (Entity.Payment - Entity.Total));

                this.toolStripComboBoxClient.SelectedText = Entity.PaymentType.Trim();

                this.CreatedDate = Entity.CreatedDate;

                switch (Entity.PaymentType.Trim())
                {
                    case "Cheque":

                        this.toolStripComboBoxClient.SelectedIndex = 0;

                        break;

                    case "Efectivo":

                        this.toolStripComboBoxClient.SelectedIndex = 1;

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

                this.SetGrid(false);
            }
        }

        #endregion

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void GetClients()
        {
            using (posb.Client client = new posb.Client())
            {
                this.cmbClient.Fill(client.List(), AddFirstOption: false);

                this.cmbClient.SelectedValue = this.AppSet<int>("DefaultClientId");
            }

            //this.cmbClient.SelectedIndex = 0;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            this.ShowClient();
        }

        private void ShowClient()
        {
            ClientEdit ClientEdit = new ClientEdit();

            ClientEdit.Result += new ClientEdit.Communication(ResultEmployee);

            ClientEdit.ShowDialog();
        }

        private void ResultEmployee(bool IsCorrect, String ErrorMessage, int Id)
        {
            this.GetClients();

            this.cmbClient.SelectedValue = Id;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class AutoCompleteTextBox : TextBox
    {
        private ListBox _listBox;
        private bool _isAdded;
        private String[] _values;
        private String _formerValue = String.Empty;

        public AutoCompleteTextBox()
        {
            InitializeComponent();
            ResetListBox();
        }

        private void InitializeComponent()
        {
            _listBox = new ListBox();

           

            KeyDown += this_KeyDown;
            KeyUp += this_KeyUp;
        }

        private void ShowListBox()
        {
            if (!_isAdded)
            {
                Parent.Controls.Add(_listBox);
                _listBox.Left = Left;
                _listBox.Top = Top + Height;
                _isAdded = true;
            }
            _listBox.Visible = true;
            _listBox.BringToFront();
        }

        private void ResetListBox()
        {
            _listBox.Visible = false;
        }

        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateListBox();
        }

        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    {
                        if (_listBox.Visible)
                        {
                            InsertWord((String)_listBox.SelectedItem);
                            ResetListBox();
                            _formerValue = Text;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                            _listBox.SelectedIndex++;

                        break;
                    }
                case Keys.Up:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex > 0))
                            _listBox.SelectedIndex--;

                        break;
                    }
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Tab:
                    return true;
                default:
                    return base.IsInputKey(keyData);
            }
        }

        private void UpdateListBox()
        {
            if (Text == _formerValue) 
                return;

            _formerValue = Text;
            String word = GetWord();

            if (_values != null && word.Length > 0)
            {
                String[] matches = Array.FindAll(_values,
                                                 x => (x.StartsWith(word, StringComparison.OrdinalIgnoreCase) && !SelectedValues.Contains(x)));
                if (matches.Length > 0)
                {
                    ShowListBox();
                    _listBox.Items.Clear();
                    Array.ForEach(matches, x => _listBox.Items.Add(x));
                    _listBox.SelectedIndex = 0;
                    _listBox.Height = 0;
                    //_listBox.Width = 0;
                    Focus();
                    using (Graphics graphics = _listBox.CreateGraphics())
                    {
                        for (int i = 0; i < _listBox.Items.Count; i++)
                        {
                            _listBox.Height += _listBox.GetItemHeight(i);
                            // it item width is larger than the current one
                            // set it to the new max item width
                            // GetItemRectangle does not work for me
                            // we add a little extra space by using '_'
                            int itemWidth = (int)graphics.MeasureString(((String)_listBox.Items[i]) + "_", _listBox.Font).Width;
                            //_listBox.Width = (_listBox.Width < itemWidth) ? itemWidth : _listBox.Width;
                        }
                    }
                }
                else
                {
                    ResetListBox();
                }
            }
            else
            {
                ResetListBox();
            }

            _listBox.Width = this.Width;
        }

        private String GetWord()
        {
            String text = Text;
            int pos = SelectionStart;

            int posStart = text.LastIndexOf(' ', (pos < 1) ? 0 : pos - 1);
            posStart = (posStart == -1) ? 0 : posStart + 1;
            int posEnd = text.IndexOf(' ', pos);
            posEnd = (posEnd == -1) ? text.Length : posEnd;

            int length = ((posEnd - posStart) < 0) ? 0 : posEnd - posStart;

            return text.Substring(posStart, length);
        }

        private void InsertWord(String newTag)
        {
            String text = Text;
            int pos = SelectionStart;

            int posStart = text.LastIndexOf(' ', (pos < 1) ? 0 : pos - 1);
            posStart = (posStart == -1) ? 0 : posStart + 1;
            int posEnd = text.IndexOf(' ', pos);

            String firstPart = text.Substring(0, posStart) + newTag;
            String updatedText = firstPart + ((posEnd == -1) ? "" : text.Substring(posEnd, text.Length - posEnd));


            Text = updatedText;
            SelectionStart = firstPart.Length;
        }

        public String[] Values
        {
            get
            {
                return _values;
            }
            set
            {
                _values = value;
            }
        }

        public List<String> SelectedValues
        {
            get
            {
                String[] result = Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return new List<String>(result);
            }
        }

    }
}