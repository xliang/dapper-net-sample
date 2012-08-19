using System;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using dapper_net_sample.Entity;
using dapper_net_sample.Utility;

namespace dapper_net_sample
{
    public class Core_Insert_One_Entity_Using_Sql_Extension
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
                    CompanyName = "DEF Corporation"
                };

                sqlConnection.Execute(
                                    @"
                                       insert Suppliers(CompanyName, Address)
                                       values (@CompanyName, @Address)
                                    ",
                    supplier); 

                sqlConnection.Close();

                Console.WriteLine("Done. ");
            }
        }
    }
}