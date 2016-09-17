using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public string Settings(string Name)
        {
            try
            {
                var settings = GetConfiguration().AppSettings;

                return settings.Settings[Name].Value;
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public string ConnectionString(string Name)
        {
            try
            {
                var connectionStrings = GetConfiguration().ConnectionStrings;

                return connectionStrings.ConnectionStrings[Name].ToString();
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Configuration  GetConfiguration()
        {
            string assemblyPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath.Replace("%20"," ").Replace("/", "\\");

            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = assemblyPath + ".config";

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            return ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None); 
        }
    }
}
