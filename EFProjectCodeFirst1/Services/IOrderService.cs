using DatabaseFirst_Initial.Models;
using EFProjectCodeFirst1.Models;
using EFProjectCodeFirst1.Services.Data;
using System.Collections.Generic;

namespace EFProjectCodeFirst1.Services
{
    internal interface IOrderService<T> where T : class
    {
        T AddOrder(AppDBContext context, Customer customer, Product product);

        T AddOrder(AppDBContext context, Customer customer, List<ProductData> products);

    }
}