using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_Initial.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ProductCategory Category { get; set; }

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
