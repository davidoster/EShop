using DatabaseFirst_Initial.Models;
using EFProjectCodeFirst1.Models;
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
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> CustomerOrders { get; set; }

        public virtual DbSet<SomeTable> SomeTables { get; set; }

        // Customer
        // Order

        public AppDBContext() : base("name=MyConnectionString")
        {
            Configuration.LazyLoadingEnabled = false; // does it really work??? and how?
        }
    }
}
