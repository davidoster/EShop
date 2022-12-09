namespace EFProjectCodeFirst1.Migrations
{
    using DatabaseFirst_Initial.Models;
    using EFProjectCodeFirst1.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Runtime.Remoting.Contexts;

    internal sealed class Configuration : DbMigrationsConfiguration<EFProjectCodeFirst1.Services.Data.AppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFProjectCodeFirst1.Services.Data.AppDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // Add some ProductCategories
            if (context.ProductCategories.Where(pc => pc.Title == "Pen").Count() == 0 &&
                context.ProductCategories.Where(pc => pc.Title == "Pencil").Count() == 0 &&
                context.ProductCategories.Where(pc => pc.Title == "Color Pen").Count() == 0 &&
                context.ProductCategories.Where(pc => pc.Title == "Rubbed Eraser").Count() == 0)
            {
                // Update
                //var pcPen = context.ProductCategories.Where(pc => pc.Title == "Pen").SingleOrDefault();
                //pcPen.Title = "Pen New";
                //context.ProductCategories.AddOrUpdate(pcPen);
                
                // Add
                context.ProductCategories.Add(new ProductCategory
                            { Title = "Pen", Description = "A Pen" });
                context.ProductCategories.Add(new ProductCategory 
                            { Title = "Pencil", Description = "A Pencil" });
                context.ProductCategories.Add(new ProductCategory 
                            { Title = "Color Pen", Description = "A Colored Pen" });
                context.ProductCategories.Add(new ProductCategory 
                            { Title = "Rubbed Eraser", Description = "A Rubbed Eraser" });
                context.SaveChanges();
            }

            // Add some Products
            try
            {
                if(context.Products.Where(p => p.Title == "Awesome Pen" ).Count() == 0 &&
                   context.Products.Where(p => p.Title == "Awesome Pencil").Count() == 0 &&
                   context.Products.Where(p => p.Title == "Awesome Color Pen").Count() == 0 &&
                   context.Products.Where(p => p.Title == "Awesome Rubbed Eraser").Count() == 0)
                {
                    Console.WriteLine("Creating products...");
                    var pCategory = context.ProductCategories.Where(productCategory => productCategory.Title == "Pen")
                                                             .SingleOrDefault();
                    context.Products.AddOrUpdate(new Product
                    {
                        Title = "Awesome Pen",
                        Description = "Awesome Pen description",
                        Price = 28,
                        Category = pCategory,
                        //ProductCategoryId = pCategory.Id
                    });

                    pCategory = context.ProductCategories.Where(productCategory => productCategory.Title == "Pencil")
                                                             .SingleOrDefault();
                    context.Products.AddOrUpdate(new Product
                    {
                        Title = "Awesome Pencil",
                        Description = "Awesome Pencil description",
                        Price = 20,
                        Category = pCategory,
                        //ProductCategoryId = pCategory.Id
                    });

                    pCategory = context.ProductCategories.Where(productCategory => productCategory.Title == "Color Pen")
                                                             .SingleOrDefault();
                    context.Products.AddOrUpdate(new Product
                    {
                        Title = "Awesome Color Pen",
                        Description = "Awesome Color Pen description",
                        Price = 32,
                        Category = pCategory,
                        //ProductCategoryId = pCategory.Id
                    });

                    pCategory = context.ProductCategories.Where(productCategory => productCategory.Title == "Rubbed Eraser")
                                                             .SingleOrDefault();
                    context.Products.AddOrUpdate(new Product
                    {
                        Title = "Awesome Rubbed Eraser",
                        Description = "Awesome Rubbed Eraser description",
                        Price = 9,
                        Category = pCategory,
                        //ProductCategoryId = pCategory.Id
                    });
                }
                context.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine("Already existed Products");
                Console.WriteLine(e.InnerException.InnerException.Message);
            }
            finally
            {
                Console.WriteLine("Are we done yet?");
            }

            // Add some Customers
            try
            {
                if (context.Customers.Where(c => c.Email == "paspa@hotmail.com").Count() == 0 &&
                    context.Customers.Where(c => c.Email == "paspabill@hotmail.com").Count() == 0)
                {
                    context.Customers.AddOrUpdate(new Customer
                    {
                        Name = "George Pasparakis",
                        Email = "paspa@hotmail.com",
                        PhoneNumber = "+306977649229"
                    });

                    context.Customers.AddOrUpdate(new Customer
                    {
                        Name = "Bill Pasparakis",
                        Email = "paspabill@hotmail.com",
                        PhoneNumber = "+306978649229"
                    });
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //Console.WriteLine("Already existed Customers");
                //Console.WriteLine(e.InnerException.InnerException.Message);
            }
            finally
            {
                Console.WriteLine("Are the customers inserted?");
            }

            // Add some CustomerOrders
            // Get some Customers
            var customerGeorge = context.Customers.Where(c => c.Email == "paspa@hotmail.com").SingleOrDefault();
            var customerBill = context.Customers.Where(c => c.Name.StartsWith("Bill Pas")).SingleOrDefault();
            
            // Get some Products
            var productPen = context.Products.Where(p => p.Title == "Awesome Pen").SingleOrDefault();
            var productPencil = context.Products.Where(p => p.Title == "Awesome Pencil").SingleOrDefault();

            // Add the sample Orders for these customers
            var finalProductPrice = productPen.Price + 22;
            var finalProductQuantity = 4;
            context.CustomerOrders.AddOrUpdate(new Order
            {
                Customer = customerGeorge,
                OrderDate = DateTime.Now,
                ProductPrice = finalProductPrice,
                ProductQuantity = finalProductQuantity,
                TotalPrice = finalProductPrice * finalProductQuantity,
                Product = productPen
            });
            
            finalProductPrice = productPencil.Price + 22;
            finalProductQuantity = 4;
            context.CustomerOrders.AddOrUpdate(new Order
            {
                Customer = customerBill,
                OrderDate = DateTime.Now,
                ProductPrice = finalProductPrice,
                ProductQuantity = finalProductQuantity,
                TotalPrice = finalProductPrice * finalProductQuantity,
                Product = productPencil
            }); 
        }
    }
}
