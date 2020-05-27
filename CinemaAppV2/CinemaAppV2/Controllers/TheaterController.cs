using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppV2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAppV2.Controllers
{
    [Route("api/theater")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public TheaterController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Theater>>> GetTheater()
        {
            return await _databaseContext.Theater.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Theater>> CreateTheater(Theater theater)
        {
            _databaseContext.Theater.Add(theater);
            await _databaseContext.SaveChangesAsync();

            return CreatedAtAction("GetTheater", new { id = theater.theaterId }, theater); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Theater>> DeleteTheater(int id)
        {
            var theater = await _databaseContext.Theater.FindAsync(id);
            if (theater == null)
            {
                return NotFound();
            }

            _databaseContext.Remove(theater);
            await _databaseContext.SaveChangesAsync();

            return theater;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Theater>> UpdateTheater(int id, Theater theater)
        {
            if (id != theater.theaterId)
            {
                return BadRequest();
            }

            _databaseContext.Entry(theater).State = EntityState.Modified;

            try
            {
                await _databaseContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheaterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return NoContent();
        }

        private bool TheaterExists(int id)
        {
            return _databaseContext.Theater.Any(x => x.theaterId == id);
        }

    }
}