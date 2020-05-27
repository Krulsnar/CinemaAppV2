using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAppV2.Models
{
    public class MovieGenre
    {
        public int movieId { get; set; }
        public Movie Movie { get; set; }
        public int genreId { get; set; }
        public Genre Genre { get; set; }
    }
}
