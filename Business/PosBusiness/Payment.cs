using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Payment : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int? IdLoan { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Date { get; set; }

        #endregion

        #region Builder

        public Payment()
        {

        }

        #endregion

        #region Methods

        public bool Get(int? Id = null)
        {
            try
            {
                Payment payment = this.List(Id).First();

                this.Id = payment.Id;
                this.IdLoan = payment.IdLoan;
                this.Amount = payment.Amount;
                this.Date = payment.Date;
                this.CreatedDate = payment.CreatedDate;
                this.Name = payment.Name;
                this.Active = payment.Active;

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
        public List<Payment> List(int? Id = null)
        {
            if (Id.HasValue)
            {
                return this.AccessMsSql.Pos.Listpayment.ExeList<Payment>(null, Id);
            }
            else
            {

                return this.AccessMsSql.Pos.Listpayment.ExeList<Payment>(this.Id);
            }
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
                    this.AccessMsSql.Pos.Updatepayment.ExeScalar<int>(this.Id, this.Amount, this.Date);
                }
                else
                {
                    this.Id = this.AccessMsSql.Pos.Addpayment.ExeScalar<int>(this.IdLoan, this.Amount, this.Date);
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
                this.AccessMsSql.Pos.Deletepayment.ExeNonQuery(this.Id);

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