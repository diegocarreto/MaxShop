using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Freight : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        public int? IdPm { get; set; }

        public int? IdDestination { get; set; }

        public decimal? Cost { get; set; }

        public double? Max { get; set; }

        public double? Min { get; set; }

        #endregion

        #region Builder

        public Freight()
        {
        }

        #endregion

        #region Methods

        public bool Exist()
        {
            return this.AccessMsSql.Pos.Existfreight.ExeScalar<int>(this.IdPm, this.IdDestination).Equals(1);
        }

        public bool Get()
        {
            try
            {
                Freight freight = this.List().First();

                this.IdPm = freight.IdPm;
                this.IdDestination = freight.IdDestination;
                this.Cost = freight.Cost;
                this.Max = freight.Max;
                this.Min = freight.Min;
                this.Active = freight.Active;

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
        public List<Freight> ListDestination()
        {
            return this.AccessMsSql.Pos.Listdestination.ExeList<Freight>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Freight> List()
        {
            return this.AccessMsSql.Pos.Listfreight.ExeList<Freight>(this.Id, this.IdPm);
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
                    this.AccessMsSql.Pos.Updatefreight.ExeScalar<int>(this.Id, this.IdPm, this.IdDestination, this.Cost, this.Min, this.Max, this.Active);
                }
                else
                {
                    this.Id = this.AccessMsSql.Pos.Addfreight.ExeScalar<int>(this.IdPm, this.IdDestination, this.Cost, this.Min, this.Max, this.Active);
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
                this.AccessMsSql.Pos.Deletefreight.ExeNonQuery(this.Id);

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