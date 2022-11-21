using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Database.Models
{
    public class User
    {
        public User(Guid id, string username, string password, string email, string telephone, bool confirmEmail)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            Telephone = telephone;
            ConfirmEmail = confirmEmail;
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool ConfirmEmail { get; set; }

    }
}
