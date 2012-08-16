using Dapper.Contrib.Extensions;

namespace dapper_net_sample.Entity
{
    // property data type should match exactly with defined in sql server database. 
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int SupplierID { get; set; }

        public int CategoryID { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
        
        // reference 
        public Supplier Supplier { get; set; }
    }
}