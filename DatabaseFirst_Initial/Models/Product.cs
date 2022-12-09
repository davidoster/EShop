using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_Initial.Models
{
    [Table("CustomerProducts")]
    public class Product
    {
        //[Key] // annotations, decorators, attributes
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }

        [Required]
        //[ForeignKey("Id")]
        public ProductCategory Category { get; set; } // FK // ONE ProductCategory TO MANY Product (s)
        //public int ProductCategoryId { get; set; } // DON'T DO THIS for EF!!!!

        public Product()
        {

        }
        public Product(string title, string description, double price, ProductCategory category)
        {
            Title = title;
            Description = description;
            Price = price;
            Category = category;
        }
        public Product(int id, string title, string description, double price, ProductCategory category)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}
