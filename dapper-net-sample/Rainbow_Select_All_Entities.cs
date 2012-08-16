using System.Configuration;
using System.Data.SqlClient;
using dapper_net_sample.Utility;

namespace dapper_net_sample
{
    public class Rainbow_Select_All_Entities
    {
        public static void Main()
        {
             string connectionString = ConfigurationManager.ConnectionStrings["database-connection-2"].ConnectionString;

             using (var sqlConnection = new SqlConnection(connectionString))
             {
                 sqlConnection.Open();

                 var db = NorthwindDatabase.Init(sqlConnection, commandTimeout: 2);
                 
                 var result = db.Suppliers.All();

                 foreach (var supplier in result)
                 {
                     ObjectDumper.Write(supplier);
                 }

             }
            
            
        }
    }
}