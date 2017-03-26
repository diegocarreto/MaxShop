using System;
using System.Windows.Forms;
using posb = PosBusiness;
using UtilitiesForm.Extensions;

namespace WindowsFormsApplication1
{
    public partial class ClientEdit : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage, int Id);

        public event Communication Result;

        private int? Id = null;

        private bool IsCopy = false;

        #endregion

        #region Builder

        public ClientEdit(int? Id = null, bool IsCopy = false)
        {
            InitializeComponent();

            this.Id = Id;
            this.IsCopy = IsCopy;
        }

        #endregion

        #region Events

        private void MeasureEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtName;

            if (this.Id.HasValue)
            {
                this.LoadData(this.Id);
            }

            if (this.IsCopy)
            {
                this.Id = null;

                this.txtName.Clear();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtName.Text))
            {
                //if (!string.IsNullOrEmpty(this.txtPhone1.Text))
                //{
                //    if (!string.IsNullOrEmpty(this.txtStreet.Text))
                //    {
                //        if (!string.IsNullOrEmpty(this.txtMunicipality.Text))
                //        {
                //            if (!string.IsNullOrEmpty(this.txtState.Text))
                //            {
                                if (this.Id.HasValue)
                                {
                                    if (!this.Name.Equals(txtName.Text, StringComparison.InvariantCultureIgnoreCase))
                                        this.Save();
                                    else
                                        this.Save(false);
                                }
                                else
                                    this.Save();
                            //}
                            //else
                            //{
                            //    this.Alert("Debe indicar el estado");
                            //    this.txtState.Focus();
                            //}
                //        }
                //        else
                //        {
                //            this.Alert("Debe indicar el municipio");
                //            this.txtMunicipality.Focus();
                //        }
                //    }
                //    else
                //    {
                //        this.Alert("Debe indicar la calle");
                //        this.txtStreet.Focus();
                //    }
                //}
                //else
                //{
                //    this.Alert("Debe indicar un número telefónico");
                //    this.txtPhone1.Focus();
                //}
            }
            else
            {
                this.Alert("Debe indicar el nombre del cliente");
                this.txtName.Focus();
            };
        }

        #endregion

        #region Methods

        private void LoadData(int? Id)
        {
            using (posb.Client Entity = new posb.Client
            {
                Id = this.Id
            })
            {
                Entity.Get();

                this.txtName.Text = Entity.Name;
                this.Name = Entity.Name;

                this.txtPhone1.Text = Entity.Phone1;
                this.txtPhone2.Text = Entity.Phone2.Replace("N/A", string.Empty);
                this.txtStreet.Text = Entity.Street;
                this.txtForeign.Text = Entity.Number1;
                this.txtInside.Text = Entity.Number2;
                this.txtColony.Text = Entity.Colony;
                this.txtMunicipality.Text = Entity.Municipality;
                this.txtState.Text = Entity.State;
                this.txtZipCode.Text = Entity.Zip;
                this.cbActive.Checked = Entity.Active.Value;
                this.txtOther.Text = Entity.Others.Replace("N/A", string.Empty);
            }
        }

        private void Save(bool Exist = true)
        {
            using (posb.Client Entity = new posb.Client
            {
                Name = this.txtName.Text,

                Phone1 = this.txtPhone1.Text,
                Phone2 = this.txtPhone2.Text,
                Street = this.txtStreet.Text,
                Number1 = this.txtForeign.Text,
                Number2 = this.txtInside.Text,
                Colony = this.txtColony.Text,
                Municipality = this.txtMunicipality.Text,
                State = this.txtState.Text,
                Zip = this.txtZipCode.Text,
                Others = this.txtOther.Text,
                Active = this.cbActive.Checked,
                Id = this.Id
            })
            {
                if (Exist && Entity.Exist())
                    this.Alert("Ya se encuentra registrado el cliente  [" + Entity.Name + "]");
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
