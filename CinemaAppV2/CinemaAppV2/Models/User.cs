using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAppV2.Models
{
    public class User
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string emailAddress { get; set; }
        public int roleId { get; set; }
        public Role role { get; set; }
        public List<Order> orders { get; set; }
    }
}
