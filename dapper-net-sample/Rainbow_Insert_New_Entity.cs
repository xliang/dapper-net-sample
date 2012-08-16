using System;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using dapper_net_sample.Entity;

namespace dapper_net_sample
{
    public class Rainbow_Insert_New_Entity
    {
        public static void Main()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["database-connection-2"].ConnectionString;

            using (var sqlConnection
                = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                var db = NorthwindDatabase.Init(sqlConnection, commandTimeout: 2);
                int? supplierId = db.Suppliers.Insert(new
                                                          {
                                                              CompanyName = Guid.NewGuid().ToString()

                                                          });
                Console.WriteLine(string.Format("New Supplier Id is {0}", supplierId.Value));

            }
        }
    }

    public class NorthwindDatabase : Database<NorthwindDatabase>
    {
        public Table<Supplier> Suppliers { get; set;  } 
    }
}