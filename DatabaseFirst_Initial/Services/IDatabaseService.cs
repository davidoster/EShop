using DatabaseFirst_Initial.Models;

namespace DatabaseFirst_Initial.Services
{
    public interface IDatabaseService
    {
        Database Database { get; set; }
        Server Server { get; set; }
        User User { get; set; }

        string ConnectionString { get; }


        // private static int CreateData(DatabaseService databaseService, ProductCategory productCategory)
        int CreateData(ProductCategory productCategory);
        int CreateData(Product product);


    }
}