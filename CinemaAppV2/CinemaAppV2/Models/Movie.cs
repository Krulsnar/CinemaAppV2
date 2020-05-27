using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAppV2.Models
{
    public class Movie
    {
        public int movieId { get; set; }
        public string title { get; set; }
        public int runtime { get; set; }
        public string description { get; set; }
        public DateTime releaseDate { get; set; }

        public virtual List<MovieGenre> MovieGenres { get; set; }
        public List<Show> Shows { get; set; }
    }
}
