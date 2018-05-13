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
    [Route("api/ProcedureIdQualifiers")]
    public class ProcedureIdQualifiersController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public ProcedureIdQualifiersController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/ProcedureIdQualifiers
        [HttpGet]
        public IEnumerable<ProcedureIdQualifier> GetProcedureIdQualifier()
        {
            return _context.ProcedureIdQualifier;
        }

        // GET: api/ProcedureIdQualifiers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProcedureIdQualifier([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var procedureIdQualifier = await _context.ProcedureIdQualifier.SingleOrDefaultAsync(m => m.ProcedureIdQualifierId == id);

            if (procedureIdQualifier == null)
            {
                return NotFound();
            }

            return Ok(procedureIdQualifier);
        }

        // PUT: api/ProcedureIdQualifiers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcedureIdQualifier([FromRoute] int id, [FromBody] ProcedureIdQualifier procedureIdQualifier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != procedureIdQualifier.ProcedureIdQualifierId)
            {
                return BadRequest();
            }

            _context.Entry(procedureIdQualifier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedureIdQualifierExists(id))
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

        // POST: api/ProcedureIdQualifiers
        [HttpPost]
        public async Task<IActionResult> PostProcedureIdQualifier([FromBody] ProcedureIdQualifier procedureIdQualifier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProcedureIdQualifier.Add(procedureIdQualifier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcedureIdQualifier", new { id = procedureIdQualifier.ProcedureIdQualifierId }, procedureIdQualifier);
        }

        // DELETE: api/ProcedureIdQualifiers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcedureIdQualifier([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var procedureIdQualifier = await _context.ProcedureIdQualifier.SingleOrDefaultAsync(m => m.ProcedureIdQualifierId == id);
            if (procedureIdQualifier == null)
            {
                return NotFound();
            }

            _context.ProcedureIdQualifier.Remove(procedureIdQualifier);
            await _context.SaveChangesAsync();

            return Ok(procedureIdQualifier);
        }

        private bool ProcedureIdQualifierExists(int id)
        {
            return _context.ProcedureIdQualifier.Any(e => e.ProcedureIdQualifierId == id);
        }
    }
}