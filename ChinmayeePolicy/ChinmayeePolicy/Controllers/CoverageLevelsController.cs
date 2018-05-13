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
    [Route("api/CoverageLevels")]
    public class CoverageLevelsController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public CoverageLevelsController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/CoverageLevels
        [HttpGet]
        public IEnumerable<CoverageLevel> GetCoverageLevel()
        {
            return _context.CoverageLevel;
        }

        // GET: api/CoverageLevels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoverageLevel([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coverageLevel = await _context.CoverageLevel.SingleOrDefaultAsync(m => m.CoverageLevelId == id);

            if (coverageLevel == null)
            {
                return NotFound();
            }

            return Ok(coverageLevel);
        }

        // PUT: api/CoverageLevels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoverageLevel([FromRoute] short id, [FromBody] CoverageLevel coverageLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coverageLevel.CoverageLevelId)
            {
                return BadRequest();
            }

            _context.Entry(coverageLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoverageLevelExists(id))
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

        // POST: api/CoverageLevels
        [HttpPost]
        public async Task<IActionResult> PostCoverageLevel([FromBody] CoverageLevel coverageLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CoverageLevel.Add(coverageLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoverageLevel", new { id = coverageLevel.CoverageLevelId }, coverageLevel);
        }

        // DELETE: api/CoverageLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoverageLevel([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coverageLevel = await _context.CoverageLevel.SingleOrDefaultAsync(m => m.CoverageLevelId == id);
            if (coverageLevel == null)
            {
                return NotFound();
            }

            _context.CoverageLevel.Remove(coverageLevel);
            await _context.SaveChangesAsync();

            return Ok(coverageLevel);
        }

        private bool CoverageLevelExists(short id)
        {
            return _context.CoverageLevel.Any(e => e.CoverageLevelId == id);
        }
    }
}