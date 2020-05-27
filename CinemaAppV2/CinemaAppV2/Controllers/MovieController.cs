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
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MovieController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            return await _context.Movie.ToListAsync();
        }

        // GET: api/Movie/title='name'
        [HttpGet("search")]
        public Movie Search(string title)
        {
            var movie = _context.Movie.Where(m => m.title == title).FirstOrDefault();
            return movie;
        }

        // GET: api/Movie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpGet("WithGenre/{id}")]
        public ActionResult<MovieGenreOutput> GetMovieWithGenre(int id)
        {
            var movie = (from m in _context.Movie
                         join mg in _context.MovieGenre on m.movieId equals mg.movieId
                         join g in _context.Genre on mg.genreId equals g.genreId
                         where m.movieId == id
                         select new MovieGenreOutput
                         {
                             movieId = m.movieId,
                             title = m.title,
                             description = m.description,
                             runtime = m.runtime,
                             releaseDate = m.releaseDate,
                             genre = g.genre
                         }).FirstOrDefault();

            return movie;
        }


        // PUT: api/Movie/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.movieId)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        /*
        * @HttpPost methos adds the movie object to the @database.Movie table, 
        * then saves the changes, and returns the newly created object as a new 201 Created http response.
        * */
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.movieId }, movie);
        }


        /* 
         * @HttpDelete calls the database via an id parameter, then controls if that ID exists in the database, 
         * if it does then it will remove that data from the database, then save the changes.
         * If the @MovieID does not exist then it will return a 404 not found http response.
         */
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.movieId == id);
        }
    }
}