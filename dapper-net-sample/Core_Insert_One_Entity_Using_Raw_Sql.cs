using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using dapper_net_sample.Entity;
using dapper_net_sample.Utility;

namespace dapper_net_sample
{
    /// <summary>
    /// Insert object using default dapper implementation
    /// </summary>
    public class Core_Insert_One_Entity_Using_Raw_Sql
    {
        public static void Main()
        {
            using (var sqlConnection = new SqlConnection(Constant.DatabaseConnection))
            {
                sqlConnection.Open();

                var supplier = new Supplier()
                {
                    Address = "10 Main Street",
                    CompanyName = "ABC Corporation"
                };

                supplier.Id = sqlConnection.Query<int>(
                                    @"
                                        insert Suppliers(CompanyName, Address)
                                        values (@CompanyName, @Address)
                                        select cast(scope_identity() as int)
                                    ", supplier).First(); 



                sqlConnection.Close();

                Console.WriteLine(supplier.Id);

                Console.WriteLine("Done. ");
            }
        }
    }
}