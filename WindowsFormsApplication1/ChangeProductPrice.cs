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

namespace WindowsFormsApplication1
{
    public partial class ChangeProductPrice : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, int Id, decimal Unitary, String ErrorMessage);

        public event Communication Result;

        private int? Id = null;

        private decimal? Unitary = null;

        private string NameProduct = null;

        #endregion

        #region Builder

        public ChangeProductPrice(int? Id = null, decimal? Price = null, string NameProduct = null)
        {
            InitializeComponent();

            this.Id = Id;
            this.Unitary = Price;
            this.NameProduct = Name;

            this.Text = "Producto: " + this.Name;
        }

        #endregion

        #region Events

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PMEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtAmount;

            this.txtAmount.Text = this.Unitary.ToString();
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

        #endregion

        #region Methods

        private void Save()
        {
            if (!string.IsNullOrEmpty(txtAmount.Text))
            {
                decimal price = decimal.Parse(txtAmount.Text);

                this.Result(true, this.Id.Value, price, string.Empty);

                this.Close();
            }
            else
            {
                this.Alert("Debe indicar el precio del producto [" + this.NameProduct + "].");
            }
        }

        #endregion
    }
}
