
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
    [Table("CustomerOrders")]
    internal class Order
    {
        [Key]
        public int CustomerOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }  

    }
}
