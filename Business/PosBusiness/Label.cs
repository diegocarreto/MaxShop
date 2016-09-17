using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Label : EntityBase
    {
        #region Members
        #endregion

        #region Properties
        #endregion

        #region Builder

        public Label()
        {
        }

        #endregion

        #region Methods

        public bool Exist()
        {
            return this.AccessMsSql.Pos.Existlabel.ExeScalar<int>(this.Name).Equals(1);
        }

        public bool Get()
        {
            try
            {
                Label label = this.List().First();

                this.Name = label.Name;
                this.Active = label.Active;

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
        public List<Label> List()
        {
            return this.AccessMsSql.Pos.Listlabel.ExeList<Label>(this.Id, this.Name);
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
                    this.AccessMsSql.Pos.Updatelabel.ExeScalar<int>(this.Id, this.Name, this.Active);
                }
                else
                {
                    this.Id = this.AccessMsSql.Pos.Addlabel.ExeScalar<int>(this.Name, this.Active);
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
                this.AccessMsSql.Pos.Deletelabel.ExeNonQuery(this.Id);

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
