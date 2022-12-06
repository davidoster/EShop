using DatabaseFirst_Initial.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProjectCodeFirst1.Services.Data
{
    internal class AppDBContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } // LAZY

        // Customer
        // Order

        public AppDBContext() : base("name=MyConnectionString")
        {
        }
    }
}
