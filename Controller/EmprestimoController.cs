/*
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Biblioteca_API.models;
using Biblioteca_API.data;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_API.Controller
{
    [ApiController]
    [Route("")]
    public class EmprestimoController : ControllerBase 
    {
        private readonly BibliotecaDbContext _context;

        public EmprestimoController(BibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emprestimo>>> GetEmprestimos()
        {
            return await _context.Emprestimo.ToListAsync();
        }

        [HttpGet("porLivro/{livroId}")]
        public async Task<ActionResult<IEnumerable<Emprestimo>>> GetEmprestimosPorLivro(int livroId)
        {
            var emprestimos = await _context.Emprestimo.Where(e => e.Book.Id == livroId).ToListAsync();

            if (emprestimos == null || emprestimos.Count == 0) { return NotFound(); }

            return emprestimos;
        }


        [HttpPost]
        public async Task<ActionResult<Emprestimo>> PostEmprestimo(Emprestimo emprestimo)
        {
            _context.Emprestimo.Add(emprestimo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmprestimo", new { id = emprestimo.Id }, emprestimo);
        }

    }
}
*/