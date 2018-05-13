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
    [Route("api/Deliveries")]
    public class DeliveriesController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public DeliveriesController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/Deliveries
        [HttpGet]
        public IEnumerable<Delivery> GetDelivery()
        {
            return _context.Delivery;
        }

        // GET: api/Deliveries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDelivery([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var delivery = await _context.Delivery.SingleOrDefaultAsync(m => m.DeliveryId == id);

            if (delivery == null)
            {
                return NotFound();
            }

            return Ok(delivery);
        }

        // PUT: api/Deliveries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDelivery([FromRoute] short id, [FromBody] Delivery delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != delivery.DeliveryId)
            {
                return BadRequest();
            }

            _context.Entry(delivery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryExists(id))
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

        // POST: api/Deliveries
        [HttpPost]
        public async Task<IActionResult> PostDelivery([FromBody] Delivery delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Delivery.Add(delivery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDelivery", new { id = delivery.DeliveryId }, delivery);
        }

        // DELETE: api/Deliveries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery([FromRoute] short id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var delivery = await _context.Delivery.SingleOrDefaultAsync(m => m.DeliveryId == id);
            if (delivery == null)
            {
                return NotFound();
            }

            _context.Delivery.Remove(delivery);
            await _context.SaveChangesAsync();

            return Ok(delivery);
        }

        private bool DeliveryExists(short id)
        {
            return _context.Delivery.Any(e => e.DeliveryId == id);
        }
    }
}