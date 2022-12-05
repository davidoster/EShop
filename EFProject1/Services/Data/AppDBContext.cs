using DatabaseFirst_Initial.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject1.Services.Data
{
    internal class AppDBContext : DbContext
    {
        // brings inside C# (via EF) the table ProductCategories
        public DbSet<ProductCategory> ProductCategories { get; set; } // EAGER LOADING
        //public virtual DbSet<ProductCategory> ProductCategories2 { get; set; } // LAZY LOADING
        
        public AppDBContext() : base("name=MyConnectionString")
        {

        }
    }
}
