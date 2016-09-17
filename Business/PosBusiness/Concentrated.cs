using System;
using System.Collections.Generic;
using System.Linq;

namespace PosBusiness
{
    [Serializable]
    public class Concentrated : EntityBase
    {
        #region Members

        public bool ForReport { get; set; }

        public double Amount { get; set; }

        public string Type { get; set; }

        #endregion

        #region Properties
        #endregion

        #region Builder

        public Concentrated()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Concentrated> List(DateTime StartDate, DateTime FinishDate)
        {
            return this.AccessMsSql.Pos.Getconcentratedreport.ExeList<Concentrated>(null, StartDate, FinishDate);
        }

        #endregion
    }
}
