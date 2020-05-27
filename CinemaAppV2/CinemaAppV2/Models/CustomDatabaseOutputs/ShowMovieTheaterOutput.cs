using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAppV2.Models.CustomDatabaseOutputs
{
    public class ShowMovieTheaterOutput
    {
        public int showId { get; set; }
        public DateTime showTime { get; set; }
        public string moiveTitle { get; set; }
        public string theaterName { get; set; }
    }
}
