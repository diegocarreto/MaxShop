using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Location : EntityBase
    {
        #region Members
        #endregion

        #region Properties
        #endregion

        #region Builder

        public Location()
        {
        }

        #endregion

        #region Methods

        public bool Exist()
        {
            return this.AccessMsSql.Pos.Existlocation.ExeScalar<int>(this.Name).Equals(1);
        }

        public bool Get()
        {
            try
            {
                Location location = this.List().First();

                this.Name = location.Name;
                this.Active = location.Active;

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
        public List<Location> List()
        {
            return this.AccessMsSql.Pos.Listlocation.ExeList<Location>(this.Id, this.Name);
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
                    this.AccessMsSql.Pos.Updatelocation.ExeScalar<int>(this.Id, this.Name, this.Active);
                }
                else
                {
                    this.Id = this.AccessMsSql.Pos.Addlocation.ExeScalar<int>(this.Name, this.Active);
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
                this.AccessMsSql.Pos.Deletelocation.ExeNonQuery(this.Id);

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
