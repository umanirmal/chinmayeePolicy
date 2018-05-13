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
    [Route("api/SmokingStatus")]
    public class SmokingStatusController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public SmokingStatusController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/SmokingStatus
        [HttpGet]
        public IEnumerable<SmokingStatus> GetSmokingStatus()
        {
            return _context.SmokingStatus;
        }

        // GET: api/SmokingStatus/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSmokingStatus([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smokingStatus = await _context.SmokingStatus.SingleOrDefaultAsync(m => m.SmokingStatusId == id);

            if (smokingStatus == null)
            {
                return NotFound();
            }

            return Ok(smokingStatus);
        }

        // PUT: api/SmokingStatus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmokingStatus([FromRoute] short id, [FromBody] SmokingStatus smokingStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != smokingStatus.SmokingStatusId)
            {
                return BadRequest();
            }

            _context.Entry(smokingStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmokingStatusExists(id))
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

        // POST: api/SmokingStatus
        [HttpPost]
        public async Task<IActionResult> PostSmokingStatus([FromBody] SmokingStatus smokingStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SmokingStatus.Add(smokingStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmokingStatus", new { id = smokingStatus.SmokingStatusId }, smokingStatus);
        }

        // DELETE: api/SmokingStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmokingStatus([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smokingStatus = await _context.SmokingStatus.SingleOrDefaultAsync(m => m.SmokingStatusId == id);
            if (smokingStatus == null)
            {
                return NotFound();
            }

            _context.SmokingStatus.Remove(smokingStatus);
            await _context.SaveChangesAsync();

            return Ok(smokingStatus);
        }

        private bool SmokingStatusExists(short id)
        {
            return _context.SmokingStatus.Any(e => e.SmokingStatusId == id);
        }
    }
}