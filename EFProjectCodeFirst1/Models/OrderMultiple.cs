
using DatabaseFirst_Initial.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProjectCodeFirst1.Models
{
    [Table("CustomerOrdersMultipleProducts")]
    internal class OrderMultiple
    {
        [Key]
        public int CustomerOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public ICollection<ProductData> ProductData { get; set; }
        public Customer Customer { get; set; } 
    }

    internal class ProductData
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }
    }
}
