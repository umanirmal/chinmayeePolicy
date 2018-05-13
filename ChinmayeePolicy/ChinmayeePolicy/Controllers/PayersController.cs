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
    [Route("api/Payers")]
    public class PayersController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public PayersController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/Payers
        [HttpGet]
        public IEnumerable<Payer> GetPayer()
        {
            return _context.Payer;
        }

        // GET: api/Payers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payer = await _context.Payer.SingleOrDefaultAsync(m => m.PayerId == id);

            if (payer == null)
            {
                return NotFound();
            }

            return Ok(payer);
        }

        // PUT: api/Payers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayer([FromRoute] int id, [FromBody] Payer payer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != payer.PayerId)
            {
                return BadRequest();
            }

            _context.Entry(payer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayerExists(id))
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

        // POST: api/Payers
        [HttpPost]
        public async Task<IActionResult> PostPayer([FromBody] Payer payer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Payer.Add(payer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayer", new { id = payer.PayerId }, payer);
        }

        // DELETE: api/Payers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payer = await _context.Payer.SingleOrDefaultAsync(m => m.PayerId == id);
            if (payer == null)
            {
                return NotFound();
            }

            _context.Payer.Remove(payer);
            await _context.SaveChangesAsync();

            return Ok(payer);
        }

        private bool PayerExists(int id)
        {
            return _context.Payer.Any(e => e.PayerId == id);
        }
    }
}