using Microsoft.AspNetCore.Mvc;
using Biblioteca_API.models;
using Biblioteca_API.data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Biblioteca_API.controllers
{
    [ApiController]
    [Route("editora")]
    public class EditoraAfiliadaController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;

        public EditoraAfiliadaController(BibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("new")]
        public async Task<ActionResult<EditoraAfiliada>> PostEditoraAfiliada([FromForm]EditoraAfiliada editoraAfiliada)
        {
            if (_context is null || _context.EditorasAfiliadas is null)
                return NotFound();

            _context.EditorasAfiliadas.Add(editoraAfiliada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEditoraAfiliada", new { id = editoraAfiliada.Id }, editoraAfiliada);
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<EditoraAfiliada>>> GetEditorasAfiliadas()
        {
            if (_context is null || _context.EditorasAfiliadas is null)
                return NotFound();

            return await _context.EditorasAfiliadas.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<EditoraAfiliada>> GetEditoraAfiliada(int id)
        {
            if (_context is null || _context.EditorasAfiliadas is null)
                return NotFound();

            var editoraAfiliada = await _context.EditorasAfiliadas.FindAsync(id);

            if (editoraAfiliada == null)
            {
                return NotFound();
            }

            return editoraAfiliada;
        }

        [HttpPut]
        [Route("update-editoraAfiliada")]
        public IActionResult UpdateEditoraAfiliadas([FromForm] EditoraAfiliada updateEditoraAfiliada)
        {
            if (_context is null || _context.EditorasAfiliadas is null)
                return NotFound();

            _context.EditorasAfiliadas.Update(updateEditoraAfiliada);
            _context.SaveChanges();

            return Ok(updateEditoraAfiliada);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteEditoraAfiliada([FromRoute] int id)
        {
            if (_context is null || _context.EditorasAfiliadas is null)
                return NotFound();

            var editoraAfiliada = await _context.EditorasAfiliadas.FindAsync(id);
            if (editoraAfiliada == null)
            {
                return NotFound();
            }

            _context.EditorasAfiliadas.Remove(editoraAfiliada);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
