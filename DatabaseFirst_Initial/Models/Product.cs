using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_Initial.Models
{
    public class Product
    {
        //[Key] // annotations, decorators, attributes
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
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
