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
    public partial class ProductEdit : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage);

        public event Communication Result;

        private int? Id = null;

        private int? IdLabel = null;

        private int? IdMaterial = null;

        #endregion

        #region Builder

        public ProductEdit(int? Id = null)
        {
            InitializeComponent();
            this.Id = Id;
        }

        #endregion

        #region Events

        private void ProductEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.cmbLabel;

            this.GetGroups();
            this.GetLabels();
            this.GetMaterials();

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
            if (cmbLabel.SelectedIndex > 0)
            {
                if (cmbGroup.SelectedIndex > 0)
                {
                    if (this.Id.HasValue)
                    {
                        this.Save((int.Parse(this.cmbLabel.SelectedValue.ToString()) != this.IdLabel || int.Parse(this.cmbMaterial.SelectedValue.ToString()) != this.IdMaterial));
                    }
                    else
                        this.Save();
                }
                else
                    this.Alert("Debe indicar el grupo del subproducto");
            }
            else
                this.Alert("Debe indicar la etiqueta del subproducto");
        }

        #endregion

        #region Methods

        private void GetLabels()
        {
            using (posb.Label Label = new posb.Label())
            {
                this.cmbLabel.Fill(Label.List());
            }
        }

        private void GetMaterials()
        {
            using (posb.Material Material = new posb.Material())
            {
                this.cmbMaterial.Fill(Material.List());
            }
        }

        private void GetGroups()
        {
            using (posb.Group Group = new posb.Group())
            {
                this.cmbGroup.Fill(Group.List());
            }
        }

        private void LoadData(int? Id)
        {
            using (posb.Product Entity = new posb.Product
            {
                Id = this.Id
            })
            {
                Entity.Get();

                this.IdLabel = Entity.IdLabel;
                this.IdMaterial = Entity.IdMaterial == null ? 0 : Entity.IdMaterial;

                cmbLabel.SelectedValue = this.IdLabel;
                cmbMaterial.SelectedValue = this.IdMaterial;
                cmbGroup.SelectedValue = Entity.IdGroup;

                this.cbActive.Checked = Entity.Active.Value;
            }
        }

        private void Save(bool Exist = true)
        {
            using (posb.Product Entity = new posb.Product
            {
                IdLabel = int.Parse(this.cmbLabel.SelectedValue.ToString()),
                IdMaterial = int.Parse(this.cmbMaterial.SelectedValue.ToString()),
                IdGroup = int.Parse(this.cmbGroup.SelectedValue.ToString()),
                Active = this.cbActive.Checked,
                Id = this.Id
            })
            {
                if (Entity.IdMaterial.Equals(0))
                    Entity.IdMaterial = null;

                if (Exist && Entity.Exist())
                {
                    string message = this.cmbLabel.Text + (this.cmbMaterial.SelectedIndex > 0 ? " de " + this.cmbMaterial.Text : string.Empty);

                    this.Alert("Ya se encuentra registrado el subproducto [" + message + "]");
                }
                else
                {
                    Entity.Save();

                    this.Result(true, "");

                    this.Close();
                }
            }
        }

        #endregion
    }
}
