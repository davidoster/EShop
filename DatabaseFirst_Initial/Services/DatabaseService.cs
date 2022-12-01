using DatabaseFirst_Initial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_Initial.Services
{
    internal class DatabaseService : IDatabaseService
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
    }
}
