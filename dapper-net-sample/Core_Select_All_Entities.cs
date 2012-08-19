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
            using (var sqlConnection = new SqlConnection(Constant.DatabaseConnection))
            {
                sqlConnection.Open();
                IEnumerable<Product> products = 
                    sqlConnection.Query<Product>("Select * from Products");

                foreach (Product product in products)
                {
                    ObjectDumper.Write(product);
                }
            }
        }
    }
}