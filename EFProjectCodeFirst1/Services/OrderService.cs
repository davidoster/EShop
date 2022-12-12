using DatabaseFirst_Initial.Models;
using EFProjectCodeFirst1.Migrations;
using EFProjectCodeFirst1.Models;
using EFProjectCodeFirst1.Services.Data;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EFProjectCodeFirst1.Services
{
    internal class OrderService<T> : IOrderService<T> where T : class 
    {
        private AppDBContext _context;
        public AppDBContext context { 
            get => _context; 
            set => _context = value; 
        }

        public OrderService()
        {
            // if the db server is up and running only then create AppDBContext and create an OrderService 
            SqlConnection sqlConnection = 
                new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            try
            {
                sqlConnection.Open();
                sqlConnection.Close();
            }
            catch (Exception)
            {

                throw new DBServerConnectionErrorException("The database server is experiencing some issues. Please try later.");
            }
            _context = new AppDBContext();
            //if (sqlConnection.State.HasFlag(System.Data.ConnectionState.Closed) 
            //    || sqlConnection.State.HasFlag(System.Data.ConnectionState.Broken))
            //{
            //    throw new DBServerConnectionErrorException();
            //}
            //else
            //{
                
            //}
            
        }
        public T AddOrder(Customer customer, Product product)
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

        public T AddOrder(Customer customer, List<ProductData> products)
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
