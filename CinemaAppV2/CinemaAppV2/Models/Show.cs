using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAppV2.Models
{
    public class Show
    {
        public int showId { get; set; }
        public DateTime showtime { get; set; }
        //Foreign keys to movie
        public int movieId { get; set; }
        public Movie movie { get; set; }
        //Foreign key to theater
        public int theaterId { get; set; }
        public Theater theater { get; set; }
    }
}
