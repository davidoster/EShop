using DatabaseFirst_Initial.Models;
using DatabaseFirst_Initial.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_Initial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseService databaseService = new DatabaseService(
                    new Database("EShop", "dbo.ProductCategories", "SELECT * FROM dbo.ProductCategories"),
                    new Server("ra1.anystream.eu", "9888"),
                    new User("sa", "SuperSecretPassw0rd")
                );
            Console.WriteLine(databaseService.ConnectionString);
            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = // using with resources takes care of closing the connection
                new SqlConnection(databaseService.ConnectionString)) // connect (δημιουργώ ένα connection)
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(databaseService.Database.Query, connection); // new query window
                

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open(); // do the actual connection
                    Console.WriteLine("Yeeeessss Houston we are connected!!!");
                    SqlDataReader reader = command.ExecuteReader(); // Execute
                    while (reader.Read()) // για όσο μπορώ να διαβάσω (υπάρχουν εγγραφές) διάβαζε)
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}", reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Houston we have major problems!!!!");
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
                connection.Close(); // is not needed because of using
            }
        }
    }
}
