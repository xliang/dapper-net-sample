using System.Data.SqlClient;
using Dapper;
using dapper_net_sample.Utility;

namespace dapper_net_sample
{
    class Contrib_SqlBuilder
    {
        public static void Main()
        {
            using (var sqlConnection = new SqlConnection(Constant.DatabaseConnection))
            {
                sqlConnection.Open();
                var builder = new SqlBuilder();

                // /**select**/  -- has to be low case
                var selectSupplierIdBuilder = builder.AddTemplate("Select /**select**/ from Suppliers /**where**/ ");
                builder.Select("Id");
                builder.Where("City = @City", new { City = "Tokyo"}); // pass an anonymous object 

                var supplierIds = sqlConnection.Query<int>(selectSupplierIdBuilder.RawSql,
                                                           selectSupplierIdBuilder.Parameters);
                
                ObjectDumper.Write(supplierIds);

                sqlConnection.Close();
                
            }
            
            


        }
    }
}
