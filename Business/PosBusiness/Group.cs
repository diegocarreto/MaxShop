using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Group : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string Prefix { get; set; }

        #endregion

        #region Builder

        public Group()
        {
        }

        #endregion

        #region Methods

        public bool Exist()
        {
            return this.AccessMsSql.Pos.Existgroup.ExeScalar<int>(this.Name).Equals(1);
        }

        public int GetIdByNameGroup()
        {
            return this.AccessMsSql.Pos.Getidbynamegroup.ExeScalar<int>(this.Name);
        }

        public bool ExistPrefix()
        {
            return this.AccessMsSql.Pos.Existgroupbyprefix.ExeScalar<int>(this.Prefix).Equals(1);
        }

        public bool Get()
        {
            try
            {
                Group oGroup = this.List().First();

                this.Name = oGroup.Name;
                this.Prefix = oGroup.Prefix;
                this.Active = oGroup.Active;

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
        public List<Group> List()
        {
            return this.AccessMsSql.Pos.Listgroup.ExeList<Group>(this.Id, this.Name, this.Prefix);
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
                    this.AccessMsSql.Pos.Updategroup.ExeScalar<int>(this.Id, this.Name, this.Prefix, this.Active);
                }
                else
                {
                    this.Id = this.AccessMsSql.Pos.Addgroup.ExeScalar<int>(this.Name, this.Prefix);
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
                this.AccessMsSql.Pos.Deletegroup.ExeNonQuery(this.Id);

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
