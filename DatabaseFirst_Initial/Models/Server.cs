using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_Initial.Models
{
    public class Server
    {
        public string Name { get; set; }
        public string Port { get; set; }

        public Server(string name, string port)
        {
            Name = name;
            Port = port;
        }
    }
}
