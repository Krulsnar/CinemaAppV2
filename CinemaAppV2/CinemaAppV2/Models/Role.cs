using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAppV2.Models
{
    public class Role
    {
        public int roleId { get; set; }
        public string roleType { get; set; }
        public List<User> user { get; set; }
    }
}
