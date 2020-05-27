using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAppV2.Models.CustomDatabaseOutputs
{
    public class UserRoleOutput
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string emailAddress { get; set; }
        public string role { get; set; }
    }
}

