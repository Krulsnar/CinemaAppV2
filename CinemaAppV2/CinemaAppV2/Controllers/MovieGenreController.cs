using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppV2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAppV2.Controllers
{
    [Route("api/MovieGenre")]
    [ApiController]
    public class MovieGenreController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public MovieGenreController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<ActionResult<MovieGenre>> InsertMovieGenre(MovieGenre movieGenre)
        {
            try
            {
                _databaseContext.Add(movieGenre);
            }
            catch (Exception e)
            {
                throw e;
            }
            await _databaseContext.SaveChangesAsync();
            return movieGenre;
        }
    }
}