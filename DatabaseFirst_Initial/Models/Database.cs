using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_Initial.Models
{
    public class Database
    {
        public string Name { get; set; }
        public string Table { get; set; }
        public string Query { get; set; }

        public Database(string name, string table, string query)
        {
            Name = name;
            Table = table;
            Query = query;
        }
    }
}
