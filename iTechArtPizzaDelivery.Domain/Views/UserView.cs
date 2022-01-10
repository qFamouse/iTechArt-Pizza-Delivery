using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Domain.Views
{
    public class UserView
    {
        public int? Id { get; }
        public string Name { get; }
        public string Phone { get; }
        public string Birthday { get; }
        public string Email { get; }
        public List<string> Roles { get; }

        public UserView(int? id, string name, string phone, string birthday, string email, List<string> roles)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Birthday = birthday;
            Email = email;
            Roles = roles;
        }
    }
}
