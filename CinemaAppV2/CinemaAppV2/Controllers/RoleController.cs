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
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public RoleController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRole()
        {
            return await _databaseContext.Role.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _databaseContext.Role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return role;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Role>> PutRole(int id, Role role)
        {
            if (id != role.roleId)
            {
                return BadRequest();
            }

            _databaseContext.Entry(role).State = EntityState.Modified;

            try
            {
                await _databaseContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            _databaseContext.Role.Add(role);
            await _databaseContext.SaveChangesAsync();

            return CreatedAtAction("GetRole", new { id = role.roleId }, role);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> DeleteRole(int id)
        {
            var role = await _databaseContext.Role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _databaseContext.Role.Remove(role);
            await _databaseContext.SaveChangesAsync();

            return role;
        }

        private bool RoleExists(int id)
        {
            return _databaseContext.Role.Any(x => x.roleId == id);
        }
    }
}