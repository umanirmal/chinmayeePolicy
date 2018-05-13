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
    [Route("api/HealthInfoes")]
    public class HealthInfoesController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public HealthInfoesController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/HealthInfoes
        [HttpGet]
        public IEnumerable<HealthInfo> GetHealthInfo()
        {
            return _context.HealthInfo;
        }

        // GET: api/HealthInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHealthInfo([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var healthInfo = await _context.HealthInfo.SingleOrDefaultAsync(m => m.HealthInfoId == id);

            if (healthInfo == null)
            {
                return NotFound();
            }

            return Ok(healthInfo);
        }

        // PUT: api/HealthInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHealthInfo([FromRoute] short id, [FromBody] HealthInfo healthInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != healthInfo.HealthInfoId)
            {
                return BadRequest();
            }

            _context.Entry(healthInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HealthInfoExists(id))
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

        // POST: api/HealthInfoes
        [HttpPost]
        public async Task<IActionResult> PostHealthInfo([FromBody] HealthInfo healthInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HealthInfo.Add(healthInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHealthInfo", new { id = healthInfo.HealthInfoId }, healthInfo);
        }

        // DELETE: api/HealthInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHealthInfo([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var healthInfo = await _context.HealthInfo.SingleOrDefaultAsync(m => m.HealthInfoId == id);
            if (healthInfo == null)
            {
                return NotFound();
            }

            _context.HealthInfo.Remove(healthInfo);
            await _context.SaveChangesAsync();

            return Ok(healthInfo);
        }

        private bool HealthInfoExists(short id)
        {
            return _context.HealthInfo.Any(e => e.HealthInfoId == id);
        }
    }
}