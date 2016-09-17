using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitiesForm.Extensions;
using Utilities.Extensions;
using posb = PosBusiness;

namespace WindowsFormsApplication1
{
    public partial class SearchProducts : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage, int IdPm, TextBox TxtFocus);

        public event Communication Result;

        #endregion

        #region Properties

        private posb.PM Entity { get; set; }

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

        public TextBox TxtFocus { get; set; }

        #endregion

        #region Builder

        public SearchProducts()
        {
            InitializeComponent();

            this.Entity = new posb.PM();
        }

        #endregion

        #region Events

        private void PM_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtFind;

            this.SetTypeLike();

            this.ConfigureGridView();

            this.GetGroups();

            this.GetBrands();

            this.FillGridView();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            this.FillGridView();
        }

        private void gvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.Result != null)
                this.Result(true, "", this.EntityId, this.TxtFocus);
        }

        private void gvList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            gvList.Cursor = Cursors.Hand;
        }

        private void gvList_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            gvList.Cursor = Cursors.Default;
        }

        private void cmBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillGridView();
        }

        private void cmbTypeLike_SelectedValueChanged(object sender, EventArgs e)
        {
            this.FillGridView();
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

        private void GetBrands()
        {
            using (posb.Brand Brand = new posb.Brand())
            {
                this.cmBrand.Fill(Brand.List());
            }
        }

        private void SetTypeLike()
        {
            var tp = new
            {
                Id = 0,
                Name = string.Empty
            };

            var options = tp.ToList();

            options.Add(new { Id = 0, Name = "Inicia" });
            options.Add(new { Id = 1, Name = "Contiene" });
            options.Add(new { Id = 2, Name = "Termina" });

            this.cmbTypeLike.Fill(options, AddFirstOption: false);

            this.cmbTypeLike.SelectedIndex = 1;
        }

        private void ConfigureGridView()
        {
            this.gvList.AutoGenerateColumns = false;

            this.gvList.AllowUserToResizeColumns = false;

            this.gvList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void FillGridView()
        {
            this.gvList.AutoGenerateColumns = false;

            int id = 0;

            this.Entity.Name = txtFind.Text;

            if (int.TryParse(this.Entity.Name, out id))
            {
                this.Entity.Id = id;
            }
            else
            {
                this.Entity.Id = null;
            }

            if (this.cmBrand.SelectedIndex > 0)
            {
                this.Entity.IdBrand = int.Parse(this.cmBrand.SelectedValue.ToString());
            }
            else
            {
                this.Entity.IdBrand = null;
            }

            if (this.cmbGroup.SelectedIndex > 0)
            {
                this.Entity.IdGroup = int.Parse(this.cmbGroup.SelectedValue.ToString());
            }
            else
            {
                this.Entity.IdGroup = null;
            }

            int typeLike = 0;

            if (this.cmbTypeLike.SelectedValue != null && int.TryParse(this.cmbTypeLike.SelectedValue.ToString(), out typeLike))
            {
                this.Entity.TypeLike = typeLike;
            }
            else
            {
                this.Entity.TypeLike = 0;
            }

            this.gvList.DataSource = this.Entity.List();

            lblTotal.Text = this.gvList.RowCount.ToString();
        }

        #endregion
    }
}
