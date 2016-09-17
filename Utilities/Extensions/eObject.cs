using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Extensions
{
    public static class eObject
    {
        /// <summary>
        /// Obtiene el valor del AppSetting indicado de la aplicacion actual.
        /// </summary>
        /// <param name="pg">Objeto.</param>
        /// <param name="SettingName">Nombre del AppSetting.</param>
        /// <returns></returns>
        public static T AppSet<T>(this Object obj, String SettingName)
        {
            if (ConfigurationManager.AppSettings[SettingName] != null)
                return (T)Convert.ChangeType(ConfigurationManager.AppSettings[SettingName], typeof(T));
            else
                return default(T);
        }

        public static List<T> ToList<T>(this T Obj)
        {
            List<T> newList = new List<T>();

            return newList;
        }
    }
}
