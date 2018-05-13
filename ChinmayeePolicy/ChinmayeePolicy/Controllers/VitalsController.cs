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
    [Route("api/Vitals")]
    public class VitalsController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public VitalsController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/Vitals
        [HttpGet]
        public IEnumerable<Vitals> GetVitals()
        {
            return _context.Vitals;
        }

        // GET: api/Vitals/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVitals([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vitals = await _context.Vitals.SingleOrDefaultAsync(m => m.VitalsId == id);

            if (vitals == null)
            {
                return NotFound();
            }

            return Ok(vitals);
        }

        // PUT: api/Vitals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVitals([FromRoute] short id, [FromBody] Vitals vitals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vitals.VitalsId)
            {
                return BadRequest();
            }

            _context.Entry(vitals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VitalsExists(id))
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

        // POST: api/Vitals
        [HttpPost]
        public async Task<IActionResult> PostVitals([FromBody] Vitals vitals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Vitals.Add(vitals);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVitals", new { id = vitals.VitalsId }, vitals);
        }

        // DELETE: api/Vitals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVitals([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vitals = await _context.Vitals.SingleOrDefaultAsync(m => m.VitalsId == id);
            if (vitals == null)
            {
                return NotFound();
            }

            _context.Vitals.Remove(vitals);
            await _context.SaveChangesAsync();

            return Ok(vitals);
        }

        private bool VitalsExists(short id)
        {
            return _context.Vitals.Any(e => e.VitalsId == id);
        }
    }
}