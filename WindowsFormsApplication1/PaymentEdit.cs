using System;
using System.Windows.Forms;
using posb = PosBusiness;
using UtilitiesForm.Extensions;

namespace WindowsFormsApplication1
{
    public partial class PaymentEdit : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage, int Id);

        public event Communication Result;

        private int? Id = null;

        private int? IdLoan = null;

        #endregion

        #region Builder

        public PaymentEdit(int? Id = null, int? IdLoan = null)
        {
            InitializeComponent();

            this.Id = Id;
            this.IdLoan = IdLoan;
        }

        #endregion

        #region Events

        private void MeasureEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtAmount;

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
            if (!string.IsNullOrEmpty(txtAmount.Text))
            {
                this.Save();
            }
            else
                this.Alert("Debe indicar el monto del pago");
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
            using (posb.Payment Entity = new posb.Payment
            {

            })
            {
                Entity.Get(Id);

                this.txtAmount.Text = String.Format("{0:0.00}", Entity.Amount);
                this.dtpDate.Value = Entity.Date.Value;

            }
        }

        private void Save()
        {
            decimal? loanTotal = 0,
                     paymentTotal = 0,
                     currentPayment = decimal.Parse(this.txtAmount.Text);

            using (posb.Loan Entity = new posb.Loan
            {
                Id = this.IdLoan
            })
            {
                Entity.Get();

                loanTotal = Entity.Amount;
                paymentTotal = Entity.PaymentTotal + currentPayment;

                if (currentPayment == 0)
                {
                    this.Alert("El monto del pago debe ser mayor a cero");

                    this.txtAmount.Clear();
                    this.Focus();

                    return;
                }
                else if (paymentTotal > loanTotal)
                {
                    this.Alert("El monto de los pagos supera el monto del prestamo");
                    this.Focus();

                    return;
                }
            }

            using (posb.Payment Entity = new posb.Payment
            {
                Amount = currentPayment,
                Date = this.dtpDate.Value,
                Id = this.Id,
                IdLoan = this.IdLoan
            })
            {
                Entity.Save();

                this.Result(true, "", Entity.Id.Value);

                this.Close();
            }
        }

        #endregion
    }
}
