using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChinmayeePolicy;

namespace ChinmayeePolicy.Controllers
{
    [Produces("application/json")]
    [Route("api/Authorizations")]
    public class AuthorizationsController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public AuthorizationsController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/Authorizations
        [HttpGet]
        public IEnumerable<Authorization> GetAuthorization()
        {
            return _context.Authorization;
        }

        // GET: api/Authorizations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorization([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorization = await _context.Authorization.SingleOrDefaultAsync(m => m.AuthorizationId == id);

            if (authorization == null)
            {
                return NotFound();
            }

            return Ok(authorization);
        }

        // PUT: api/Authorizations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthorization([FromRoute] int id, [FromBody] Authorization authorization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authorization.AuthorizationId)
            {
                return BadRequest();
            }

            _context.Entry(authorization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorizationExists(id))
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

        // POST: api/Authorizations
        [HttpPost]
        public async Task<IActionResult> PostAuthorization([FromBody] Authorization authorization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Authorization.Add(authorization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthorization", new { id = authorization.AuthorizationId }, authorization);
        }

        // DELETE: api/Authorizations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorization([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorization = await _context.Authorization.SingleOrDefaultAsync(m => m.AuthorizationId == id);
            if (authorization == null)
            {
                return NotFound();
            }

            _context.Authorization.Remove(authorization);
            await _context.SaveChangesAsync();

            return Ok(authorization);
        }

        private bool AuthorizationExists(int id)
        {
            return _context.Authorization.Any(e => e.AuthorizationId == id);
        }
    }
}