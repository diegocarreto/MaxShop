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
using Utilities.Extensions;
using UtilitiesForm.Extensions;
using PosUtilities;

namespace WindowsFormsApplication1
{
    public partial class Group : FormBase
    {
        #region Properties

        private posb.Group Entity { get; set; }

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

        public Group()
        {
            InitializeComponent();

            this.Entity = new posb.Group();
        }

        #endregion

        #region Events

        private void Group_Load(object sender, EventArgs e)
        {
            this.ConfigureGridView();

            this.FillGridView();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntFind_Click(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.OpenEdit();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.OpenEdit(this.EntityId);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.Confirm(PosLabels.GroupConfirmDelete1 + this.EntityName + PosLabels.GroupConfirmDelete2))
            {
                this.Entity.Id = this.EntityId;

                if (this.Entity.Delete())
                {
                    this.Entity.Id = null;

                    this.FillGridView();
                }
                else
                    this.Alert(PosLabels.GroupAlertError1 + this.EntityName + PosLabels.GroupAlertError2, eForm.TypeError.Error);
            }
        }

        private void Result(bool IsCorrect, String ErrorMessage, int Id)
        {
            this.FillGridView();
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            this.FillGridView();
        }

        #endregion

        #region Methods

        private void OpenEdit(int? Id = null)
        {
            GroupEdit GroupEdit = new GroupEdit(Id);

            GroupEdit.Result += new GroupEdit.Communication(Result);

            GroupEdit.ShowDialog();
        }

        private void ConfigureGridView()
        {
            this.gvList.AutoGenerateColumns = false;

            this.gvList.AllowUserToResizeColumns = false;
        }

        private void FillGridView()
        {
            this.Entity.Name = txtFind.Text;
            this.Entity.Prefix = this.Entity.Name;

            this.gvList.DataSource = this.Entity.List();
        }

        #endregion


    }
}
