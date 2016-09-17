using System;
using System.Windows.Forms;
using posb = PosBusiness;
using UtilitiesForm.Extensions;

namespace WindowsFormsApplication1
{
    public partial class Calc : FormBase
    {
        #region Members
        #endregion

        #region Builder

        public Calc()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void MeasureEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtBox;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                double caja = double.Parse(this.txtBox.Text),
                       ganancia = double.Parse(this.txtNGanancia.Text),
                       cantidad = double.Parse(this.txtCantidad.Text);

                double gananciaTotal = caja * ganancia;


                double precioUnidad = gananciaTotal / cantidad;

                this.txtTotal.Text = precioUnidad.ToString();

                this.button1.Focus();
            }
            catch
            {
                this.txtBox.Focus();
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtBox.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtNGanancia.Text = "2";
            this.txtTotal.Text = string.Empty;

            this.txtBox.Focus();
        }

        #region Methods
        #endregion
    }
}
