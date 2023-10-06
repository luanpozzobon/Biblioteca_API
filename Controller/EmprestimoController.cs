
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Biblioteca_API.models;
using Biblioteca_API.data;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_API.Controller
{
    [ApiController]
    [Route("emprestimo")]
    public class EmprestimoController : ControllerBase 
    {
        private readonly BibliotecaDbContext _context;

        public EmprestimoController(BibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<Emprestimo>>> GetEmprestimos()
        {
            if (_context is null || _context.Emprestimo is null)
                return NotFound();
                
            return await _context.Emprestimo.ToListAsync();
        }

        [HttpGet]
        [Route("findById/{id}")]
        public async Task<ActionResult<IEnumerable<Emprestimo>>> GetEmprestimosPorLivro(int livroId)
        {
            if (_context is null || _context.Emprestimo is null)
                return NotFound();
                
            var emprestimos = await _context.Emprestimo.Where(e => e.BookId == livroId).ToListAsync();

            if (emprestimos == null || emprestimos.Count == 0) { return NotFound(); }

            return emprestimos;
        }


        [HttpPost]
        [Route("new")]
        public async Task<ActionResult<Emprestimo>> PostEmprestimo([FromForm] Emprestimo emprestimo)
        {
            if (_context is null || _context.Emprestimo is null)
                return NotFound();
            
            _context.Emprestimo.Add(emprestimo);
            await _context.SaveChangesAsync();

            return Created("Emprestimo criado com sucesso!", emprestimo);
        }


        [HttpDelete]
        [Route("delete-emprestimo/{id}")]
        public IActionResult DeleteEmprestimo([FromRoute] int id)
        {
            if (_context is null || _context.Emprestimo is null)
                return NotFound();

            var emprestimo = _context.Emprestimo.Find(id);
            if (emprestimo == null)
                return NotFound();

            _context.Emprestimo.Remove(emprestimo);
            _context.SaveChanges();

            return NoContent();
        } 

    }
}
