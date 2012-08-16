using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using dapper_net_sample.Utility;

namespace dapper_net_sample
{
    public class Core_Select_By_Dynamic
    {
        public static void Main()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["database-connection-2"].ConnectionString;

            using (var sqlConnection
                = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                IEnumerable<dynamic> products = sqlConnection
                    .Query<dynamic>("Select * from Products where Id = @Id",
                                    new {Id = 2});

                foreach (dynamic product in products)
                {
                    
                    ObjectDumper.Write(string.Format("{0}-{1}", product.Id, product.ProductName));
                }
            }
        }
    }
}