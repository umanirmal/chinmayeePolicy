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
    [Route("api/QuantityQualifiers")]
    public class QuantityQualifiersController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public QuantityQualifiersController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/QuantityQualifiers
        [HttpGet]
        public IEnumerable<QuantityQualifier> GetQuantityQualifier()
        {
            return _context.QuantityQualifier;
        }

        // GET: api/QuantityQualifiers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuantityQualifier([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quantityQualifier = await _context.QuantityQualifier.SingleOrDefaultAsync(m => m.QuantityQualifierId == id);

            if (quantityQualifier == null)
            {
                return NotFound();
            }

            return Ok(quantityQualifier);
        }

        // PUT: api/QuantityQualifiers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuantityQualifier([FromRoute] short id, [FromBody] QuantityQualifier quantityQualifier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quantityQualifier.QuantityQualifierId)
            {
                return BadRequest();
            }

            _context.Entry(quantityQualifier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuantityQualifierExists(id))
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

        // POST: api/QuantityQualifiers
        [HttpPost]
        public async Task<IActionResult> PostQuantityQualifier([FromBody] QuantityQualifier quantityQualifier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.QuantityQualifier.Add(quantityQualifier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuantityQualifier", new { id = quantityQualifier.QuantityQualifierId }, quantityQualifier);
        }

        // DELETE: api/QuantityQualifiers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuantityQualifier([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quantityQualifier = await _context.QuantityQualifier.SingleOrDefaultAsync(m => m.QuantityQualifierId == id);
            if (quantityQualifier == null)
            {
                return NotFound();
            }

            _context.QuantityQualifier.Remove(quantityQualifier);
            await _context.SaveChangesAsync();

            return Ok(quantityQualifier);
        }

        private bool QuantityQualifierExists(short id)
        {
            return _context.QuantityQualifier.Any(e => e.QuantityQualifierId == id);
        }
    }
}