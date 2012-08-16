using System.Configuration;

namespace dapper_net_sample.Utility
{
    public class Constant
    {
        public static string DatabaseConnection = 
            ConfigurationManager.ConnectionStrings["database-connection-2"].ConnectionString; 
    }
}