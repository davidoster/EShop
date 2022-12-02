using DatabaseFirst_Initial.Models;
using DatabaseFirst_Initial.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IDatabaseService databaseService = new DatabaseService(
                    new Database("EShop", "dbo.ProductCategories", "SELECT * FROM dbo.ProductCategories"),
                    new Server("ra1.anystream.eu", "9888"),
                    new User("sa", "SuperSecretPassw0rd"));
            databaseService.CreateData(new ProductCategory("Awesome PC", "The Awesome Awesomness of PCs"));
            
        }
    }
}
