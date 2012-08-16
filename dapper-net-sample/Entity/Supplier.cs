using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace dapper_net_sample.Entity
{
    public interface ISupplier
    {
        [Key]
        int Id { get; set; }

        string CompanyName { get; set; }
        string ContactName { get; set; }
        string ContactTitle { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string PostalCode { get; set; }
        string Country { get; set; }
        IEnumerable<Product> Products { get; set; } 
    }

    public class Supplier : ISupplier
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public IEnumerable<Product> Products { get; set;  }  
    }
}