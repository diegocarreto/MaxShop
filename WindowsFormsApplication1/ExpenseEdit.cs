using System;
using System.Windows.Forms;
using posb = PosBusiness;
using UtilitiesForm.Extensions;

namespace WindowsFormsApplication1
{
    public partial class ExpenseEdit : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage, int Id);

        public event Communication Result;

        private int? Id = null;

        #endregion

        #region Builder

        public ExpenseEdit(int? Id = null)
        {
            InitializeComponent();

            this.Id = Id;
        }

        #endregion

        #region Events

        private void MeasureEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtName;

            this.txtAmount.KeyPress += new KeyPressEventHandler(this.txt_KeyPress);

            this.GetExpensesCategory();

            this.GetCompanies();

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
            if (this.cmbCompany.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(this.txtName.Text))
                {
                    if (this.cmbCategory.SelectedIndex > 0)
                    {
                        if (!string.IsNullOrEmpty(this.txtAmount.Text))
                        {
                            decimal amount;

                            if (decimal.TryParse(this.txtAmount.Text, out amount))
                            {
                                if (!string.IsNullOrEmpty(this.txtDescription.Text))
                                {
                                    this.Save();
                                }
                                else
                                {
                                    this.Alert("Debe indicar la descripción");
                                    this.txtDescription.Focus();
                                }
                            }
                            else
                            {
                                this.Alert("Debe indicar un valor numérico para el monto");

                                this.txtAmount.Text = string.Empty;
                                this.txtAmount.Focus();
                            }
                        }
                        else
                        {
                            this.Alert("Debe indicar el monto");
                            this.txtAmount.Focus();
                        }
                    }
                    else
                    {
                        this.Alert("Debe indicar la categoría");
                        this.cmbCategory.Focus();
                    }
                }
                else
                {
                    this.Alert("Debe indicar el nombre");
                    this.txtName.Focus();
                }
            }
            else
            {
                this.Alert("Debe indicar el negocio");
                this.cmbCompany.Focus();
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
            using (posb.Expense Entity = new posb.Expense
            {
                Id = this.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            })
            {
                Entity.Get();

                this.txtName.Text = Entity.Name;
                this.txtDescription.Text = Entity.Description;
                this.txtAmount.Text = Entity.Amount.ToString();

                int? idCategory = Entity.IdCategory == null ? 0 : Entity.IdCategory;
                this.cmbCategory.SelectedValue = idCategory;

                int? idCompany = Entity.IdCompany == null ? 0 : Entity.IdCompany;
                this.cmbCompany.SelectedValue = idCompany;
            }
        }

        private void GetCompanies()
        {
            using (posb.Company company = new posb.Company())
            {
                this.cmbCompany.Fill(company.List());
            }
        }

        private void Save(bool Exist = true)
        {
            using (posb.Expense Entity = new posb.Expense
            {
                Name = this.txtName.Text,
                Amount = decimal.Parse(this.txtAmount.Text),
                Description = txtDescription.Text,
                IdCategory = int.Parse(this.cmbCategory.SelectedValue.ToString()),
                Id = this.Id,
                IdCompany = int.Parse(this.cmbCompany.SelectedValue.ToString())
            })
            {
                Entity.Save();

                this.Result(true, "", Entity.Id.Value);

                this.Close();
            }
        }

        private void GetExpensesCategory()
        {
            using (posb.Expense Expense = new posb.Expense())
            {
                this.cmbCategory.Fill(Expense.ListCategory());
            }
        }

        #endregion
    }
}
