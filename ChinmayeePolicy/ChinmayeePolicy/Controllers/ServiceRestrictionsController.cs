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
    [Route("api/ServiceRestrictions")]
    public class ServiceRestrictionsController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public ServiceRestrictionsController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/ServiceRestrictions
        [HttpGet]
        public IEnumerable<ServiceRestriction> GetServiceRestriction()
        {
            return _context.ServiceRestriction;
        }

        // GET: api/ServiceRestrictions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceRestriction([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceRestriction = await _context.ServiceRestriction.SingleOrDefaultAsync(m => m.ServiceRestrictionId == id);

            if (serviceRestriction == null)
            {
                return NotFound();
            }

            return Ok(serviceRestriction);
        }

        // PUT: api/ServiceRestrictions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceRestriction([FromRoute] short id, [FromBody] ServiceRestriction serviceRestriction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceRestriction.ServiceRestrictionId)
            {
                return BadRequest();
            }

            _context.Entry(serviceRestriction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceRestrictionExists(id))
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

        // POST: api/ServiceRestrictions
        [HttpPost]
        public async Task<IActionResult> PostServiceRestriction([FromBody] ServiceRestriction serviceRestriction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ServiceRestriction.Add(serviceRestriction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceRestriction", new { id = serviceRestriction.ServiceRestrictionId }, serviceRestriction);
        }

        // DELETE: api/ServiceRestrictions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceRestriction([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceRestriction = await _context.ServiceRestriction.SingleOrDefaultAsync(m => m.ServiceRestrictionId == id);
            if (serviceRestriction == null)
            {
                return NotFound();
            }

            _context.ServiceRestriction.Remove(serviceRestriction);
            await _context.SaveChangesAsync();

            return Ok(serviceRestriction);
        }

        private bool ServiceRestrictionExists(short id)
        {
            return _context.ServiceRestriction.Any(e => e.ServiceRestrictionId == id);
        }
    }
}