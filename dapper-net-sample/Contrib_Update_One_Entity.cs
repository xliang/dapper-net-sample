using System.Data.SqlClient;
using Dapper.Contrib;
using Dapper.Contrib.Extensions; 
using dapper_net_sample.Entity;
using dapper_net_sample.Utility;

namespace dapper_net_sample
{
    public class Contrib_Update_One_Entity
    {
        public static void Main()
        {
            using (var sqlConnection = new SqlConnection(Constant.DatabaseConnection))
            {
                sqlConnection.Open();

                var entity = sqlConnection.Get<Supplier>(9);
                entity.ContactName = "John Smith"; 

                sqlConnection.Update<Supplier>(entity);

                var result = sqlConnection.Get<Supplier>(9);

                ObjectDumper.Write(result.ContactName);
            }
        }
    }
}