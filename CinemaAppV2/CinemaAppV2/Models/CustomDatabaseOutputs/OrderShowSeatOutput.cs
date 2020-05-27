using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAppV2.Models.CustomDatabaseOutputs
{
    public class OrderShowSeatOutput
    {
        public int orderId { get; set; }
        public DateTime createdDate { get; set; }
        public float price { get; set; }
        public DateTime showTime { get; set; }
        public int seatNr { get; set; }
        public int rowNr { get; set; }

    }
}
