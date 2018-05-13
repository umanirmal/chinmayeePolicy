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
    [Route("api/AuthorizationRequireds")]
    public class AuthorizationRequiredsController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public AuthorizationRequiredsController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/AuthorizationRequireds
        [HttpGet]
        public IEnumerable<AuthorizationRequired> GetAuthorizationRequired()
        {
            return _context.AuthorizationRequired;
        }

        // GET: api/AuthorizationRequireds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorizationRequired([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorizationRequired = await _context.AuthorizationRequired.SingleOrDefaultAsync(m => m.AuthorizationRequiredId == id);

            if (authorizationRequired == null)
            {
                return NotFound();
            }

            return Ok(authorizationRequired);
        }

        // PUT: api/AuthorizationRequireds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthorizationRequired([FromRoute] short id, [FromBody] AuthorizationRequired authorizationRequired)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authorizationRequired.AuthorizationRequiredId)
            {
                return BadRequest();
            }

            _context.Entry(authorizationRequired).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorizationRequiredExists(id))
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

        // POST: api/AuthorizationRequireds
        [HttpPost]
        public async Task<IActionResult> PostAuthorizationRequired([FromBody] AuthorizationRequired authorizationRequired)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AuthorizationRequired.Add(authorizationRequired);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthorizationRequired", new { id = authorizationRequired.AuthorizationRequiredId }, authorizationRequired);
        }

        // DELETE: api/AuthorizationRequireds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorizationRequired([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorizationRequired = await _context.AuthorizationRequired.SingleOrDefaultAsync(m => m.AuthorizationRequiredId == id);
            if (authorizationRequired == null)
            {
                return NotFound();
            }

            _context.AuthorizationRequired.Remove(authorizationRequired);
            await _context.SaveChangesAsync();

            return Ok(authorizationRequired);
        }

        private bool AuthorizationRequiredExists(short id)
        {
            return _context.AuthorizationRequired.Any(e => e.AuthorizationRequiredId == id);
        }
    }
}