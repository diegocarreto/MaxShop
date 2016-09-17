using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Company : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string Address { get; set; }

        public string ShopName { get; set; }

        public string TicketAddress1 { get; set; }

        public string TicketAddress2 { get; set; }

        public string TicketPhoneNumber { get; set; }

        #endregion

        #region Builder

        public Company()
        {
        }

        #endregion

        #region Methods

        public bool Exist()
        {
            return this.AccessMsSql.Pos.Existbrand.ExeScalar<int>(this.Name).Equals(1);
        }

        public bool Get()
        {
            try
            {
                Company company = this.List().First();

                this.Name = company.Name;
                this.Active = company.Active;

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
        public List<Company> List()
        {
            return this.AccessMsSql.Pos.Listcompany.ExeList<Company>(this.Id, this.Name);
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
                    this.AccessMsSql.Pos.Updatebrand.ExeScalar<int>(this.Id, this.Name, this.Active);
                }
                else
                {
                    this.Id = this.AccessMsSql.Pos.Addbrand.ExeScalar<int>(this.Name, this.Active);
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
                this.AccessMsSql.Pos.Deletebrand.ExeNonQuery(this.Id);

                return true;
            }
            catch (Exception ex)
            {
                this.SetError(ex);

                return false;
            }

        }

        public List<Company> GetTicket(bool? Principal)
        {
            return this.AccessMsSql.Pos.Getticketcompany.ExeList<Company>(this.Id, Principal);
        }

        #endregion
    }
}
