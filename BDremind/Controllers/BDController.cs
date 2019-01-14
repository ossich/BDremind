using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BDremind.Models;

namespace BDremind.Controllers
{
    [Route("api/BD")]
    [ApiController]
    public class BDController : ControllerBase
    {
        private readonly BDContext _context;

        public BDController(BDContext context)
        {
            _context = context;

            if (_context.BDItems.Count() == 0)
            {
                // Create a new BDItem if collection is empty,
                // which means you can't delete all BDItems.
                _context.BDItems.Add(new BDItem { Name = "Name1" });
                _context.SaveChanges();
            }
        }

        // GET: api/BD
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BDItem>>> GetBDItems()
        {
            return await _context.BDItems.ToListAsync();
        }

        // GET: api/BD/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BDItem>> GetBDItem(long id)
        {
            var BDItem = await _context.BDItems.FindAsync(id);

            if (BDItem == null)
            {
                return NotFound();
            }

            return BDItem;
        }
        
        // POST: api/BD
        [HttpPost]
        public async Task<ActionResult<BDItem>> PostTodoItem(BDItem BDItem)
        {
            _context.BDItems.Add(BDItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBDItem", new { id = BDItem.Id }, BDItem);
        }

        // PUT: api/BD/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBDItem(long id, BDItem BDItem)
        {
            if (id != BDItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(BDItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/BD/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BDItem>> DeleteBDItem(long id)
        {
            var BDItem = await _context.BDItems.FindAsync(id);
            if (BDItem == null)
            {
                return NotFound();
            }

            _context.BDItems.Remove(BDItem);
            await _context.SaveChangesAsync();

            return BDItem;
        }
    }
}