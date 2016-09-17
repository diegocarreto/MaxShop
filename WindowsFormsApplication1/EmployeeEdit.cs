using System;
using System.Windows.Forms;
using posb = PosBusiness;
using UtilitiesForm.Extensions;

namespace WindowsFormsApplication1
{
    public partial class EmployeeEdit : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage, int Id);

        public event Communication Result;

        private int? Id = null;

        #endregion

        #region Builder

        public EmployeeEdit(int? Id = null)
        {
            InitializeComponent();

            this.Id = Id;
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                if (!string.IsNullOrEmpty(this.txtPhone.Text))
                {
                    if (!string.IsNullOrEmpty(this.txtSalary.Text))
                    {
                        if (this.Id.HasValue)
                        {
                            if (!this.Name.Equals(txtName.Text, StringComparison.InvariantCultureIgnoreCase))
                                this.Save();
                            else
                                this.Save(false);
                        }
                        else
                            this.Save();
                    }
                    else
                        this.Alert("Debe indicar el salario del empleado");
                }
                else
                    this.Alert("Debe indicar el telefono del empleado");
            }
            else
                this.Alert("Debe indicar el nombre del empleado");
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
            using (posb.Employee Entity = new posb.Employee
            {
                Id = this.Id
            })
            {
                Entity.Get();

                this.txtName.Text = Entity.Name;
                this.Name = Entity.Name;
                this.txtPhone.Text = Entity.Phone;
                this.txtSalary.Text = String.Format("{0:0.00}", Entity.Salary);
            }
        }

        private void Save(bool Exist = true)
        {
            using (posb.Employee Entity = new posb.Employee
            {
                Name = this.txtName.Text,
                Salary = decimal.Parse(this.txtSalary.Text),
                Phone = this.txtPhone.Text,
                Id = this.Id
            })
            {
                if (Exist && Entity.Exist())
                    this.Alert("Ya se encuentra registrado el empleado [" + Entity.Name + "]");
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
