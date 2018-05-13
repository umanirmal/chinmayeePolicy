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
    [Route("api/MonetaryRestrictions")]
    public class MonetaryRestrictionsController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public MonetaryRestrictionsController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/MonetaryRestrictions
        [HttpGet]
        public IEnumerable<MonetaryRestrictions> GetMonetaryRestrictions()
        {
            return _context.MonetaryRestrictions;
        }

        // GET: api/MonetaryRestrictions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMonetaryRestrictions([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var monetaryRestrictions = await _context.MonetaryRestrictions.SingleOrDefaultAsync(m => m.MonetaryRestrictionsId == id);

            if (monetaryRestrictions == null)
            {
                return NotFound();
            }

            return Ok(monetaryRestrictions);
        }

        // PUT: api/MonetaryRestrictions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonetaryRestrictions([FromRoute] short id, [FromBody] MonetaryRestrictions monetaryRestrictions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monetaryRestrictions.MonetaryRestrictionsId)
            {
                return BadRequest();
            }

            _context.Entry(monetaryRestrictions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonetaryRestrictionsExists(id))
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

        // POST: api/MonetaryRestrictions
        [HttpPost]
        public async Task<IActionResult> PostMonetaryRestrictions([FromBody] MonetaryRestrictions monetaryRestrictions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MonetaryRestrictions.Add(monetaryRestrictions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonetaryRestrictions", new { id = monetaryRestrictions.MonetaryRestrictionsId }, monetaryRestrictions);
        }

        // DELETE: api/MonetaryRestrictions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonetaryRestrictions([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var monetaryRestrictions = await _context.MonetaryRestrictions.SingleOrDefaultAsync(m => m.MonetaryRestrictionsId == id);
            if (monetaryRestrictions == null)
            {
                return NotFound();
            }

            _context.MonetaryRestrictions.Remove(monetaryRestrictions);
            await _context.SaveChangesAsync();

            return Ok(monetaryRestrictions);
        }

        private bool MonetaryRestrictionsExists(short id)
        {
            return _context.MonetaryRestrictions.Any(e => e.MonetaryRestrictionsId == id);
        }
    }
}