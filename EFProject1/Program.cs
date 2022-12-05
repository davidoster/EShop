using DatabaseFirst_Initial.Models;
using EFProject1.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDBContext appDBContext = new AppDBContext();
            ProductCategory productCategory = new ProductCategory("Work Telephone XKB22-AN Pro", 
                "Pro Series of the most expensive telephone in house");
            Console.WriteLine($"productCategory(before): {productCategory}");
            
            // creates a new record
            ProductCategory productCategory2 = appDBContext.ProductCategories.Add(productCategory);
            
            // saves any pending changes
            appDBContext.SaveChanges();
            Console.WriteLine($"productCategory: {productCategory}");
            Console.WriteLine($"productCategory2: {productCategory2}");
            
            // changes the actual (for the GOD shake!!!!) OBJECT in C#
            // and then this is saved to DB!!!!!!
            productCategory.Description += " MAX TURBO EXTRA SUPER NICE!!";
            appDBContext.SaveChanges();

        }
    }
}
