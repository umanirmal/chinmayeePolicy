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
    [Route("api/CoveragePolicies")]
    public class CoveragePoliciesController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public CoveragePoliciesController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/CoveragePolicies
        [HttpGet]
        public IEnumerable<CoveragePolicy> GetCoveragePolicy()
        {
            return _context.CoveragePolicy;
        }

        // GET: api/CoveragePolicies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoveragePolicy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coveragePolicy = await _context.CoveragePolicy.SingleOrDefaultAsync(m => m.CoveragePolicyId == id);

            if (coveragePolicy == null)
            {
                return NotFound();
            }

            return Ok(coveragePolicy);
        }

        // PUT: api/CoveragePolicies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoveragePolicy([FromRoute] int id, [FromBody] CoveragePolicy coveragePolicy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coveragePolicy.CoveragePolicyId)
            {
                return BadRequest();
            }

            _context.Entry(coveragePolicy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoveragePolicyExists(id))
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

        // POST: api/CoveragePolicies
        [HttpPost]
        public async Task<IActionResult> PostCoveragePolicy([FromBody] CoveragePolicy coveragePolicy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CoveragePolicy.Add(coveragePolicy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoveragePolicy", new { id = coveragePolicy.CoveragePolicyId }, coveragePolicy);
        }

        // DELETE: api/CoveragePolicies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoveragePolicy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coveragePolicy = await _context.CoveragePolicy.SingleOrDefaultAsync(m => m.CoveragePolicyId == id);
            if (coveragePolicy == null)
            {
                return NotFound();
            }

            _context.CoveragePolicy.Remove(coveragePolicy);
            await _context.SaveChangesAsync();

            return Ok(coveragePolicy);
        }

        private bool CoveragePolicyExists(int id)
        {
            return _context.CoveragePolicy.Any(e => e.CoveragePolicyId == id);
        }
    }
}