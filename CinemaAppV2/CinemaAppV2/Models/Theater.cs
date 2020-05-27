using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAppV2.Models
{
    public class Theater
    {
        public int theaterId { get; set; }
        public string name { get; set; }
        public int seatings { get; set; }
        public int rows { get; set; }
        public List<Show> shows { get; set; }
    }
}
