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
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class FreightEdit : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage);

        public event Communication Result;

        private int? Id = null;

        private int? IdPM = null;

        private int? IdDestination = null;

        #endregion

        #region Builder

        public FreightEdit(int IdPm, int? Id = null)
        {
            InitializeComponent();

            this.Id = Id;
            this.IdPM = IdPm;
        }

        #endregion

        #region Events

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (this.cmbDestination.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(this.txtCost.Text))
                {
                    if (this.Id.HasValue)
                    {
                        //if (this.IdDestination != int.Parse(this.cmbDestination.SelectedValue.ToString()))
                            this.Save(false);
                        //else
                        //    this.Save(false);
                    }
                    else
                        this.Save(false);
                }
                else
                {
                    this.Alert("Debe indicar el costo");
                    this.txtCost.Focus();
                }
            }
            else
            {
                this.Alert("Debe indicar el destino");
                this.cmbDestination.Focus();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PMEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.cmbDestination;

            this.GetDestinations();

            if (this.Id.HasValue)
            {
                this.LoadData(this.Id);
            }
        }

        #endregion

        #region Methods

        private void GetDestinations()
        {
            using (posb.Freight Freight = new posb.Freight())
            {
                this.cmbDestination.Fill(Freight.ListDestination());
            }
        }

        private void LoadData(int? Id)
        {
            using (posb.Freight Entity = new posb.Freight
            {
                Id = this.Id
            })
            {
                Entity.Get();

                this.cmbDestination.SelectedValue = Entity.IdDestination;
                this.IdDestination = Entity.IdDestination;

                this.txtCost.Text = Entity.Cost.ToString();
                this.txtMax.Text = Entity.Max.ToString();
                this.txtMin.Text = Entity.Min.ToString();
                this.cbActive.Checked = Entity.Active.Value;

            }
        }

        private void Save(bool Exist = true)
        {
            using (posb.Freight Entity = new posb.Freight
            {
                IdDestination = int.Parse(this.cmbDestination.SelectedValue.ToString()),
                Cost = decimal.Parse(this.txtCost.Text),
                Active = this.cbActive.Checked,
                IdPm = this.IdPM,
                Id = this.Id,
            })
            {
                if (string.IsNullOrEmpty(this.txtMax.Text))
                    Entity.Max = null;
                else
                    Entity.Max = double.Parse(this.txtMax.Text);

                if (string.IsNullOrEmpty(this.txtMin.Text))
                    Entity.Min = null;
                else
                    Entity.Min = double.Parse(this.txtMin.Text);


                if (Exist && Entity.Exist())
                {
                    this.Alert("Ya se encuentra registrado el flete [" + this.cmbDestination.Text + "]");
                }
                else
                {
                    Entity.Save();

                    this.Result(true, "");

                    this.Id = null;
                    this.txtMin.Text = (int.Parse(this.txtMax.Text) + 1).ToString();
                    this.txtMax.Text = "";
                    this.txtCost.Text = "";

                    this.txtCost.Focus();

                    //this.Close();
                }
            }
        }

        #endregion
    }
}
