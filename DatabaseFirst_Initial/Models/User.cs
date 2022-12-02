using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_Initial.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Password { get; set; }

        public User(string id, string password)
        {
            Id = id;
            Password = password;
        }
    }
}
