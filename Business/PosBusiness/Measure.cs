using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Measure : EntityBase
    {
        #region Members
        #endregion

        #region Properties
        #endregion

        #region Builder

        public Measure()
        {
        }

        #endregion

        #region Methods

        public bool Exist()
        {
            return this.AccessMsSql.Pos.Existmeasure.ExeScalar<int>(this.Name).Equals(1);
        }

        public bool Get()
        {
            try
            {
                Measure oMeasure = this.List().First();

                this.Name = oMeasure.Name;
                this.Active = oMeasure.Active;

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
        public List<Measure> List()
        {
            return this.AccessMsSql.Pos.Listmeasure.ExeList<Measure>(this.Id, this.Name);
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
                    this.AccessMsSql.Pos.Updatemeasure.ExeScalar<int>(this.Id, this.Name, this.Active);
                }
                else
                {
                    this.Id = this.AccessMsSql.Pos.Addmeasure.ExeScalar<int>(this.Name, this.Active);
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
                this.AccessMsSql.Pos.Deletemeasure.ExeNonQuery(this.Id);

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
