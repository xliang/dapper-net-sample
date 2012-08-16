using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using dapper_net_sample.Entity;
using dapper_net_sample.Utility;

namespace dapper_net_sample
{
    public class Contrib_Update_Entity_Using_Tracking
    {
        public static void Main()
        {
            using (var sqlConnection = new SqlConnection(Constant.DatabaseConnection))
            {
                sqlConnection.Open();

                // using interface to track "Isdirty"
                var supplier = sqlConnection.Get<ISupplier>(9);
                //supplier.CompanyName = "Manning"; 

                // should return false, becasue there is no change. 
                ObjectDumper.Write(string.Format("Is Update {0}", sqlConnection.Update(supplier)));
                
                supplier.CompanyName = "Manning";

                // should return true
                ObjectDumper.Write(string.Format("Is Update {0}", sqlConnection.Update(supplier)));

            }
        }
    }
}