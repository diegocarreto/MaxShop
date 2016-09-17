using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Box : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        public int? IdSuperUser { get; set; }

        public int? IdUser { get; set; }

        public int? CashRegister { get; set; }

        public decimal Origin { get; set; }

        public decimal Obtained { get; set; }

        public decimal Total { get; set; }

        #endregion

        #region Builder

        public Box()
        {
        }

        #endregion

        #region Methods

        public bool Exist()
        {
            return this.AccessMsSql.Pos.Checkbox.ExeScalar<int>(this.IdUser, this.CashRegister).Equals(1);
        }

        public bool Get()
        {
            try
            {
                Box box = this.AccessMsSql.Pos.Getcurrentbox.ExeList<Box>(this.IdUser, this.CashRegister).First();

                this.Origin = box.Origin;
                this.Obtained = box.Obtained;
                this.Total = box.Total;

                return true;
            }
            catch (Exception ex)
            {
                this.SetError(ex);

                return false;
            }

        }

        public bool Open()
        {
            try
            {
                this.AccessMsSql.Pos.Openbox.ExeNonQuery(this.IdUser, this.CashRegister, this.Total);

                return true;
            }
            catch (Exception ex)
            {
                this.SetError(ex);

                return false;
            }
        }

        public bool Close()
        {
            try
            {
                this.AccessMsSql.Pos.Closebox.ExeNonQuery(this.IdUser, this.CashRegister, this.Total);

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
