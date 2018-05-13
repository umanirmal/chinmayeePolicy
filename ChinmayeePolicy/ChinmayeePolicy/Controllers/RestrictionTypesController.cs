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
    [Route("api/RestrictionTypes")]
    public class RestrictionTypesController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public RestrictionTypesController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/RestrictionTypes
        [HttpGet]
        public IEnumerable<RestrictionType> GetRestrictionType()
        {
            return _context.RestrictionType;
        }

        // GET: api/RestrictionTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestrictionType([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restrictionType = await _context.RestrictionType.SingleOrDefaultAsync(m => m.RestrictionTypeId == id);

            if (restrictionType == null)
            {
                return NotFound();
            }

            return Ok(restrictionType);
        }

        // PUT: api/RestrictionTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestrictionType([FromRoute] short id, [FromBody] RestrictionType restrictionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restrictionType.RestrictionTypeId)
            {
                return BadRequest();
            }

            _context.Entry(restrictionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestrictionTypeExists(id))
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

        // POST: api/RestrictionTypes
        [HttpPost]
        public async Task<IActionResult> PostRestrictionType([FromBody] RestrictionType restrictionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RestrictionType.Add(restrictionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestrictionType", new { id = restrictionType.RestrictionTypeId }, restrictionType);
        }

        // DELETE: api/RestrictionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestrictionType([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restrictionType = await _context.RestrictionType.SingleOrDefaultAsync(m => m.RestrictionTypeId == id);
            if (restrictionType == null)
            {
                return NotFound();
            }

            _context.RestrictionType.Remove(restrictionType);
            await _context.SaveChangesAsync();

            return Ok(restrictionType);
        }

        private bool RestrictionTypeExists(short id)
        {
            return _context.RestrictionType.Any(e => e.RestrictionTypeId == id);
        }
    }
}