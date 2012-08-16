using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using dapper_net_sample.Entity;
using dapper_net_sample.Utility;

namespace dapper_net_sample
{
    internal class Core_Select_All_Entities
    {
        public static void Main()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["database-connection-2"].ConnectionString;

            using (var sqlConnection
                = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                IEnumerable<Product> products = sqlConnection.Query<Product>("Select * from Products");

                foreach (Product product in products)
                {
                    ObjectDumper.Write(product);
                }
            }
        }
    }
}