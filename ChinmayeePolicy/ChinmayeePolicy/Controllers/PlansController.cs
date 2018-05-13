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
    [Route("api/Plans")]
    public class PlansController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public PlansController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/Plans
        [HttpGet]
        public IEnumerable<Plans> GetPlans()
        {
            return _context.Plans;
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlans([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plans = await _context.Plans.SingleOrDefaultAsync(m => m.PlansId == id);

            if (plans == null)
            {
                return NotFound();
            }

            return Ok(plans);
        }

        // PUT: api/Plans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlans([FromRoute] int id, [FromBody] Plans plans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plans.PlansId)
            {
                return BadRequest();
            }

            _context.Entry(plans).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlansExists(id))
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

        // POST: api/Plans
        [HttpPost]
        public async Task<IActionResult> PostPlans([FromBody] Plans plans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Plans.Add(plans);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlans", new { id = plans.PlansId }, plans);
        }

        // DELETE: api/Plans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlans([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plans = await _context.Plans.SingleOrDefaultAsync(m => m.PlansId == id);
            if (plans == null)
            {
                return NotFound();
            }

            _context.Plans.Remove(plans);
            await _context.SaveChangesAsync();

            return Ok(plans);
        }

        private bool PlansExists(int id)
        {
            return _context.Plans.Any(e => e.PlansId == id);
        }
    }
}