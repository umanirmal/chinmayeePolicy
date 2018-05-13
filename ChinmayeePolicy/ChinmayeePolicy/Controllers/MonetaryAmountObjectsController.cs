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
    [Route("api/MonetaryAmountObjects")]
    public class MonetaryAmountObjectsController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public MonetaryAmountObjectsController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/MonetaryAmountObjects
        [HttpGet]
        public IEnumerable<MonetaryAmountObject> GetMonetaryAmountObject()
        {
            return _context.MonetaryAmountObject;
        }

        // GET: api/MonetaryAmountObjects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMonetaryAmountObject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var monetaryAmountObject = await _context.MonetaryAmountObject.SingleOrDefaultAsync(m => m.MonetaryamountId == id);

            if (monetaryAmountObject == null)
            {
                return NotFound();
            }

            return Ok(monetaryAmountObject);
        }

        // PUT: api/MonetaryAmountObjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonetaryAmountObject([FromRoute] int id, [FromBody] MonetaryAmountObject monetaryAmountObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monetaryAmountObject.MonetaryamountId)
            {
                return BadRequest();
            }

            _context.Entry(monetaryAmountObject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonetaryAmountObjectExists(id))
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

        // POST: api/MonetaryAmountObjects
        [HttpPost]
        public async Task<IActionResult> PostMonetaryAmountObject([FromBody] MonetaryAmountObject monetaryAmountObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MonetaryAmountObject.Add(monetaryAmountObject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonetaryAmountObject", new { id = monetaryAmountObject.MonetaryamountId }, monetaryAmountObject);
        }

        // DELETE: api/MonetaryAmountObjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonetaryAmountObject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var monetaryAmountObject = await _context.MonetaryAmountObject.SingleOrDefaultAsync(m => m.MonetaryamountId == id);
            if (monetaryAmountObject == null)
            {
                return NotFound();
            }

            _context.MonetaryAmountObject.Remove(monetaryAmountObject);
            await _context.SaveChangesAsync();

            return Ok(monetaryAmountObject);
        }

        private bool MonetaryAmountObjectExists(int id)
        {
            return _context.MonetaryAmountObject.Any(e => e.MonetaryamountId == id);
        }
    }
}