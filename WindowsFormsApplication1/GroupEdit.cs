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
using PosUtilities;

namespace WindowsFormsApplication1
{
    public partial class GroupEdit : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage, int Id);

        public event Communication Result;

        private int? Id = null;

        private string Name = string.Empty;

        private string Prefix = string.Empty;

        #endregion

        #region Builder

        public GroupEdit(int? Id = null)
        {
            InitializeComponent();
            this.Id = Id;
        }

        #endregion

        #region Events

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                if (!string.IsNullOrEmpty(txtPrefix.Text))
                {
                    if (this.Id.HasValue)
                    {
                        this.Save(!this.Name.Equals(txtName.Text, StringComparison.InvariantCultureIgnoreCase), (!this.Prefix.Equals(txtPrefix.Text, StringComparison.InvariantCultureIgnoreCase)));
                    }
                    else
                        this.Save();
                }
                else
                    this.Alert(PosLabels.GroupEditAlertPrefix);
            }
            else
                this.Alert(PosLabels.GroupEditAlertName);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GroupEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtName;

            if (this.Id.HasValue)
            {
                this.LoadData(this.Id);
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtName.Text.Length.Equals(0))
                e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
            else if (txtName.Text[txtName.Text.Length - 1] == ' ')
                e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
            else
                e.KeyChar = e.KeyChar.ToString().ToLower().ToCharArray()[0];
        }

        #endregion

        #region Methods

        private void LoadData(int? Id)
        {
            using (posb.Group Entity = new posb.Group
            {
                Id = this.Id
            })
            {
                Entity.Get();

                this.txtName.Text = Entity.Name;
                this.txtPrefix.Text = Entity.Prefix;

                this.Name = Entity.Name;
                this.Prefix = Entity.Prefix;

                this.cbActive.Checked = Entity.Active.Value;
            }
        }

        private void Save(bool Exist = true, bool Exist2 = true)
        {
            using (posb.Group Entity = new posb.Group
            {
                Name = this.txtName.Text,
                Prefix = this.txtPrefix.Text,
                Active = this.cbActive.Checked,
                Id = this.Id
            })
            {
                if (Exist && Entity.Exist())
                    this.Alert(PosLabels.GroupEditAlertExistGroupName1 + Entity.Name + PosLabels.GroupEditAlertExistGroupName2);
                else if (Exist2 && Entity.ExistPrefix())
                    this.Alert(PosLabels.GroupEditAlertExistGroupPrefix1 + Entity.Prefix + PosLabels.GroupEditAlertExistGroupPrefix2);
                else
                {
                    Entity.Save();

                    this.Result(true, "", Entity.Id.Value);

                    this.Close();
                }
            }
        }

        #endregion
    }
}
