using System;
using System.Windows.Forms;
using posb = PosBusiness;
using UtilitiesForm.Extensions;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public partial class SmartPayment : FormBase
    {
        #region Members

        public delegate void Communication(bool IsCorrect, String ErrorMessage, int Id);

        public event Communication Result;

        private int? IdUser = null;

        private decimal Total = 0;

        private decimal Salary = 0;

        #endregion

        #region Builder

        public SmartPayment(int? IdUser = null, decimal Total = 0)
        {
            InitializeComponent();

            this.IdUser = IdUser;
        }

        #endregion

        #region Events

        private void MeasureEdit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtPago;

            this.LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            decimal pago = 0;

            if (decimal.TryParse(this.txtPago.Text, out pago))
            {
                if (pago <= 0)
                {
                    this.Alert("El pago debe ser mayor a cero", eForm.TypeError.Error);
                    this.txtPago.Focus();

                    return;
                }

                if (this.Confirm("¿Realmente deseas realiza el pago de [$" + String.Format("{0:0.00}", pago) + "]?"))
                {
                    posb.Loan loan = new posb.Loan();

                    loan.IdEmployee = this.IdUser;

                    var loans = loan.List(DateTime.Now.AddYears(-10), DateTime.Now);

                    List<posb.Loan> loans2 = new List<posb.Loan>();

                    foreach (var ln in loans)
                    {
                        if (ln.Amount > ln.PaymentTotal)
                        {
                            decimal? deuda = ln.Amount - ln.PaymentTotal;

                            using (posb.Payment Entity = new posb.Payment
                            {
                                Date = DateTime.Now,
                                Id = null,
                                IdLoan = ln.Id
                            })
                            {
                                if (deuda > pago)
                                {
                                    Entity.Amount = pago;
                                    Entity.Save();

                                    break;
                                }
                                else
                                {
                                    decimal resto = pago - deuda.Value;
                                    pago = resto;

                                    Entity.Amount = deuda.Value;
                                    Entity.Save();

                                    if (pago <= 0)
                                        break;
                                }
                            }

                            loans2.Add(ln);
                        }
                    }

                    this.Result(true, "", this.IdUser.Value);

                    this.Close();
                }
            }
            else
            {
                this.Alert("Indique el pago", eForm.TypeError.Error);
                this.txtPago.Focus();
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDeuda.Text.Length.Equals(0))
                e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
            else if (txtDeuda.Text[txtDeuda.Text.Length - 1] == ' ')
                e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
            else
                e.KeyChar = e.KeyChar.ToString().ToLower().ToCharArray()[0];
        }

        #endregion

        #region Methods

        private void GetFinalSalary()
        {
            decimal pago = string.IsNullOrEmpty(this.txtPago.Text) ? 0 : decimal.Parse(this.txtPago.Text);

            this.txtSaldo.Text = String.Format("{0:0.00}", this.Salary - pago);
        }

        private void LoadData()
        {
            using (posb.Employee employee = new posb.Employee
            {
                Id = this.IdUser
            })
            {
                employee.Get();

                this.Total = employee.GetDebt();

                this.txtDeuda.Text = String.Format("{0:0.00}", this.Total);

                this.Salary = employee.Salary.Value;

                this.txtSueldo.Text = String.Format("{0:0.00}", this.Salary);

                decimal total3 = employee.Salary.Value / 3;

                if (this.Total > employee.Salary)
                {
                    decimal total2 = employee.Salary.Value / 2;

                    this.txtPago.Text = String.Format("{0:0.00}", total2);
                }
                else if (this.Total > total3)
                {
                    this.txtPago.Text = String.Format("{0:0.00}", total3);
                }
                else
                {
                    this.txtPago.Text = String.Format("{0:0.00}", this.Total);
                }

                this.GetFinalSalary();
            }
        }

        private void Save(bool Exist = true)
        {
            //using (posb.Brand Entity = new posb.Brand
            //{
            //    Name = this.txtName.Text,
            //    Active = this.cbActive.Checked,
            //    Id = this.Id
            //})
            //{
            //    if (Exist && Entity.Exist())
            //        this.Alert("Ya se encuentra registrada la marca [" + Entity.Name + "]");
            //    else
            //    {
            //        Entity.Save();

            //        this.Result(true, "", Entity.Id.Value);

            //        this.Close();
            //    }
            //}
        }

        #endregion

        private void txtSaldo_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPago_KeyUp(object sender, KeyEventArgs e)
        {
            this.GetFinalSalary();
        }
    }
}
