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
using BarcodeLib;

namespace WindowsFormsApplication1
{
    public partial class Budgetary : FormBase
    {
        #region Properties

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
                return double.Parse(gvList[3, this.SelectRowIndex].Value.ToString());
            }
        }

        private decimal EntityPrice
        {
            get
            {
                return decimal.Parse(gvList[4, this.SelectRowIndex].Value.ToString());
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

        private List<posb.ProductForAction> lProduct { get; set; }

        #endregion

        #region Builder

        public Budgetary()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.lProduct.Count > 0)
            {
                if (this.Confirm("¿Realmente deseas quitar el producto [" + this.EntityName + "]?"))
                {
                    try
                    {
                        this.lProduct.RemoveAll(p => p.Id.Equals(this.EntityId));

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
            if (this.lProduct.Count > 0)
            {
                if (this.Confirm("¿Realmente deseas cancelar la cotización?"))
                    this.CleanControls(true);
            }
            else
                this.CleanControls();

            this.SetAutoComplete();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.lProduct.Count > 0)
            {
                if (this.Confirm("¿Realmente deseas salir del módulo de cotizaciones?"))
                    this.Close();
            }
            else
                this.Close();
        }

        private void Sale_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtBuscar;

            this.lProduct = new List<posb.ProductForAction>();

            this.Entity = new posb.PM();

            this.SetAutoComplete();

            this.gvList.Columns["Id"].Visible = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.AddProduct();

            this.SetAutoComplete();
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
            if (this.lProduct.Count > 0)
            {
                if (this.Confirm("¿Deseas realizar la cotización?"))
                {
                    using (posb.Budgetary budgetary = new posb.Budgetary())
                    {
                        if (budgetary.Charge(this.lProduct, this.txtCliente.Text))
                        {
                            this.Print(budgetary.Id.Value, this.lProduct, lblTotalLetter.Text, txtCliente.Text);

                            this.CleanControls(true);
                        }
                        else
                        {
                            this.Alert("Ocurrió un error al guardar la cotización.\r\nDescripción: " + budgetary.ErrorMessage, eForm.TypeError.Error);

                            this.CleanControls();
                        }
                    }
                }
            }
            else
            {
                this.Alert("No tiene productos seleccionados.");

                this.CleanControls();
            }

            this.SetAutoComplete();
        }

        private void Result(bool IsCorrect, int Id, Double Amount, String ErrorMessage)
        {
            this.IdPM = Id;

            posb.ProductForAction product = this.GeCurrentSale();

            product.Amount = Amount;

            product.Price = (decimal)product.Amount * product.Unitary;

            this.SetGrid();
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
            if (this.lProduct.Count > 0)
            {
                ChangeProductQuantity QuantityEdit = new ChangeProductQuantity(this.EntityId, this.EntityAmount, this.EntityName);

                QuantityEdit.Result += new ChangeProductQuantity.Communication(Result);

                QuantityEdit.ShowDialog();

                this.CleanControls();
            }
            else
            {
                this.Alert("No tiene productos seleccionados.");

                this.CleanControls();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.lProduct.Count > 0)
            {
                ChangeProductPrice PriceEdit = new ChangeProductPrice(this.EntityId, this.EntityPrice, this.EntityName);

                PriceEdit.Result += new ChangeProductPrice.Communication(Result2);

                PriceEdit.ShowDialog();

                this.CleanControls();
            }
            else
            {
                this.Alert("No tiene productos seleccionados.");

                this.CleanControls();
            }
        }

        #endregion

        #region Methods

        private void CleanControls(bool All = false)
        {
            this.txtBuscar.Text = string.Empty;
            this.txtCantidad.Text = "1";

            if (All)
            {
                this.txtTotal.Text = "0.00";
                this.lblTotalLetter.Text = "Cero Pesos 00/100 M.N.";
                this.txtCliente.Text = string.Empty;

                this.lProduct.Clear();
                this.SetGrid();
            }

            this.txtBuscar.Focus();
        }

        private void ConfigureGridView()
        {
            this.gvList.AutoGenerateColumns = false;

            this.gvList.AllowUserToResizeColumns = false;

            this.gvList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void SetAutoComplete()
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
                double amount = this.GetAmount();
                posb.ProductForAction product = this.GeCurrentSale();
                string code = string.Empty;

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
                        Name = productName,
                        Amount = amount,
                        Unitary = decimal.Parse(stringForPrice),
                        Code = this.IdPM.ToString().PadLeft(5, '0')
                    };

                    venta.Price = (decimal)venta.Amount * venta.Unitary;

                    this.lProduct.Add(venta);
                }

                this.SetGrid();

                txtBuscar.Text = string.Empty;

                this.CleanControls();
            }
        }

        private void SetGrid()
        {
            this.gvList.DataSource = new List<posb.ProductForAction>();
            this.gvList.DataSource = this.lProduct;

            lblTotal.Text = this.gvList.RowCount.ToString();

            this.GetTotalSales();
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
            return lProduct.Find(p => p.Id.Equals(this.IdPM));
        }

        private void GetTotalSales()
        {
            txtTotal.Text = String.Format("{0:0.00}", this.lProduct.Sum(item => item.Price));

            lblTotalLetter.Text = new Numalet().Convert(txtTotal.Text);
        }

        private int StartXPosition(object Amount, int StartPosition, int Step = 6)
        {
            int len = String.Format("{0:0.00}", Amount).Length;
            int valueXAmount = StartPosition - (len * Step);

            return valueXAmount;
        }

        /// <summary>
        /// Imprime el ticket de venta.
        /// </summary>
        /// <param name="Id">Identificadot de la venta.</param>
        /// <param name="List">Productos vendidos.</param>
        private void Print(int Id, List<posb.ProductForAction> List, string ChashLetter, string Client)
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

                double total = (double)List.Sum(item => item.Price),
                       iva = total * 0.16,
                       subTotal = total - iva;

                int numberOfProducts = List.Count;

                e1.Graphics.DrawString(this.AppSet<string>("ShopName").Replace("°", " "), f14, brush, 10, 20);
                e1.Graphics.DrawString(this.AppSet<string>("TicketAddress1"), f09, brush, 10, 45);
                e1.Graphics.DrawString(this.AppSet<string>("TicketAddress2"), f09, brush, 10, 60);
                e1.Graphics.DrawString("Tel. " + this.AppSet<string>("TicketPhoneNumber"), f09, brush, 10, 75);

                e1.Graphics.DrawString("Folio: " + Id.ToString().PadLeft(8, '0') + "            " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), f10, new SolidBrush(Color.Black), 10, 95);

                e1.Graphics.DrawString("==================================", f10, brush, 10, 105);

                e1.Graphics.DrawString("Nombre - Propiedades - Marca", f09, brush, 10, 115);
                e1.Graphics.DrawString("Código", f09, brush, 10, 125);
                e1.Graphics.DrawString("Cantidad", f09, brush, 80, 125);
                e1.Graphics.DrawString("Unitario", f09, brush, 150, 125);
                e1.Graphics.DrawString("Precio", f09, brush, 230, 125);

                e1.Graphics.DrawString("==================================", f10, brush, 10, 133);

                int i = 0;

                foreach (posb.ProductForAction pfa in List)
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
                e1.Graphics.DrawString("IVA:", new Font("Times New Roman", 10), brush, 150, newX + 40);

                var valueXTotal = this.StartXPosition(total, 260);
                e1.Graphics.DrawString(String.Format("{0:0.00}", total), f10, brush, valueXTotal, newX + 20);

                var valueXIva = this.StartXPosition(iva, 260);
                e1.Graphics.DrawString(String.Format("{0:0.00}", iva), f10, brush, valueXIva, newX + 40);

                e1.Graphics.DrawString(ChashLetter, f08, brush, 10, newX + 70);
                e1.Graphics.DrawString("# Arts. cotizados " + numberOfProducts.ToString(), f08, brush, 10, newX + 85);

                e1.Graphics.DrawString("==================================", f10, brush, 10, newX + 100);

                //Impresion Codigo de barras

                //codigo del pais 750 
                //letra L 12 y letra D 04 = 1204
                //5 digitos del identificador del PM
                //Digito de control control
                string BarcodeString = "7501001" + Id.ToString().PadLeft(5, '0');

                BarcodeString = BarcodeString + this.GetControlDigit(BarcodeString);

                BarcodeLib.Barcode code = new Barcode();
                code.IncludeLabel = false;

                e1.Graphics.DrawImage(code.Encode(BarcodeLib.TYPE.EAN13, BarcodeString, Color.Black, Color.White, 150, 40), 65, newX + 120, 150, 40);

                e1.Graphics.DrawString("Sucursal: " + this.AppSet<string>("branchOffice"), f10, brush, 10, newX + 170);
                e1.Graphics.DrawString("Caja: " + this.AppSet<string>("CashRegister"), f10, brush, 170, newX + 170);

                if (!string.IsNullOrEmpty(Client))
                {
                    e1.Graphics.DrawString("Cliente: " + Client, f10, brush, 10, newX + 185);

                    e1.Graphics.DrawString("¡Gracias por su preferencia!", f11, brush, 50, newX + 200);
                    e1.Graphics.DrawString("MaxShop V1.0.0 - Punto de venta", f04, brush, 95, newX + 217);
                }
                else
                {
                    e1.Graphics.DrawString("¡Gracias por su preferencia!", f11, brush, 50, newX + 185);
                    e1.Graphics.DrawString("MaxShop V1.0.0 - Punto de venta", f04, brush, 95, newX + 202);
                }
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

        #endregion

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
                    this.SetAutoComplete();
                }
                else if ((txtBuscar.Text.Length > 6 && double.TryParse(txtBuscar.Text, out code)) || double.TryParse(txtBuscar.Text.Substring(1, txtBuscar.Text.Length - 1), out code))
                {
                    List<posb.PM> pms = this.Entity.List(null, true, txtBuscar.Text);

                    if (pms.Count.Equals(1))
                    {
                        txtBuscar.Text = pms[0].Aux;
                        txtCantidad.Text = "1";
                    }

                    this.AddProduct();
                    this.SetAutoComplete();
                }
            }
        }

        private int GetControlDigit(string BarCode)
        {
            int val1 = 0,
                val2 = 0,
                mult = 0;

            for (int i = 0; i < BarCode.Length; i++)
            {
                string value = BarCode[i].ToString();
                int intValue = int.Parse(value);

                if ((i % 2).Equals(0))
                {
                    val2 += intValue;
                }
                else
                {
                    val1 += intValue;
                }
            }

            val1 *= 3;

            val1 += val2;

            if (val1 < 100)
                mult = 100;
            else if (val1 < 200)
                mult = 200;
            else if (val1 < 300)
                mult = 300;

            val1 = mult - val1;

            string preValue = val1.ToString();

            preValue = preValue.Substring(preValue.Length - 1, 1);

            val1 = int.Parse(preValue);

            return val1;
        }
    }
}