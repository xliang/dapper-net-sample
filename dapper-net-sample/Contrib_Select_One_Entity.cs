using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using dapper_net_sample.Entity;
using dapper_net_sample.Utility;

namespace dapper_net_sample
{
    public class Contrib_Select_One_Entity
    {
        public static void Main()
        {
            using (var sqlConnection = new SqlConnection(Constant.DatabaseConnection))
            {
                sqlConnection.Open();

                var result = sqlConnection.Get<Supplier>(9); 

                ObjectDumper.Write(result);
            }
        }
            
    }
}