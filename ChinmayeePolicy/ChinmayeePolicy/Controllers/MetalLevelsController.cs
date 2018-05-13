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
    [Route("api/MetalLevels")]
    public class MetalLevelsController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public MetalLevelsController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/MetalLevels
        [HttpGet]
        public IEnumerable<MetalLevel> GetMetalLevel()
        {
            return _context.MetalLevel;
        }

        // GET: api/MetalLevels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMetalLevel([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var metalLevel = await _context.MetalLevel.SingleOrDefaultAsync(m => m.MetalLevelId == id);

            if (metalLevel == null)
            {
                return NotFound();
            }

            return Ok(metalLevel);
        }

        // PUT: api/MetalLevels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetalLevel([FromRoute] short id, [FromBody] MetalLevel metalLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != metalLevel.MetalLevelId)
            {
                return BadRequest();
            }

            _context.Entry(metalLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetalLevelExists(id))
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

        // POST: api/MetalLevels
        [HttpPost]
        public async Task<IActionResult> PostMetalLevel([FromBody] MetalLevel metalLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MetalLevel.Add(metalLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetalLevel", new { id = metalLevel.MetalLevelId }, metalLevel);
        }

        // DELETE: api/MetalLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetalLevel([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var metalLevel = await _context.MetalLevel.SingleOrDefaultAsync(m => m.MetalLevelId == id);
            if (metalLevel == null)
            {
                return NotFound();
            }

            _context.MetalLevel.Remove(metalLevel);
            await _context.SaveChangesAsync();

            return Ok(metalLevel);
        }

        private bool MetalLevelExists(short id)
        {
            return _context.MetalLevel.Any(e => e.MetalLevelId == id);
        }
    }
}