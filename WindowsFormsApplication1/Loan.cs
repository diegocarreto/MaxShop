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
    public partial class Loan : FormBase
    {
        #region Properties

        private posb.Loan Entity { get; set; }

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

        private int SelectRowIndex
        {
            get
            {
                return gvList.CurrentRow.Index;
            }
        }

        #endregion

        #region Builder

        public Loan()
        {
            InitializeComponent();

            this.Entity = new posb.Loan();
        }

        #endregion

        #region Events

        private void gvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex.Equals(0))
            {
                this.OpenEdit(this.EntityId);
            }
            else if (e.ColumnIndex.Equals(3))
            {
                this.OpenPayment(this.EntityId);
            }
        }

        private void gvList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            gvList.Cursor = Cursors.Default;
        }

        private void gvList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex.Equals(0) || e.ColumnIndex.Equals(3))
                gvList.Cursor = Cursors.Hand;
            else
                gvList.Cursor = Cursors.Default;
        }

        private void Measure_Load(object sender, EventArgs e)
        {
            this.ConfigureDateTimePicker();

            this.ConfigureGridView();

            this.GetEmployees();

            this.FillGridView();

            this.cmbType.SelectedIndex = 2;
        }

        private void bntFind_Click(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.Confirm("¿Realmente deseas eliminar el prestamo [" + this.EntityName + "]?"))
            {
                this.Entity.Id = this.EntityId;

                if (this.Entity.Delete())
                {
                    this.Entity.Id = null;

                    this.FillGridView();
                }
                else
                    this.Alert("Ocurrió un error al intentar eliminar el prestamo [" + this.EntityName + "]", eForm.TypeError.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.OpenEdit(this.EntityId);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.OpenEdit();
        }

        private void Result(bool IsCorrect, String ErrorMessage, int Id)
        {
            FillGridView();
        }

        private void Measure_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Entity.Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            this.FillGridView();
        }

        #endregion

        #region Methods

        private void ConfigureDateTimePicker()
        {
            dtpDate1.Format = DateTimePickerFormat.Custom;
            dtpDate1.CustomFormat = "dd/MM/yyyy";
            dtpDate1.Value = DateTime.Now.AddDays(-5);

            dtpDate2.Format = DateTimePickerFormat.Custom;
            dtpDate2.CustomFormat = "dd/MM/yyyy";
            dtpDate2.Value = DateTime.Now;
        }

        private void GetEmployees()
        {
            using (posb.Employee Employee = new posb.Employee())
            {
                this.cmbEmployee.Fill(Employee.List());
            }
        }

        private void OpenEdit(int? Id = null)
        {
            LoanEdit LoanEdit = new LoanEdit(Id);

            LoanEdit.Result += new LoanEdit.Communication(Result);

            LoanEdit.ShowDialog();
        }

        private void OpenPayment(int Id)
        {
            Payment payment = new Payment(Id);

            //payment.Result += new LoanEdit.Communication(Result);

            payment.ShowDialog();
        }

        private void ConfigureGridView()
        {
            this.gvList.AutoGenerateColumns = false;

            this.gvList.AllowUserToResizeColumns = false;
        }

        private void FillGridView()
        {
            this.Entity.Name = txtFind.Text;

            this.Entity.IdEmployee = null;

            if (this.cmbEmployee.SelectedIndex > 0)
            {
                this.Entity.IdEmployee = int.Parse(this.cmbEmployee.SelectedValue.ToString());
            }

            List<posb.Loan> loans = this.Entity.List(this.dtpDate1.Value, this.dtpDate2.Value);

            List<posb.Loan> loans2 = new List<posb.Loan>();

            if (this.cmbType.SelectedIndex.Equals(0))
            {
                loans2 = loans;
            }
            else
            {
                foreach (var loan in loans)
                {
                    if (this.cmbType.SelectedIndex.Equals(2) && loan.Amount > loan.PaymentTotal)
                    {
                        loans2.Add(loan);
                    }
                    else if (this.cmbType.SelectedIndex.Equals(1) && loan.Amount.Equals(loan.PaymentTotal))
                    {
                        loans2.Add(loan);
                    }
                }
            }

            this.gvList.AutoGenerateColumns = false;

            this.gvList.DataSource = loans2;

            

            this.lblTotalExpenses.Text = String.Format("{0:0.00}", loans2.Sum(item => item.Amount));

            this.lblPagado.Text = String.Format("{0:0.00}", loans2.Sum(item => item.PaymentTotal));

            this.lblSaldo.Text = String.Format("{0:0.00}", decimal.Parse(this.lblTotalExpenses.Text) - decimal.Parse(this.lblPagado.Text));
        }

        #endregion

        private void txtFind_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.cmbEmployee.SelectedIndex > 0)
            {
                SmartPayment SmartPayment = new SmartPayment(int.Parse(this.cmbEmployee.SelectedValue.ToString()),decimal.Parse(this.lblSaldo.Text));

                SmartPayment.Result += new SmartPayment.Communication(Result2);

                SmartPayment.ShowDialog();
            }
        }

        private void Result2(bool IsCorrect, String ErrorMessage, int Id)
        {
            this.FillGridView();
        }

        private void dtpDate2_ValueChanged(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void dtpDate1_ValueChanged(object sender, EventArgs e)
        {
            this.FillGridView();
        }
    }
}