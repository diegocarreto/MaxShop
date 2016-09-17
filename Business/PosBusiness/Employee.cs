using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Employee : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        public decimal? Salary { get; set; }

        public string Phone { get; set; }

        #endregion

        #region Builder

        public Employee()
        {

        }

        #endregion

        #region Methods

        public bool Exist()
        {
            return this.AccessMsSql.Pos.Existemployee.ExeScalar<int>(this.Name).Equals(1);
        }

        public bool Get()
        {
            try
            {
                Employee employee = this.List().First();

                this.Name = employee.Name;
                this.Active = employee.Active;
                this.Salary = employee.Salary;
                this.Phone = employee.Phone;

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
        public List<Employee> List()
        {
            return this.AccessMsSql.Pos.Listemployee.ExeList<Employee>(this.Id, this.Name);
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
                    this.AccessMsSql.Pos.Updateemployee.ExeScalar<int>(this.Id, this.Name, this.Salary, this.Phone);
                }
                else
                {
                    this.Id = this.AccessMsSql.Pos.Addemployee.ExeScalar<int>(this.Name, this.Salary, this.Phone);
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
                this.AccessMsSql.Pos.Deleteemployee.ExeNonQuery(this.Id);

                return true;
            }
            catch (Exception ex)
            {
                this.SetError(ex);

                return false;
            }

        }

        public decimal GetDebt()
        {
            return this.AccessMsSql.Pos.Gettotaldebt.ExeScalar<decimal>(this.Id);
        }

        #endregion
    }
}