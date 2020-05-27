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
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public UserController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            var userList = await _databaseContext.User.ToListAsync();

            return Ok(userList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _databaseContext.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("WithRole/{id}")]
        public ActionResult<UserRoleOutput> GetUserWithRole(int id)
        {
            var user = (from u in _databaseContext.User
                        join r in _databaseContext.Role on u.roleId equals r.roleId
                        where u.userId == id
                        select new UserRoleOutput
                        {
                            userId = u.userId,
                            username = u.username,
                            password = u.password,
                            firstname = u.firstname,
                            surname = u.surname,
                            emailAddress = u.emailAddress,
                            role = r.roleType
                        }).FirstOrDefault();

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _databaseContext.User.Add(user);
            await _databaseContext.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.userId }, user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _databaseContext.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _databaseContext.User.Remove(user);
            await _databaseContext.SaveChangesAsync();

            return user;

        }
    }
}