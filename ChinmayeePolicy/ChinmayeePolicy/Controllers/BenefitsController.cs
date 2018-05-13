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
    [Route("api/Benefits")]
    public class BenefitsController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public BenefitsController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/Benefits
        [HttpGet]
        public IEnumerable<Benefit> GetBenefit()
        {
            return _context.Benefit;
        }

        // GET: api/Benefits/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBenefit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var benefit = await _context.Benefit.SingleOrDefaultAsync(m => m.BenefitId == id);

            if (benefit == null)
            {
                return NotFound();
            }

            return Ok(benefit);
        }

        // PUT: api/Benefits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBenefit([FromRoute] int id, [FromBody] Benefit benefit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != benefit.BenefitId)
            {
                return BadRequest();
            }

            _context.Entry(benefit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BenefitExists(id))
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

        // POST: api/Benefits
        [HttpPost]
        public async Task<IActionResult> PostBenefit([FromBody] Benefit benefit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Benefit.Add(benefit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBenefit", new { id = benefit.BenefitId }, benefit);
        }

        // DELETE: api/Benefits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBenefit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var benefit = await _context.Benefit.SingleOrDefaultAsync(m => m.BenefitId == id);
            if (benefit == null)
            {
                return NotFound();
            }

            _context.Benefit.Remove(benefit);
            await _context.SaveChangesAsync();

            return Ok(benefit);
        }

        private bool BenefitExists(int id)
        {
            return _context.Benefit.Any(e => e.BenefitId == id);
        }
    }
}