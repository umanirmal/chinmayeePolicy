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
    [Route("api/TimePeriodQualifiers")]
    public class TimePeriodQualifiersController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public TimePeriodQualifiersController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/TimePeriodQualifiers
        [HttpGet]
        public IEnumerable<TimePeriodQualifier> GetTimePeriodQualifier()
        {
            return _context.TimePeriodQualifier;
        }

        // GET: api/TimePeriodQualifiers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTimePeriodQualifier([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timePeriodQualifier = await _context.TimePeriodQualifier.SingleOrDefaultAsync(m => m.TimePeriodQualifierId == id);

            if (timePeriodQualifier == null)
            {
                return NotFound();
            }

            return Ok(timePeriodQualifier);
        }

        // PUT: api/TimePeriodQualifiers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimePeriodQualifier([FromRoute] short id, [FromBody] TimePeriodQualifier timePeriodQualifier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timePeriodQualifier.TimePeriodQualifierId)
            {
                return BadRequest();
            }

            _context.Entry(timePeriodQualifier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimePeriodQualifierExists(id))
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

        // POST: api/TimePeriodQualifiers
        [HttpPost]
        public async Task<IActionResult> PostTimePeriodQualifier([FromBody] TimePeriodQualifier timePeriodQualifier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TimePeriodQualifier.Add(timePeriodQualifier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimePeriodQualifier", new { id = timePeriodQualifier.TimePeriodQualifierId }, timePeriodQualifier);
        }

        // DELETE: api/TimePeriodQualifiers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimePeriodQualifier([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timePeriodQualifier = await _context.TimePeriodQualifier.SingleOrDefaultAsync(m => m.TimePeriodQualifierId == id);
            if (timePeriodQualifier == null)
            {
                return NotFound();
            }

            _context.TimePeriodQualifier.Remove(timePeriodQualifier);
            await _context.SaveChangesAsync();

            return Ok(timePeriodQualifier);
        }

        private bool TimePeriodQualifierExists(short id)
        {
            return _context.TimePeriodQualifier.Any(e => e.TimePeriodQualifierId == id);
        }
    }
}