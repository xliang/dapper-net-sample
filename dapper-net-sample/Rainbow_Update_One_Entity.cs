using System;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using dapper_net_sample.Utility;

namespace dapper_net_sample
{
    public class Rainbow_Update_One_Entity
    {
        public static void Main()
        {
             string connectionString = ConfigurationManager.ConnectionStrings["database-connection-2"].ConnectionString;

             using (var sqlConnection
                         = new SqlConnection(connectionString))
             {
                 sqlConnection.Open();
                 
                 var db = NorthwindDatabase.Init(sqlConnection, commandTimeout: 3);

                 var supplier = db.Suppliers.Get(9);

                 // snapshotter tracks which fields change on the object 

                 var s = Snapshotter.Start(supplier);

                 supplier.CompanyName += "_" + Guid.NewGuid().ToString().Substring(1, 4);

                 db.Suppliers.Update(9, s.Diff());

                 // reload it from database 
                 supplier = db.Suppliers.Get(9);

                 ObjectDumper.Write(supplier);
             }

        }
    }
}