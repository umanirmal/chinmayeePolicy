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
    [Route("api/ServiceTypeCodes")]
    public class ServiceTypeCodesController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public ServiceTypeCodesController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/ServiceTypeCodes
        [HttpGet]
        public IEnumerable<ServiceTypeCodes> GetServiceTypeCodes()
        {
            return _context.ServiceTypeCodes;
        }

        // GET: api/ServiceTypeCodes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceTypeCodes([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceTypeCodes = await _context.ServiceTypeCodes.SingleOrDefaultAsync(m => m.CodeX12Spec == id);

            if (serviceTypeCodes == null)
            {
                return NotFound();
            }

            return Ok(serviceTypeCodes);
        }

        // PUT: api/ServiceTypeCodes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceTypeCodes([FromRoute] string id, [FromBody] ServiceTypeCodes serviceTypeCodes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceTypeCodes.CodeX12Spec)
            {
                return BadRequest();
            }

            _context.Entry(serviceTypeCodes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeCodesExists(id))
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

        // POST: api/ServiceTypeCodes
        [HttpPost]
        public async Task<IActionResult> PostServiceTypeCodes([FromBody] ServiceTypeCodes serviceTypeCodes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ServiceTypeCodes.Add(serviceTypeCodes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServiceTypeCodesExists(serviceTypeCodes.CodeX12Spec))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetServiceTypeCodes", new { id = serviceTypeCodes.CodeX12Spec }, serviceTypeCodes);
        }

        // DELETE: api/ServiceTypeCodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceTypeCodes([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceTypeCodes = await _context.ServiceTypeCodes.SingleOrDefaultAsync(m => m.CodeX12Spec == id);
            if (serviceTypeCodes == null)
            {
                return NotFound();
            }

            _context.ServiceTypeCodes.Remove(serviceTypeCodes);
            await _context.SaveChangesAsync();

            return Ok(serviceTypeCodes);
        }

        private bool ServiceTypeCodesExists(string id)
        {
            return _context.ServiceTypeCodes.Any(e => e.CodeX12Spec == id);
        }
    }
}