using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwitterApi.Data;
using TwitterApi.Models;

namespace TwitterApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitzController : ControllerBase
    {
        private readonly ApiContext _context;

        public TwitzController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Twitz
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Twit>>> GetTwits()
        {
            return await _context.Twits.ToListAsync();
        }

        // GET: api/Twitz/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Twit>> GetTwit(int id)
        {
            var twit = await _context.Twits.FindAsync(id);

            if (twit == null)
            {
                return NotFound();
            }

            return twit;
        }

        // PUT: api/Twitz/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTwit(int id, Twit twit)
        {
            if (id != twit.Id)
            {
                return BadRequest();
            }

            _context.Entry(twit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TwitExists(id))
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

        // POST: api/Twitz
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Twit>> PostTwit(Twit twit)
        {
            _context.Twits.Add(twit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTwit", new { id = twit.Id }, twit);
        }

        // DELETE: api/Twitz/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTwit(int id)
        {
            var twit = await _context.Twits.FindAsync(id);
            if (twit == null)
            {
                return NotFound();
            }

            _context.Twits.Remove(twit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TwitExists(int id)
        {
            return _context.Twits.Any(e => e.Id == id);
        }
    }
}
