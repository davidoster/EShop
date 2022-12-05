using DatabaseFirst_Initial.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_Initial.Services
{
    public class DatabaseService : IDatabaseService
    {
        public Database Database { get; set; }
        public Server Server { get; set; }
        public User User { get; set; }

        public string ConnectionString { get; private set; }

        public DatabaseService(Database database, Server server, User user)
        {
            Database = database;
            Server = server;
            User = user;
            List<KeyValuePair<string, string>> listOfKeyValuePairs = new List<KeyValuePair<string, string>>();
            listOfKeyValuePairs.Add(CreateKeyValuePair("Server", $"{Server.Name},{Server.Port}"));
            listOfKeyValuePairs.Add(CreateKeyValuePair("Database", Database.Name));
            listOfKeyValuePairs.Add(CreateKeyValuePair("User Id", User.Id));
            listOfKeyValuePairs.Add(CreateKeyValuePair("Password", User.Password));
            CreateConnectionString(listOfKeyValuePairs);
        }

        private KeyValuePair<string, string> CreateKeyValuePair(string key, string value)
        {
            KeyValuePair<string, string> result = new KeyValuePair<string, string>(key, value);
            return result;
        }

        private void CreateConnectionString(List<KeyValuePair<string, string>> listOfKeyValuePairs)
        {
            StringBuilder sbConnectionString = new StringBuilder();
            foreach (var keyValuePair in listOfKeyValuePairs)
            {
                sbConnectionString.Append(keyValuePair.Key); // Server
                sbConnectionString.Append("="); // Server=
                sbConnectionString.Append(keyValuePair.Value); // Server=ra1.anystream.eu,9888
                sbConnectionString.Append(";");
            }
            ConnectionString = sbConnectionString.ToString(); // Server=ra1.anystream.eu,9888;
        }

        public int CreateData(ProductCategory productCategory)
        {
            int producedId = -1;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                String sqlQuery = $"INSERT INTO {Database.Table}(Title, Description)" +
                    $"VALUES(@title1, @description1)"; //,(@title2, @description2)";
                using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
                {
                    command.Parameters.AddWithValue("@title1", productCategory.Title);
                    command.Parameters.AddWithValue("@description1", productCategory.Description);
                    //command.Parameters.AddWithValue("@title2", "Jacob");
                    //command.Parameters.AddWithValue("@description2", "UAE");
                    int rowsAffected = command.ExecuteNonQuery();
                }
                using (SqlCommand command1 = new SqlCommand("SELECT @@IDENTITY", sqlConnection))
                {
                    //var obj = command1.ExecuteScalar(); //  row[0] reader[0]
                    //producedId = Convert.ToInt32(obj);

                    int.TryParse(command1.ExecuteScalar().ToString(), out producedId);

                    /***
                     * 
                     * void Add(int i, int j, out int result) { result = i + j; }
                     * 
                     */
                }

            }
            return producedId;
        }

        public int CreateData(Product product)
        {
            return 0;
        }
    }
}
