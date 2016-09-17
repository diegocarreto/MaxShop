using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class TelephoneRecharge : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        public string Phone { get; set; }

        public string Folio { get; set; }

        public string CompanyName { get; set; }

        public decimal? Amount { get; set; }

        public string Plan { get; set; }

        public bool? Successful { get; set; }

        public string Message { get; set; }

        #endregion

        #region Builder

        public TelephoneRecharge()
        {
        }

        #endregion

        #region Methods

        public List<TelephoneRecharge> List()
        {
            return this.AccessMsSql.Pos.Listtelephonerecharge.ExeList<TelephoneRecharge>(null, this.Phone);
        }

        public int Save()
        {
            try
            {
                return this.AccessMsSql.Pos.Addtelephonerecharge.ExeScalar<int>(this.Phone, this.Folio, this.CompanyName, this.Plan, this.Amount, this.Successful, this.Message);
            }
            catch
            {
                return 0;
            }
        }

        #endregion
    }
}
