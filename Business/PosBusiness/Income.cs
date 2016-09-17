using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Income : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        public bool ForReport { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int? IdCategory { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public decimal? Amount { get; set; }

        #endregion

        #region Builder

        public Income()
        {
        }

        #endregion

        #region Methods

        public bool Get()
        {
            try
            {
                Income income = this.AccessMsSql.Pos.Getincome.ExeList<Income>(this.Id).First();

                this.Name = income.Name;
                this.Description = income.Description;
                this.Amount = income.Amount;
                this.IdCategory = income.IdCategory;

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
        public List<Income> List()
        {
            return this.AccessMsSql.Pos.Listincome.ExeList<Income>(this.IdCategory, this.StartDate, this.EndDate, this.Name);
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
                    this.AccessMsSql.Pos.Updateincome.ExeScalar<int>(this.Id, this.IdCategory, this.Name, this.Description, this.Amount);
                }
                else
                {
                    this.Id = this.AccessMsSql.Pos.Addincome.ExeScalar<int>(this.IdCategory, this.Name, this.Description, this.Amount);
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
                this.AccessMsSql.Pos.Deleteincome.ExeNonQuery(this.Id);

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
