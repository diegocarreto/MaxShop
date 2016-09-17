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
    public partial class Freight : FormBase
    {
        #region Members

        private int IdPm;

        private int ScrollPosition = 0;

        #endregion

        #region Properties

        private posb.Freight Entity { get; set; }

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

        public Freight(int IdPm)
        {
            InitializeComponent();

            this.IdPm = IdPm;

            this.Entity = new posb.Freight();
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
            if (this.Confirm("¿Realmente deseas eliminar el flete [" + this.EntityName + "]?"))
            {
                this.Entity.Id = this.EntityId;

                if (this.Entity.Delete())
                {
                    this.Entity.Id = null;

                    this.FillGridView();
                }
                else
                    this.Alert("Ocurrió un error al intentar eliminar eliminar el flete [" + this.EntityName + "]", eForm.TypeError.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.OpenEdit();
        }

        private void Result(bool IsCorrect, String ErrorMessage)
        {
            FillGridView();

            this.gvList.FirstDisplayedScrollingRowIndex = this.gvList.RowCount - 1;
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

        private void gvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(1))
            {
                this.OpenEdit(this.EntityId);
            }
        }

        private void gvList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            gvList.Cursor = Cursors.Default;
        }

        private void gvList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex.Equals(1))
                gvList.Cursor = Cursors.Hand;
            else
                gvList.Cursor = Cursors.Default;
        }

        #endregion

        #region Methods

        private void OpenEdit(int? Id = null)
        {
            this.ScrollPosition = gvList.FirstDisplayedScrollingRowIndex;

            FreightEdit FreightEdit = new FreightEdit(this.IdPm, Id);

            FreightEdit.Result += new FreightEdit.Communication(Result);

            FreightEdit.ShowDialog();
        }

        private void ConfigureGridView()
        {
            this.gvList.AutoGenerateColumns = false;

            this.gvList.AllowUserToResizeColumns = false;
        }

        private void FillGridView()
        {
            this.Entity.IdPm = this.IdPm;

            this.gvList.DataSource = this.Entity.List();

            //try
            //{
            //    this.gvList.FirstDisplayedScrollingRowIndex = this.ScrollPosition;
            //}
            //catch
            //{
            //}
        }

        #endregion
    }
}
