using Microsoft.Extensions.Configuration;
using Shesha.FluentMigrator;

namespace Shesha.Tutorial
{
    /// <summary>
    /// Dbms configuration helper
    /// </summary>
    public static class DbmsHelper
    {
        /// <summary>
        /// Get current Dbms type
        /// </summary>
        public static DbmsType GetDbmsType(this IConfigurationRoot config) 
        {
            return config.GetValue("DbmsType", DbmsType.SQLServer);
        }

        /// <summary>
        /// Get default connection string
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static string GetDefaultConnectionString(this IConfigurationRoot config)
        {
            return config.GetConnectionString("Default");
        }        
    }
}
