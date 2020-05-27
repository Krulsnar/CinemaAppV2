using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAppV2.Models.CustomDatabaseOutputs
{
    public class MovieGenreOutput
    {
        public int movieId { get; set; }
        public string title { get; set; }
        public int runtime { get; set; }
        public string description { get; set; }
        public DateTime releaseDate { get; set; }
        public string genre { get; set; }
    }
}
