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
    public partial class ExpenseDetail : FormBase
    {
        #region Properties

        private posb.Expense Entity { get; set; }

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

        public ExpenseDetail(int Id)
        {
            InitializeComponent();

            this.Entity = new posb.Expense();

            this.Entity.Id = Id;
        }

        #endregion

        #region Events

        private void Measure_Load(object sender, EventArgs e)
        {
            this.ConfigureGridView();

            this.FillGridView();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.Confirm("¿Realmente deseas eliminar el detalle [" + this.EntityName + "]?"))
            {
                this.Entity.Id = this.EntityId;

                if (this.Entity.DeleteDetail())
                {
                    this.FillGridView();

                    this.Entity.Id = null;
                }
                else
                    this.Alert("Ocurrió un error al intentar eliminar el detalle de $" + String.Format("{0:0.00}", double.Parse(this.EntityName)) + "", eForm.TypeError.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.OpenEdit(this.EntityId);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.OpenEdit(IdLoan: this.Entity.Id);
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

        private void gvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.ColumnIndex.Equals(0))
            //{
            //    this.OpenEdit(this.EntityId, this.Entity.Id);
            //}
        }

        private void gvList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            //gvList.Cursor = Cursors.Default;
        }

        private void gvList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.ColumnIndex.Equals(0))
            //    gvList.Cursor = Cursors.Hand;
            //else
            //    gvList.Cursor = Cursors.Default;
        }

        #endregion

        #region Methods

        private void OpenEdit(int? Id = null, int? IdLoan = null)
        {
            ExpenseDetailEdit expenseDetailEdit = new ExpenseDetailEdit(Id, IdLoan);

            expenseDetailEdit.Result += new ExpenseDetailEdit.Communication(Result);

            expenseDetailEdit.ShowDialog();
        }

        private void ConfigureGridView()
        {
            this.gvList.AutoGenerateColumns = false;

            this.gvList.AllowUserToResizeColumns = false;
        }

        private void FillGridView()
        {
            this.gvList.DataSource = this.Entity.ListDetail();
        }

        #endregion
    }
}
