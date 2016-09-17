using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Provider : EntityBase
    {
        #region Members
        #endregion

        #region Properties

        public string Address { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string Email { get; set; }

        #endregion

        #region Builder

        public Provider()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Provider> List()
        {
            return this.AccessMsSql.Pos.Listprovider.ExeList<Provider>(this.Id, this.Name);
        }

        #endregion
    }
}
