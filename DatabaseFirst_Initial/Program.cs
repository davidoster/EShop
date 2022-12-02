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
            List<ProductCategory> listOfProductCategories = ReadData(databaseService, 115);
            Console.WriteLine($"Rows: {listOfProductCategories.Count}");
            //ReadData(databaseService, 190);

            // CreateData
            //int id = CreateData(databaseService, new ProductCategory("Personal Computer", "The Awesome Personal Computer"));
            //Console.WriteLine($"Created row with Id = {id}");
            databaseService.CreateData(new ProductCategory("Peripheral", "The Awesome Peripherals"));

            // ReadData
            //ReadData(databaseService);

            // UpdateData
            // ReadData(string title, string description) <--- Id = 178
            //UpdateData(databaseService, new ProductCategory(187, "Personal Computer", "The Personal Computer"));

            // DeleteData
            //DeleteData(databaseService, 185);
        }

        //private static int CreateData(DatabaseService databaseService, ProductCategory productCategory)
        //{
        //    int producedId = -1;
        //    using (SqlConnection sqlConnection = new SqlConnection(databaseService.ConnectionString))
        //    {
        //        sqlConnection.Open();
        //        String sqlQuery = $"INSERT INTO {databaseService.Database.Table}(Title, Description)" +
        //            $"VALUES(@title1, @description1)"; //,(@title2, @description2)";
        //        using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
        //        {
        //            command.Parameters.AddWithValue("@title1", productCategory.Title);
        //            command.Parameters.AddWithValue("@description1", productCategory.Description);
        //            //command.Parameters.AddWithValue("@title2", "Jacob");
        //            //command.Parameters.AddWithValue("@description2", "UAE");
        //            int rowsAffected = command.ExecuteNonQuery();
        //        }
        //        using(SqlCommand command1 = new SqlCommand("SELECT @@IDENTITY", sqlConnection))
        //        {
        //            //var obj = command1.ExecuteScalar(); //  row[0] reader[0]
        //            //producedId = Convert.ToInt32(obj);

        //            int.TryParse(command1.ExecuteScalar().ToString(), out producedId);

        //            /***
        //             * 
        //             * void Add(int i, int j, out int result) { result = i + j; }
        //             * 
        //             */
        //        }

        //    }
        //    return producedId;
        //}

        private static List<ProductCategory> ReadData(DatabaseService databaseService, int? id = null)
        {
            List<ProductCategory> productCategories = new List<ProductCategory>();
            using (SqlConnection connection = // using with resources takes care of closing the connection
                            new SqlConnection(databaseService.ConnectionString)) // connect (δημιουργώ ένα connection)
            {
                // Create the Command and Parameter objects.
                SqlCommand command;
                if (id != null)
                {
                    string query = databaseService.Database.Query + $" WHERE Id = {id}";
                    command = new SqlCommand(query, connection); // new query window
                }
                else
                {
                    command = new SqlCommand(databaseService.Database.Query, connection); // new query window
                }

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
                        //var productCategories2 = reader.OfType<ProductCategory>();
                        //Console.WriteLine(productCategories2.FirstOrDefault().Id);
                        
                        int someId = reader.GetFieldValue<int>(0); // Id (int)
                        string someTitle = reader.GetFieldValue<string>(1);
                        string someDescription = reader.GetFieldValue<string>(2);
                        Console.WriteLine($"{someId}\t{someTitle}{someDescription}");
                        productCategories.Add(new ProductCategory(someId, someTitle, someDescription));
                        //Console.WriteLine("\t{0}\t{1}\t{2}", reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Houston we have major problems!!!!");
                    Console.WriteLine(ex.Message);
                }
                //connection.Close(); // is not needed because of using
                return productCategories;
            }
        }

        private static void UpdateData(DatabaseService databaseService, ProductCategory productCategory)
        {
            if (productCategory.Title != null || productCategory.Description != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"UPDATE {databaseService.Database.Table}");
                sb.Append(" SET ");
                if (productCategory.Title != null)
                {
                    sb.Append("Title");
                    sb.Append("='");
                    sb.Append(productCategory.Title);
                    sb.Append("'");
                }
                if (productCategory.Title != null && productCategory.Description != null)
                {
                    sb.Append(",");
                }
                if (productCategory.Description != null)
                {
                    sb.Append("Description");
                    sb.Append("='");
                    sb.Append(productCategory.Description);
                    sb.Append("'");
                }
                sb.Append($" WHERE Id  = {productCategory.Id}");
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
            using (SqlConnection sqlConnection = new SqlConnection(databaseService.ConnectionString))
            {
                string sqlQuery = $"DELETE FROM {databaseService.Database.Table} WHERE Id = @id";

                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@id", id);
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        Console.WriteLine($"Deleted rows: {rowsAffected}");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.HResult);
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
