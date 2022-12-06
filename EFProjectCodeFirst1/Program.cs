using DatabaseFirst_Initial.Models;
using EFProjectCodeFirst1.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProjectCodeFirst1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDBContext appDBContext = new AppDBContext();
            appDBContext.ProductCategories.Add(new ProductCategory { Title = "Pen", Description = "A Pen" });
            //appDBContext.SaveChanges();
            appDBContext.Products.Add(
                new Product("Parker", "Parker Description", 19.22, 
                appDBContext.ProductCategories.Find(1)));
            appDBContext.SaveChanges(); 
        }
    }
}
