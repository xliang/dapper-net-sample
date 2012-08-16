using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using dapper_net_sample.Entity;
using dapper_net_sample.Utility;

namespace dapper_net_sample
{
    /// <summary>
    /// Select entity object by Id
    /// </summary>
    public class Core_Select_One_Item
    {
        public static void Main()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["database-connection-2"].ConnectionString;

            using (var sqlConnection
                = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                IEnumerable<Product> products = sqlConnection
                    .Query<Product>("Select * from Products where Id = @ProductId",
                                    new {ProductID = 2});

                foreach (Product product in products)
                {
                    ObjectDumper.Write(product);
                }
            }
        }
    }
}