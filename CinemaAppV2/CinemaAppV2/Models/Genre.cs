using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAppV2.Models
{
    public class Genre
    {
        public int genreId { get; set; }
        [Required]
        public string genre { get; set; }

        public virtual List<MovieGenre> MovieGenres { get; set; }
    }
}
