using DatabaseFirst_Initial.Models;
using EFProjectCodeFirst1.Models;
using EFProjectCodeFirst1.Services.Data;
using System.Collections.Generic;

namespace EFProjectCodeFirst1.Services
{
    internal interface IOrderService<T> where T : class
    {
        AppDBContext context { get; set; }
        T AddOrder(Customer customer, Product product);
        T AddOrder(Customer customer, List<ProductData> products);
        T UpdateOrder(int id, Customer customer);
        T UpdateOrder(int id, Customer customer, Product product, int Quantity);
        T UpdateOrder(int id, Customer customer, List<ProductData> products);
    }
}