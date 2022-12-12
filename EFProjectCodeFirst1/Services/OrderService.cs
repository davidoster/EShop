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
    internal class OrderService<T> : IOrderService<T> where T : class 
    {

        public T AddOrder(AppDBContext context, Customer customer, Product product)
        {
            var finalProductPrice = product.Price + 22;
            var finalProductQuantity = 4;
            var insertedOrder = context.CustomerOrders.Add(new Order
            {
                Customer = customer,
                OrderDate = DateTime.Now,
                ProductPrice = finalProductPrice,
                ProductQuantity = finalProductQuantity,
                TotalPrice = finalProductPrice * finalProductQuantity,
                Product = product
            });
            context.SaveChanges();
            return insertedOrder as T;
        }

        public T AddOrder(AppDBContext context, Customer customer, List<ProductData> products)
        {
            var insertedOrder = context.OrderMultiples.Add(new OrderMultiple
            {
                Customer = customer,
                OrderDate = DateTime.Now,
                ProductData = products,
                TotalPrice = products.Sum(x => x.Price * x.Quantity)
                //TotalPrice = listOfProductData.Sum(x => ProductDataSum(x))  // 180 + 63 // (15 * 12) + (9 * 7)
            });
            context.SaveChanges();
            return insertedOrder as T;
        }
    }
}
