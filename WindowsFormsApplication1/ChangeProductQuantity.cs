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
    public partial class ChangeProductQuantity : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, int Id, Double Amount, String ErrorMessage);

        public event Communication Result;

        private int? Id = null;

        private double? Amount = null;

        private string NameProduct = null;

        #endregion

        #region Builder

        public ChangeProductQuantity(int? Id = null, double? Amount = null, string NameProduct = null)
        {
            InitializeComponent();

            this.Id = Id;
            this.Amount = Amount;
            this.NameProduct = Name;

            this.Text = "Producto: " + this.Name;
        }

        #endregion

        #region Events

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PMEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtAmount;

            this.txtAmount.Text = this.Amount.ToString();
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
                double total = double.Parse(txtAmount.Text);

                this.Result(true, this.Id.Value, total, string.Empty);

                this.Close();
            }
            else
            {
                this.Alert("Debe indicar la cantidad del producto [" + this.NameProduct + "].");
            }
        }

        #endregion
    }
}
