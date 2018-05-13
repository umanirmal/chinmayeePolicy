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
    [Route("api/CostSharings")]
    public class CostSharingsController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public CostSharingsController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/CostSharings
        [HttpGet]
        public IEnumerable<CostSharing> GetCostSharing()
        {
            return _context.CostSharing;
        }

        // GET: api/CostSharings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCostSharing([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var costSharing = await _context.CostSharing.SingleOrDefaultAsync(m => m.CostSharingId == id);

            if (costSharing == null)
            {
                return NotFound();
            }

            return Ok(costSharing);
        }

        // PUT: api/CostSharings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCostSharing([FromRoute] int id, [FromBody] CostSharing costSharing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != costSharing.CostSharingId)
            {
                return BadRequest();
            }

            _context.Entry(costSharing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostSharingExists(id))
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

        // POST: api/CostSharings
        [HttpPost]
        public async Task<IActionResult> PostCostSharing([FromBody] CostSharing costSharing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CostSharing.Add(costSharing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCostSharing", new { id = costSharing.CostSharingId }, costSharing);
        }

        // DELETE: api/CostSharings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCostSharing([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var costSharing = await _context.CostSharing.SingleOrDefaultAsync(m => m.CostSharingId == id);
            if (costSharing == null)
            {
                return NotFound();
            }

            _context.CostSharing.Remove(costSharing);
            await _context.SaveChangesAsync();

            return Ok(costSharing);
        }

        private bool CostSharingExists(int id)
        {
            return _context.CostSharing.Any(e => e.CostSharingId == id);
        }
    }
}