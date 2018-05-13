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
    [Route("api/Subscribers")]
    public class SubscribersController : Controller
    {
        private readonly ChinmayeePolicyContext _context;

        public SubscribersController(ChinmayeePolicyContext context)
        {
            _context = context;
        }

        // GET: api/Subscribers
        [HttpGet]
        public IEnumerable<Subscriber> GetSubscriber()
        {
            return _context.Subscriber;
        }

        // GET: api/Subscribers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriber([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscriber = await _context.Subscriber.SingleOrDefaultAsync(m => m.SubscriberId == id);

            if (subscriber == null)
            {
                return NotFound();
            }

            return Ok(subscriber);
        }

        // PUT: api/Subscribers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriber([FromRoute] int id, [FromBody] Subscriber subscriber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subscriber.SubscriberId)
            {
                return BadRequest();
            }

            _context.Entry(subscriber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriberExists(id))
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

        // POST: api/Subscribers
        [HttpPost]
        public async Task<IActionResult> PostSubscriber([FromBody] Subscriber subscriber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Subscriber.Add(subscriber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriber", new { id = subscriber.SubscriberId }, subscriber);
        }

        // DELETE: api/Subscribers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriber([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscriber = await _context.Subscriber.SingleOrDefaultAsync(m => m.SubscriberId == id);
            if (subscriber == null)
            {
                return NotFound();
            }

            _context.Subscriber.Remove(subscriber);
            await _context.SaveChangesAsync();

            return Ok(subscriber);
        }

        private bool SubscriberExists(int id)
        {
            return _context.Subscriber.Any(e => e.SubscriberId == id);
        }
    }
}