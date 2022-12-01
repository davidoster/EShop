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

            // CreateData
            //CreateData(databaseService);

            // ReadData
            //ReadData(databaseService);

            // UpdateData
            //UpdateData(databaseService, 97, "Billy", "Billakos");

            // DeleteData
            DeleteData(databaseService, 97);
        }

        private static void CreateData(DatabaseService databaseService)
        {
            using (SqlConnection sqlConnection = new SqlConnection(databaseService.ConnectionString))
            {
                sqlConnection.Open();
                String sqlQuery = $"INSERT INTO {databaseService.Database.Table}(Title, Description)" +
                    $"VALUES(@title1, @description1),(@title2, @description2)";
                using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
                {
                    command.Parameters.AddWithValue("@title1", "Jake");
                    command.Parameters.AddWithValue("@description1", "United States");
                    command.Parameters.AddWithValue("@title2", "Jacob");
                    command.Parameters.AddWithValue("@description2", "UAE");
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected + " row(s) inserted");
                }
            }
        }

        private static void ReadData(DatabaseService databaseService)
        {
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

        private static void UpdateData(DatabaseService databaseService, int id, string title = null, string description = null)
        {
            if (title != null || description != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"UPDATE {databaseService.Database.Table}");
                sb.Append(" SET ");
                if (title != null)
                {
                    sb.Append("Title");
                    sb.Append("='");
                    sb.Append(title);
                    sb.Append("'");
                }
                if (title != null && description != null)
                {
                    sb.Append(",");
                }
                if (description != null)
                {
                    sb.Append("Description");
                    sb.Append("='");
                    sb.Append(description);
                    sb.Append("'");
                }
                sb.Append($" WHERE Id  = {id}");
                using (SqlConnection sqlConnection = new SqlConnection(databaseService.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                    {
                        int affectedRows = sqlCommand.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected: {affectedRows}");
                    }
                }
            }
            else 
            {
                Console.WriteLine("title or description is needed");
            }
        }

        private static void DeleteData(DatabaseService databaseService, int id)
        {

        }
    }
}
