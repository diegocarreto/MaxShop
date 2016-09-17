using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Budgetary : EntityBase
    {
        #region Members
        #endregion

        #region Properties
        #endregion

        #region Builder

        public Budgetary()
        {
        }

        #endregion

        #region Methods

        public bool Charge(List<ProductForAction> Products, string Cliente)
        {
            try
            {
                double total = (double)Products.Sum(item => item.Price);

                if (!total.Equals(0))
                {
                    this.Id = this.AccessMsSql.Pos.Addbudgetary.ExeScalar<int>(total, Cliente);

                    foreach (ProductForAction p in Products)
                    {
                        this.AccessMsSql.Pos.Adddetailbudgetary.ExeNonQuery(this.Id, p.Id, (double)p.Amount, p.Unitary, p.Price);
                    }

                    return true;
                }
                else
                {
                    this.ErrorMessage = "La Cotización no puedo ser por importe $0.00 ó cero productos.";

                    return false;
                }
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;

                return false;
            }
        }

        #endregion
    }
}
