using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddUser
{
    public class User
    {
        //public Guid Id;
        public string Name { get; set; }
        // public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public string GetStringUserData()
        {
            return $"{Name}|{Password}";
        }
    }
}
