using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAppV2.Models
{
    public class Order
    {
        public int orderId { get; set; }
        public DateTime createdDate { get; set; }
        public float price { get; set; }
        //Foreign key for user
        public int userId { get; set; }
        public User user { get; set; }
        //Foreign key for show
        public int showId { get; set; }
        public Show show { get; set; }
        //Foreign key for Seat
        public List<Seat> seats { get; set; }
    }
}
