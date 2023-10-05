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
    public class EditoraAfiliadaController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;

        public EditoraAfiliadaController(BibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EditoraAfiliada>>> GetEditorasAfiliadas()
        {
            return await _context.EditorasAfiliadas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EditoraAfiliada>> GetEditoraAfiliada(int id)
        {
            var editoraAfiliada = await _context.EditorasAfiliadas.FindAsync(id);

            if (editoraAfiliada == null)
            {
                return NotFound();
            }

            return editoraAfiliada;
        }

        [HttpPost]
        public async Task<ActionResult<EditoraAfiliada>> PostEditoraAfiliada([FromForm]EditoraAfiliada editoraAfiliada)
        {
            _context.EditorasAfiliadas.Add(editoraAfiliada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEditoraAfiliada", new { id = editoraAfiliada.Id }, editoraAfiliada);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEditoraAfiliada(int id)
        {
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
