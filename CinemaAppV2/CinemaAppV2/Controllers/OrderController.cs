using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppV2.Models;
using CinemaAppV2.Models.CustomDatabaseOutputs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAppV2.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OrderController(DatabaseContext context)
        {
            _context = context;
        }
        
        /*TODO: Make this so it is able to take in a List of seatNr and rowNr that way the user can order multiple seats in one order
         * 
         * Right now its one seat per order. So change when view is set up 
         */
        [HttpPost("{seatNr}/{rowNr}")]
        public async Task<ActionResult<Order>> PostOrder(int seatNr, int rowNr, Order order)
        {

            if (UserShowExists(order.userId, order.showId) && SeatingExists(seatNr, rowNr))
            {
                try
                {
                    _context.Order.Add(order);
                    await _context.SaveChangesAsync();
                    _context.Seat.Add(
                        new Seat
                        {
                            available = true,
                            seatNr = seatNr,
                            rowNr = rowNr,
                            showId = order.showId,
                            orderId = order.orderId

                        });
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("CreateOrder", new { id = order.orderId }, order);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Order.ToListAsync();
        }

        /* Gets all orders given a specific order id and returns a custom order where showtime and seats are presented aswell.
         */
        [HttpGet("GetOrderWithSeat/{id}")]
        public ActionResult<IEnumerable<OrderShowSeatOutput>> GetCustomOrders(int id)
        {
            var order = (from o in _context.Order
                         join s in _context.Show on o.showId equals s.showId
                         join se in _context.Seat on o.orderId equals se.orderId
                         where o.orderId == id
                         select new OrderShowSeatOutput
                         {
                             orderId = o.orderId,
                             createdDate = o.createdDate,
                             price = o.price,
                             showTime = s.showtime,
                             seatNr = se.seatNr,
                             rowNr = se.rowNr
                         }).ToList();
            if (order == null)
            {
                return BadRequest();
            }
            return order;
        }


        /* Gets all orders for a user with UserID
         */
        [HttpGet("GetUserOrders/{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByUserId(int userId)
        {
            var order = await _context.Order.Where(x => x.userId == userId).ToListAsync();
            if (order == null)
            {
                return BadRequest();
            }

            return order;
        }
        /*Gets all orders by the Order ID
         */
        [HttpGet("GetOrderById/{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return BadRequest();
            }
            return order;
        }
        /*Gets all orders with a given showID
         */
        [HttpGet("GetOrderByShow/{showId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderByShowId(int showId)
        {
            var order = await _context.Order.Where(x => x.showId == showId).ToListAsync();
            if (order == null)
            {
                return BadRequest();
            }
            return order;
        }



        private bool UserShowExists(int userId, int showId)
        {
            var userExists =  _context.User.Find(userId);
            var showExists =  _context.Show.Find(showId);
            if (userExists == null && showExists == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool SeatingExists(int seatNr, int rowNr)
        {
            var seatExists = (from s in _context.Seat
                              join o in _context.Order on s.orderId equals o.orderId
                              where s.seatNr == seatNr && s.rowNr == rowNr
                              select new
                              {
                                  s.seatNr,
                                  s.rowNr,
                                  o.showId
                              }).FirstOrDefault();

            if (seatExists == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}