using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using dapper_net_sample.Entity;
using dapper_net_sample.Extension;
using dapper_net_sample.Utility;

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
           using (var sqlConnection = new SqlConnection(Constant.DatabaseConnection))
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