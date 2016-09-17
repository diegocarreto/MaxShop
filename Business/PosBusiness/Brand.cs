using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Brand : EntityBase
    {
        #region Members
        #endregion

        #region Properties
        #endregion

        #region Builder

        public Brand()
        {
        }

        #endregion

        #region Methods

        public string GetUrlSearch()
        {
            return this.AccessMsSql.Pos.Getbrandurlsearch.ExeScalar<string>(this.Id);
        }

        public bool Exist()
        {
            return this.AccessMsSql.Pos.Existbrand.ExeScalar<int>(this.Name).Equals(1);
        }

        public bool Get()
        {
            try
            {
                Brand brand = this.List().First();

                this.Name = brand.Name;
                this.Active = brand.Active;

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
        public List<Brand> List()
        {
            return this.AccessMsSql.Pos.Listbrand.ExeList<Brand>(this.Id, this.Name);
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

        #endregion
    }
}
