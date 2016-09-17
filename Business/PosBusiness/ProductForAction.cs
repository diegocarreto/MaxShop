using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class ProductForAction
    {
        #region Members
        #endregion

        #region Properties

        public int Id { get; set; }

        public string Location { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public double Amount { get; set; }

        public decimal Unitary { get; set; }

        public string Freight { get; set; }

        public decimal Price { get; set; }

        public int? IdCompany { get; set; }
        
        #endregion

        #region Builder

        public ProductForAction()
        {
        }

        #endregion

        #region Methods
        #endregion
    }
}
