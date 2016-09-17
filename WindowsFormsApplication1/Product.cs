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
    public partial class Product : FormBase
    {
        #region Properties

        private posb.Product Entity { get; set; }

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

        public Product()
        {
            InitializeComponent();

            this.Entity = new posb.Product();
        }

        #endregion

        #region Events

        private void Product_Load(object sender, EventArgs e)
        {
            this.GetGroups();

            this.GetLabels();

            this.ConfigureGridView();

            this.FillGridView();
        }

        private void bntFind_Click(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.Confirm("¿Realmente deseas eliminar el subproducto [" + this.EntityName + "]?"))
            {
                this.Entity.Id = this.EntityId;

                if (this.Entity.Delete())
                {
                    this.Entity.Id = null;

                    this.FillGridView();
                }
                else
                    this.Alert("Ocurrió un error al intentar eliminar el subproducto [" + this.EntityName + "]", eForm.TypeError.Error);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Result(bool IsCorrect, String ErrorMessage)
        {
            FillGridView();
        }

        private void btnMass_Click(object sender, EventArgs e)
        {
            ProductMass ProductMass = new ProductMass(MassiveLoadTypes.Product);

            ProductMass.Result += new ProductMass.Communication(Result);

            ProductMass.ShowDialog();
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            this.FillGridView();
        }

        private void cmbLabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.FillGridView();
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.FillGridView();
        }

        #endregion

        #region Methods

        private void GetGroups()
        {
            using (posb.Group Group = new posb.Group())
            {
                this.cmbGroup.Fill(Group.List());
            }
        }

        private void GetLabels()
        {
            using (posb.Label Label = new posb.Label())
            {
                this.cmbLabel.Fill(Label.List());
            }
        }

        private void OpenEdit(int? Id = null)
        {
            ProductEdit ProductEdit = new ProductEdit(Id);

            ProductEdit.Result += new ProductEdit.Communication(Result);

            ProductEdit.ShowDialog();
        }

        private void ConfigureGridView()
        {
            this.gvList.AutoGenerateColumns = false;

            this.gvList.AllowUserToResizeColumns = false;
        }

        private void FillGridView()
        {
            int idGroup = 0,
                idLabel = 0;

            if (this.cmbGroup.SelectedValue != null && int.TryParse(this.cmbGroup.SelectedValue.ToString(), out idGroup))
            {
                this.Entity.IdGroup = idGroup;

                if (Entity.IdGroup.Equals(0))
                    Entity.IdGroup = null;
            }

            if (this.cmbLabel.SelectedValue != null && int.TryParse(this.cmbLabel.SelectedValue.ToString(), out idLabel))
            {
                this.Entity.IdLabel = idLabel;

                if (Entity.IdLabel.Equals(0))
                    Entity.IdLabel = null;
            }

            this.Entity.Name = txtFind.Text;

            this.gvList.DataSource = this.Entity.List();

            lblTotal.Text = this.gvList.RowCount.ToString();
        }

        #endregion
    }
}
