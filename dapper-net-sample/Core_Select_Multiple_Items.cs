using System;
using System.Data.SqlClient;
using System.Linq;
using dapper_net_sample.Entity;
using dapper_net_sample.Utility;
using Dapper;
using dapper_net_sample.Extension; 

namespace dapper_net_sample
{
    public class Core_Select_Multiple_Items
    {
         public static void Main()
         {
             using (var sqlConnection = new SqlConnection(Constant.DatabaseConnection))
             {
                 sqlConnection.Open();

                 var query = @"
                            SELECT * FROM dbo.Suppliers WHERE Id = @Id

                            SELECT * FROM dbo.Products WHERE SupplierID = @Id

                              ";

                 // return a GridReader
                 using (var result = sqlConnection.QueryMultiple(query, new {Id = 1}))
                 {
                     var supplier = result.Read<Supplier>().Single();
                     var products = result.Read<Product>().ToList();

                     ObjectDumper.Write(supplier);

                     Console.WriteLine(string.Format("Total Products {0}", products.Count));
                     
                     ObjectDumper.Write(products);
                 }
 
             }
         }
    }
}