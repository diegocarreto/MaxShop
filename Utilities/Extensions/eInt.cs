using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Extensions
{
    public static class eInt
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ColumnNumber"></param>
        /// <returns></returns>
        public static string GetExcelColumnName(this int ColumnNumber)
        {
            int dividend = ColumnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }
    }
}
