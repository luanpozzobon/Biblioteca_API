using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_API.controllers
{
    public class EditoraAfiliadaController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class EditoraAfiliadaController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public EditoraAfiliadaController(ApplicationDbContext context)
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
            public async Task<ActionResult<EditoraAfiliada>> PostEditoraAfiliada(EditoraAfiliada editoraAfiliada)
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
}
