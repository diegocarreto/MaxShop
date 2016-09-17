using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Expense : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        public bool ForReport { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int? IdExpense { get; set; }

        public int? IdCategory { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public decimal? Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? Date { get; set; }

        #endregion

        #region Builder

        public Expense()
        {
        }

        #endregion

        #region Methods

        public bool Get()
        {
            try
            {
                Expense expense = this.AccessMsSql.Pos.Getexpense.ExeList<Expense>(this.Id).First();

                this.Name = expense.Name;
                this.Description = expense.Description;
                this.Amount = expense.Amount;
                this.IdCategory = expense.IdCategory;
                this.Aux2 = expense.Aux2.Replace("$", string.Empty);

                return true;
            }
            catch (Exception ex)
            {
                this.SetError(ex);

                return false;
            }
        }

        public bool GetDetail(int? Id = null)
        {
            try
            {
                Expense expense = this.ListDetail(Id).First();

                this.Id = expense.Id;
                this.Name = expense.Name;
                this.Amount = expense.Amount;
                this.Date = expense.Date;
                this.CreatedDate = expense.CreatedDate;
                this.Name = expense.Name;
                this.Active = expense.Active;

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
        public List<Expense> ListCategory()
        {
            return this.AccessMsSql.Pos.Listcategoryexpense.ExeList<Expense>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Expense> List()
        {
            return this.AccessMsSql.Pos.Listexpense.ExeList<Expense>(this.IdCategory, this.StartDate, this.EndDate, this.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Expense> ListDetail(int? Id = null)
        {
            if (Id.HasValue)
            {
                return this.AccessMsSql.Pos.Listexpensedetail.ExeList<Expense>(null, Id);
            }
            else
            {

                return this.AccessMsSql.Pos.Listexpensedetail.ExeList<Expense>(this.Id);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SaveDetail()
        {
            try
            {
                if (this.Id.HasValue)
                {
                    this.AccessMsSql.Pos.Updatedetailexpense.ExeScalar<int>(this.Id, this.Amount, this.Date, this.Name);
                }
                else
                {
                    this.Id = this.AccessMsSql.Pos.Adddetailexpense.ExeScalar<int>(this.IdExpense, this.Amount, this.Date, this.Name);
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
        public bool Save()
        {
            try
            {
                if (this.Id.HasValue)
                {
                    this.AccessMsSql.Pos.Updateexpense.ExeScalar<int>(this.Id, this.IdCategory, this.Name, this.Description, this.Amount);
                }
                else
                {
                    this.Id = this.AccessMsSql.Pos.Addexpense.ExeScalar<int>(this.IdCategory, this.Name, this.Description, this.Amount);
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
        public bool DeleteDetail()
        {
            try
            {
                this.AccessMsSql.Pos.Deletedetailexpense.ExeNonQuery(this.Id);

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
                this.AccessMsSql.Pos.Deleteexpense.ExeNonQuery(this.Id);

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
