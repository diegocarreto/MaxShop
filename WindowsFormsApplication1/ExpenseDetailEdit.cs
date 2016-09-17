using System;
using System.Windows.Forms;
using posb = PosBusiness;
using UtilitiesForm.Extensions;

namespace WindowsFormsApplication1
{
    public partial class ExpenseDetailEdit : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage, int Id);

        public event Communication Result;

        private int? Id = null;

        private int? IdExpense = null;

        #endregion

        #region Builder

        public ExpenseDetailEdit(int? Id = null, int? IdExpense = null)
        {
            InitializeComponent();

            this.Id = Id;
            this.IdExpense = IdExpense;
        }

        #endregion

        #region Events

        private void MeasureEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtName;

            if (this.Id.HasValue)
            {
                this.LoadData(this.Id);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtName.Text))
            {
                if (!string.IsNullOrEmpty(txtAmount.Text))
                {
                    this.Save();
                }
                else
                    this.Alert("Debe indicar el monto del gasto");
            }
            else
            {
                this.Alert("Debe indicar el nombre");
                this.txtName.Focus();
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAmount.Text.Length.Equals(0))
                e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
            else if (txtAmount.Text[txtAmount.Text.Length - 1] == ' ')
                e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
            else
                e.KeyChar = e.KeyChar.ToString().ToLower().ToCharArray()[0];
        }

        #endregion

        #region Methods

        private void LoadData(int? Id)
        {
            using (posb.Expense Entity = new posb.Expense
            {

            })
            {
                Entity.GetDetail(Id);

                this.txtName.Text = Entity.Name;
                this.txtAmount.Text = String.Format("{0:0.00}", Entity.Amount);
                this.dtpDate.Value = Entity.Date.Value;

            }
        }

        private void Save()
        {
            decimal? loanTotal = 0,
                     paymentTotal = 0,
                     currentPayment = decimal.Parse(this.txtAmount.Text);

            using (posb.Expense Entity = new posb.Expense
            {
                Id = this.IdExpense
            })
            {
                Entity.Get();

                loanTotal = Entity.Amount;
                paymentTotal = decimal.Parse(Entity.Aux2) + currentPayment;

                if (currentPayment == 0)
                {
                    this.Alert("El monto del detalle debe ser mayor a cero");

                    this.txtAmount.Clear();
                    this.Focus();

                    return;
                }
                else if (paymentTotal > loanTotal)
                {
                    this.Alert("El monto del detalle supera el monto del gasto total");
                    this.Focus();

                    return;
                }
            }

            using (posb.Expense Entity = new posb.Expense
            {
                Amount = currentPayment,
                Date = this.dtpDate.Value,
                Id = this.Id,
                IdExpense = this.IdExpense,
                Name = this.txtName.Text
            })
            {
                Entity.SaveDetail();

                this.Result(true, "", Entity.Id.Value);

                this.Close();
            }
        }

        #endregion
    }
}
