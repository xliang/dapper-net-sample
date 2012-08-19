using System.Data.SqlClient;
using Dapper; 
using dapper_net_sample.Utility;

namespace dapper_net_sample
{
    public class Core_Update_Item
    {
        public static void Main()
        {
            using (var sqlConnection = new SqlConnection(Constant.DatabaseConnection))
            {
                sqlConnection.Open();

                var updateStatement = @"Update Products Set UnitPrice = @UnitPrice
                                        Where Id = @ProductId
                                        ";

                sqlConnection.Execute(updateStatement, new
                                                           {
                                                               UnitPrice = 100.0m,
                                                               ProductId = 50
                                                           });
                sqlConnection.Close();
            }
        }
    }
}