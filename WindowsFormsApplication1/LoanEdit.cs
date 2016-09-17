using System;
using System.Windows.Forms;
using posb = PosBusiness;
using UtilitiesForm.Extensions;

namespace WindowsFormsApplication1
{
    public partial class LoanEdit : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage, int Id);

        public event Communication Result;

        private int? Id = null;

        private int? IdEmployee = null;

        #endregion

        #region Builder

        public LoanEdit(int? Id = null)
        {
            InitializeComponent();

            this.Id = Id;
        }

        #endregion

        #region Events

        private void MeasureEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.cmbEmployee;

            this.GetEmployees();

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
            if (this.cmbEmployee.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(this.txtAmount.Text))
                {
                    this.Save();
                }
                else
                    this.Alert("Debe indicar el monto del prestamo");
            }
            else
                this.Alert("Debe indicar el empleado");
        }

        #endregion

        #region Methods

        private void GetEmployees()
        {
            using (posb.Employee Employee = new posb.Employee())
            {
                this.cmbEmployee.Fill(Employee.List());
            }
        }

        private void LoadData(int? Id)
        {
            using (posb.Loan Entity = new posb.Loan
            {
                Id = this.Id
            })
            {
                Entity.Get();

                this.IdEmployee = Entity.IdEmployee == null ? 0 : Entity.IdEmployee;

                this.cmbEmployee.SelectedValue = this.IdEmployee;

                this.dtpDate.Value = Entity.Date.Value;

                this.txtAmount.Text = String.Format("{0:0.00}", Entity.Amount);
            }
        }

        private void Save()
        {
            using (posb.Loan Entity = new posb.Loan
            {
                Amount = decimal.Parse(this.txtAmount.Text),
                IdEmployee = int.Parse(this.cmbEmployee.SelectedValue.ToString()),
                Date= dtpDate.Value,
                Id = this.Id
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
