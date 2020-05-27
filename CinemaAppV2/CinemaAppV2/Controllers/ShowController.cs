using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CinemaAppV2.Models;
using CinemaAppV2.Models.CustomDatabaseOutputs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAppV2.Controllers
{
    [Route("api/show")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public ShowController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public ActionResult<ShowMovieTheaterOutput> GetShow()
        {
            var show = (from s in _databaseContext.Show
                        join t in _databaseContext.Theater on s.theaterId equals t.theaterId
                        join m in _databaseContext.Movie on s.movieId equals m.movieId
                        select new ShowMovieTheaterOutput
                        {
                            showId = s.showId,
                            showTime = s.showtime,
                            moiveTitle = m.title,
                            theaterName = t.name
                        }).ToList();

            return Ok(show);
        }

        //Get all show from one movie
        [HttpGet("movie/{id}")]
        public ActionResult<ShowMovieTheaterOutput> GetShowByMovie(int id)
        {
            var show = (from s in _databaseContext.Show
                        join t in _databaseContext.Theater on s.theaterId equals t.theaterId
                        join m in _databaseContext.Movie on s.movieId equals m.movieId
                        where s.movieId == id
                        select new ShowMovieTheaterOutput
                        {
                            showId = s.showId,
                            showTime = s.showtime,
                            moiveTitle = m.title,
                            theaterName = t.name
                        }).ToList();

            return Ok(show);
        }

        [HttpGet("{id}")]
        public ActionResult<ShowMovieTheaterOutput> GetShow(int id)
        {
            var show = (from s in _databaseContext.Show
                        join t in _databaseContext.Theater on s.theaterId equals t.theaterId
                        join m in _databaseContext.Movie on s.movieId equals m.movieId
                        where s.showId == id
                        select new ShowMovieTheaterOutput
                        {
                            showId = s.showId,
                            showTime = s.showtime,
                            moiveTitle = m.title,
                            theaterName = t.name
                        }).FirstOrDefault();

            return show;
        }

        [HttpPost]
        public async Task<ActionResult<Show>> CreateShow(Show show)
        {
            var theaterId = _databaseContext.Theater.Find(show.theaterId);
            var movieId = _databaseContext.Movie.Find(show.movieId);

            if (theaterId == null)
            {
                return NotFound(show.theaterId);
            }
            else if (movieId == null)
            {
                return NotFound(show.movieId);
            }

            _databaseContext.Show.Add(show);
            await _databaseContext.SaveChangesAsync();

            return CreatedAtAction("GetShow", new { id = show.showId }, show);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Show>> UpdateShow(int id, Show show)
        {
            if (id != show.showId)
            {
                return BadRequest();
            }

            _databaseContext.Entry(show).State = EntityState.Modified;

            try
            {
                await _databaseContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetShow", show);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Show>> DeleteShow(int id)
        {
            var show = _databaseContext.Show.Find(id);
            if (show == null)
            {
                return NotFound(id);
            }

            _databaseContext.Show.Remove(show);
            await _databaseContext.SaveChangesAsync();

            return show;
        }

        private bool ShowExists(int id)
        {
            return _databaseContext.Movie.Any(e => e.movieId == id);
        }
    }
}