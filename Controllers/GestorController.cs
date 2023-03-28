using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestorArchivo.Models;

namespace GestorArchivos.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class GestorController : ControllerBase
    {
        private readonly GestorContext _context;

        public GestorController(GestorContext context)
        {
            _context = context;
        }

        // GET: api/Gestor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GestorItem>>> GetGestorItems()
        {
            return await _context.GestorItems.ToListAsync();
        }

        // GET: api/Gestor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GestorItem>> GetGestorItem(long id)
        {
            var gestorItem = await _context.GestorItems.FindAsync(id);  

            if (gestorItem == null)
            {
                return NotFound();
            }

            return gestorItem;
        }

        // PUT: api/Gestor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGestorItem(long id, GestorItem gestorItem)
        {
            if (id != gestorItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(gestorItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GestorItemExists(id))
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

        // POST: api/Gestor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GestorItem>> PostTodoItem(GestorItem gestorItem)
        {
            _context.GestorItems.Add(gestorItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetGestorItem), new { id = gestorItem.Id }, gestorItem);
        }

        // DELETE: api/Gestor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGestorItem(long id)
        {
            var gestorItem = await _context.GestorItems.FindAsync(id);
            if (gestorItem == null)
            {
                return NotFound();
            }

            _context.GestorItems.Remove(gestorItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GestorItemExists(long id)
        {
            return _context.GestorItems.Any(e => e.Id == id);
        }
    }
}
