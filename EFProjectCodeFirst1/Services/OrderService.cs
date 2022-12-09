using DatabaseFirst_Initial.Models;
using EFProjectCodeFirst1.Models;
using EFProjectCodeFirst1.Services.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EFProjectCodeFirst1.Services
{
    internal class OrderService
    {

        public void AddSingleProductOrder(AppDBContext context, Customer customer, Product product)
        {
            
            var finalProductPrice = product.Price + 22;
            var finalProductQuantity = 4;
            context.CustomerOrders.AddOrUpdate(new Order
            {
                Customer = customer,
                OrderDate = DateTime.Now,
                ProductPrice = finalProductPrice,
                ProductQuantity = finalProductQuantity,
                TotalPrice = finalProductPrice * finalProductQuantity,
                Product = product
            });
        }

        public void AddMultipleProductsOrder(AppDBContext context, Customer customer, List<ProductData> products) 
        {
            context.OrderMultiples.Add(new Models.OrderMultiple
            {
                Customer = customer,
                OrderDate = DateTime.Now,
                ProductData = products,
                TotalPrice = products.Sum(x => x.Price * x.Quantity)
                //TotalPrice = listOfProductData.Sum(x => ProductDataSum(x))  // 180 + 63 // (15 * 12) + (9 * 7)
            });
        }

        public void AddOrder()
        {

        }
    }
}
