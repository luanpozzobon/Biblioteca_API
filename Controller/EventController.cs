using Microsoft.AspNetCore.Mvc;
using Biblioteca_API.models;
using Biblioteca_API.data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Biblioteca_API.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;

        public EventController(BibliotecaDbContext context)
        {
            _context = context;
        }

        // GET: api/Event
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvent()
        {
            if (_context is null || _context.Event is null)
                return NotFound();

            return await _context.Event.ToListAsync();
        }

        // GET: api/Event/5
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            if (_context is null || _context.Event is null)
                return NotFound();

            var evento = await _context.Event.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        // POST: api/Event
        [HttpPost]
        [Route("new")]
        public async Task<ActionResult<Event>> PostEvent([FromForm]Event evento)
        {
            if (_context is null || _context.Event is null)
                return NotFound();

            _context.Event.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvent), new { id = evento.Id }, evento);
        }

        // PUT: api/Event/5
        [HttpPut]
        [Route ("update")]
        public async Task<IActionResult> PutEvent([FromForm]Event evento)
        {
            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Event/5
        [HttpDelete]
        [Route ("delete/{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            if (_context is null || _context.Event is null)
                return NotFound();
                
            var evento = await _context.Event.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Event.Remove(evento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
