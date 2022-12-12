using DatabaseFirst_Initial.Models;
using EFProjectCodeFirst1.Models;
using EFProjectCodeFirst1.Services;
using EFProjectCodeFirst1.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EFProjectCodeFirst1
{
    internal class Program
    {
        delegate double AddProductData(ProductData productData);
        static void Main(string[] args)
        {
            //AppDBContext appDBContext = new AppDBContext();
            //appDBContext.ProductCategories.Add(new ProductCategory { Title = "Pen", Description = "A Pen" });
            //appDBContext.ProductCategories.Add(new ProductCategory { Title = "Pencil", Description = "A Pencil" });
            //appDBContext.ProductCategories.Add(new ProductCategory { Title = "Color Pen", Description = "A Colored Pen" });
            //appDBContext.ProductCategories.Add(new ProductCategory { Title = "Rubbed Eraser", Description = "A Rubbed Eraser" });
            //appDBContext.SaveChanges();

            //var productCategory = appDBContext.ProductCategories.Find(3);
            //Console.WriteLine(productCategory);
            //appDBContext.Products.Add(
            //    new Product("Blue Parker", "Blue Parker Description", 19.22, productCategory));
            //appDBContext.SaveChanges();

            //appDBContext.Products.Add(
            //new Product
            //{
            //    Title = "Awesome Pencil",
            //    Description = "Awesome Pencil description",
            //    Price = 20,
            //    Category = new ProductCategory { Title = "Awesome Pencils", Description = "Awesome Pencils" }
            //});
            //appDBContext.SaveChanges();

            //appDBContext.Products.Add(
            //    new Product
            //    {
            //        Title = "Awesome Pencil 2",
            //        Description = "Awesome Pencil description",
            //        Price = 20,
            //        Category = 
            //            appDBContext.ProductCategories.Where(productCategory => 
            //            productCategory.Title == "Awesome Pencils" && productCategory.Description == "").SingleOrDefault()
            //    });

            //appDBContext.SaveChanges();

            // Query Syntax
            //var pCA = (from productCategory in appDBContext.ProductCategories
            //           where productCategory.Title == "Awesome Pencils"
            //           select productCategory).ElementAtOrDefault(0);

            //// Method Syntax
            //var pCB = appDBContext.ProductCategories.Where(productCategory =>
            //            productCategory.Title == "Awesome Pencils").SingleOrDefault();

            //Console.WriteLine(pCA == pCB);


            //var productPen = appDBContext.Products.Where(p => p.Title == "Awesome Pen").SingleOrDefault();
            //appDBContext.Entry(productPen).Reference(p => p.Category).Load();
            //Console.WriteLine(productPen.Category.Id);
            //var productPencil = appDBContext.Products.Where(p => p.Title == "Awesome Pencil").SingleOrDefault();
            //appDBContext.Entry(productPencil).Reference(p => p.Category).Load();
            //Console.WriteLine(productPencil.Category.Id);

            //var customerGeorge = appDBContext.Customers.Where(c => c.Email.Contains("paspa@hotmail.com")).SingleOrDefault();
            //var listOfProductData = new List<ProductData>();
            //listOfProductData.Add(new ProductData { Price = 15, Quantity = 12, Product = productPen });
            //listOfProductData.Add(new ProductData { Price = 9, Quantity = 7, Product = productPencil });

            //double AddData(ProductData pData) { return pData.Price * pData.Quantity; }
            //double AddData2(ProductData pData) { return (pData.Price * pData.Quantity) * 0.25; }
            //AddProductData ProductDataSum = AddData;
            //ProductDataSum = AddData2;

            //OrderService orderService1 = new OrderService();
            //orderService1.AddMultipleProductsOrder(appDBContext, customerGeorge, listOfProductData); // Order Service without Generics
            //appDBContext.OrderMultiples.Add(new Models.OrderMultiple
            //{
            //    Customer = customerGeorge,
            //    OrderDate = DateTime.Now,
            //    ProductData = listOfProductData,
            //    TotalPrice = listOfProductData.Sum(x => x.Price * x.Quantity)
            //    //TotalPrice = listOfProductData.Sum(x => ProductDataSum(x))  // 180 + 63 // (15 * 12) + (9 * 7)
            //});
            //appDBContext.SaveChanges();

            //var productCategory = appDBContext.ProductCategories.Find(3); // Color Pen
            //OrderService<Order> orderServiceSingle = new OrderService<Order>();
            //orderServiceSingle.AddOrder(appDBContext, customerGeorge, 
            //    new Product("Yellow Parker", "Yellow Parker Description", 19.22, productCategory));

            //listOfProductData = new List<ProductData>();
            //listOfProductData.Add(new ProductData { Price = 32, Quantity = 5, Product = productPen });
            //listOfProductData.Add(new ProductData { Price = 40, Quantity = 9, Product = productPen });
            try
            {
                OrderService<OrderMultiple> orderServiceMultiple = new OrderService<OrderMultiple>();
                var listOfProductData = new List<ProductData>();
                listOfProductData.Add(new ProductData { Price = 32, Quantity = 5, Product = new Product("Pink Parker", "Pink Parker Description", 22.22, orderServiceMultiple.context.ProductCategories.Find(3)) });
                listOfProductData.Add(new ProductData { Price = 40, Quantity = 9, Product = new Product("Fuchsia Parker", "Fuchsia Parker Description", 23.22, orderServiceMultiple.context.ProductCategories.Find(3)) });
                var orderMultiple = orderServiceMultiple.AddOrder(orderServiceMultiple.context.Customers.Find(1), listOfProductData);
                var customer = orderServiceMultiple.context.Customers.Find(2);
                orderServiceMultiple.UpdateOrder(orderMultiple.CustomerOrderId, customer); // this UpdateOrder changes the Customer of the order
            }
            catch (DBServerConnectionErrorException e)
            {
                Console.WriteLine(e.Message);
            }
            //orderServiceMultiple.AddOrder(appDBContext, customerGeorge, listOfProductData);

            

            Console.ReadKey();
        }
    }
}
