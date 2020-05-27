using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAppV2.Models
{
    public class Seat
    {
        public int seatId { get; set; }
        public bool available { get; set; }
        public int seatNr { get; set; }
        public int rowNr { get; set; }
        //Foreign key
        public int showId { get; set; }
        public Show show { get; set; }
        //Foreign key
        public int orderId { get; set; }
        public Order order { get; set; }
    }
}
