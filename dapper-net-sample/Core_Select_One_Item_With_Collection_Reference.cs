using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using dapper_net_sample.Entity;
using dapper_net_sample.Extension; 
namespace dapper_net_sample
{
    /// <summary>
    /// query one to many items
    /// </summary>
    public class Core_Select_One_Item_With_Collection_Reference
    {
        public static void Main()
        {
            var suppliers = QuerySupplier();

            foreach (var supplier in suppliers)
            {
                var products = supplier.Products.ToList();

                Console.WriteLine(products.Count);
            }
        }

        private static IEnumerable<Supplier> QuerySupplier()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["database-connection-2"].ConnectionString;

            
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                var query =
                    @"
                                SELECT * FROM dbo.Suppliers WHERE ContactName = 'Charlotte Cooper'

                                SELECT * FROM dbo.Products WHERE SupplierID IN (SELECT Id FROM dbo.Suppliers WHERE ContactName = 'Charlotte Cooper')
                            ";

                return sqlConnection
                    .QueryMultiple(query).Map<Supplier, Product, int>(supplier => supplier.Id,
                                                                      product => product.SupplierID,
                                                                      (supplier, products) => { supplier.Products = products; });
            }
            
        }
    }
}