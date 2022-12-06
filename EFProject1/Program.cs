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
            new ProductCategory() { Id = 115, Title = "asdasd", Description = "sdfsdf" };

            // anonymous object
            var myAnon = new { Id = 115, Title = "ASDASD", Description = "sdfsdasd" };
            Console.WriteLine(myAnon.Id);


            AppDBContext appDBContext = new AppDBContext(); // SqlConnection.Open()
            
            // CREATE
            // creates a new record
            ProductCategory productCategory2 = appDBContext.ProductCategories.Add(new ProductCategory("Work Telephone XKB22-AN Pro",
                "Pro Series of the most expensive telephone in house"));
            // object of a model productCategory becomes an entity == has a record in a db table

            // saves any pending changes
            appDBContext.SaveChanges();
            Console.WriteLine($"productCategory2 after add: {productCategory2}");

            // UPDATE
            // changes the actual (for the GOD shake!!!!) OBJECT in C#
            // and then this is saved to DB!!!!!!
            productCategory2.Description += " MAX TURBO EXTRA SUPER NICE!!";
            appDBContext.SaveChanges();

            // DELETE (REMOVE)
            // deletes an entity - must already exists
            var pd3 = appDBContext.ProductCategories.Remove(productCategory2);
            // can I undo the marking of deletion???
            appDBContext.Entry(productCategory2).State = System.Data.Entity.EntityState.Unchanged;
            appDBContext.Entry<ProductCategory>(productCategory2).State = System.Data.Entity.EntityState.Unchanged;
            appDBContext.SaveChanges();
            Console.WriteLine($"deleted???: {appDBContext.ProductCategories.Find(productCategory2.Id)}");
            // what happens when I try to remove a non entity
            //try
            //{
            //    ProductCategory productCategory = new ProductCategory("Work Telephone XKB22-AN Pro",
            //            "Pro Series of the most expensive telephone in house"); // an object typeof(ProductCategory)
            //    appDBContext.ProductCategories.Remove(productCategory);
            //    appDBContext.SaveChanges();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            // READ a single row / record based on its PK
            Console.WriteLine(appDBContext.ProductCategories.Find(115)); // find an entity by Id(PK) NEEDS default ctor
            //Console.WriteLine(appDBContext.ProductCategories.ElementAt(0));

            // READ THE WHOLE LOT
            // LINQ QUERY SYNTAX
            var allProductCategories = (from productCategory in appDBContext.ProductCategories
                                       select productCategory).ToList<ProductCategory>();
            //foreach (var item in allProductCategories)
            //{
            //    Console.WriteLine(item);
            //}
            
            // LINQ METHOD SYNTAX
            var allProductCategories2 = appDBContext.ProductCategories.ToList<ProductCategory>(); 
            
            Console.WriteLine("---------------------------------------------------------------");
            //foreach (var item in allProductCategories2)
            //{
            //    Console.WriteLine(item);
            //}

            // Find with Title = "Pana"
            //var productCategoriesWithPana = from p in appDBContext.ProductCategories
            //                                where p.Title == "Pana"
            //                                select new { p.Title, p.Description };
            //foreach (var item in productCategoriesWithPana)
            //{
            //    Console.WriteLine(item);
            //}

            // Find with Title LIKE "Pana%"
            var productCategoriesWithPana2 = from p in appDBContext.ProductCategories
                                             where p.Title.StartsWith("Pana") // Contains %Pana%, StartsWith Pana%, EndsWith %Pana
                                             select new { p.Title, p.Description };
            foreach (var item in productCategoriesWithPana2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
