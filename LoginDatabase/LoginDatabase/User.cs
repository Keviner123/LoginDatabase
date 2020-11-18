using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDatabase
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public User(string email, string name, string password, string salt) {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Salt = salt;
        }
    }
}
