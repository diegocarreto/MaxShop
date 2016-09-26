using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Loan : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int? IdEmployee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? Balance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? PaymentTotal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Detail { get; set; }

        #endregion

        #region Builder

        public Loan()
        {

        }

        #endregion

        #region Methods

        public bool Get()
        {
            try
            {
                Loan loan = this.List().First();

                this.Id = loan.Id;
                this.IdEmployee = loan.IdEmployee;
                this.Amount = loan.Amount;
                this.Date = loan.Date;
                this.CreatedDate = loan.CreatedDate;
                this.Name = loan.Name;
                this.Active = loan.Active;
                this.PaymentTotal = loan.PaymentTotal;
                this.Detail = loan.Detail;

                return true;
            }
            catch (Exception ex)
            {
                this.SetError(ex);

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Loan> List(DateTime? StartDate = null, DateTime? FinishDate = null)
        {
            return this.AccessMsSql.Pos.Listloan.ExeList<Loan>(this.Id, this.IdEmployee, StartDate, FinishDate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            try
            {
                if (this.Id.HasValue)
                {
                    this.AccessMsSql.Pos.Updateloan.ExeScalar<int>(this.Id, this.IdEmployee, this.Amount, this.Date, this.Detail);
                }
                else
                {
                    this.Id = this.AccessMsSql.Pos.Addloan.ExeScalar<int>(this.IdEmployee, this.Amount, this.Date, this.Detail);
                }

                return true;
            }
            catch (Exception ex)
            {
                this.SetError(ex);

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            try
            {
                this.AccessMsSql.Pos.Deleteloan.ExeNonQuery(this.Id);

                return true;
            }
            catch (Exception ex)
            {
                this.SetError(ex);

                return false;
            }

        }

        #endregion
    }
}