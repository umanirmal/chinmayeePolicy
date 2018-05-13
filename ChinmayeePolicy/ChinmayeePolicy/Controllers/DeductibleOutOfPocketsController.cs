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
    [Route("api/DeductibleOutOfPockets")]
    public class DeductibleOutOfPocketsController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public DeductibleOutOfPocketsController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/DeductibleOutOfPockets
        [HttpGet]
        public IEnumerable<DeductibleOutOfPocket> GetDeductibleOutOfPocket()
        {
            return _context.DeductibleOutOfPocket;
        }

        // GET: api/DeductibleOutOfPockets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeductibleOutOfPocket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deductibleOutOfPocket = await _context.DeductibleOutOfPocket.SingleOrDefaultAsync(m => m.DeductibleId == id);

            if (deductibleOutOfPocket == null)
            {
                return NotFound();
            }

            return Ok(deductibleOutOfPocket);
        }

        // PUT: api/DeductibleOutOfPockets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeductibleOutOfPocket([FromRoute] int id, [FromBody] DeductibleOutOfPocket deductibleOutOfPocket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deductibleOutOfPocket.DeductibleId)
            {
                return BadRequest();
            }

            _context.Entry(deductibleOutOfPocket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeductibleOutOfPocketExists(id))
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

        // POST: api/DeductibleOutOfPockets
        [HttpPost]
        public async Task<IActionResult> PostDeductibleOutOfPocket([FromBody] DeductibleOutOfPocket deductibleOutOfPocket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DeductibleOutOfPocket.Add(deductibleOutOfPocket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeductibleOutOfPocket", new { id = deductibleOutOfPocket.DeductibleId }, deductibleOutOfPocket);
        }

        // DELETE: api/DeductibleOutOfPockets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeductibleOutOfPocket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deductibleOutOfPocket = await _context.DeductibleOutOfPocket.SingleOrDefaultAsync(m => m.DeductibleId == id);
            if (deductibleOutOfPocket == null)
            {
                return NotFound();
            }

            _context.DeductibleOutOfPocket.Remove(deductibleOutOfPocket);
            await _context.SaveChangesAsync();

            return Ok(deductibleOutOfPocket);
        }

        private bool DeductibleOutOfPocketExists(int id)
        {
            return _context.DeductibleOutOfPocket.Any(e => e.DeductibleId == id);
        }
    }
}