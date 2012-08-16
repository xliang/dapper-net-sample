using System;
using System.Configuration;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using dapper_net_sample.Entity;
using dapper_net_sample.Utility;

namespace dapper_net_sample
{
    public class Contrib_Insert_One_Entity
    {
        public static void Main()
        {
            using (var sqlConnection
                        = new SqlConnection(Constant.DatabaseConnection))
            {
                sqlConnection.Open();

                var supplier = new Supplier()
                                   {
                                       Address = "10 Main Street",
                                       CompanyName = "ABC Corporation"
                                   };

                var supplierId = sqlConnection.Insert<Supplier>(supplier); 

                sqlConnection.Close();

                Console.WriteLine(string.Format("New Supplier Id is {0}", supplierId));

                Console.WriteLine("Done. ");
            }
        }
    }
}