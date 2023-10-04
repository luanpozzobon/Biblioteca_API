using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Biblioteca_API.models;
using Biblioteca_API.data;
using Microsoft.EntityFrameworkCore;
using BIBLIOTECA_API.Models;

namespace BIBLIOTECA_API.controllers
{
    [ApiController]
    [Route("")]
    public class EmprestimoController : ControllerBase 
    {
        private readonly ApplicationDbContext _context;

        public EmprestimosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emprestimo>>> GetEmprestimos()
        {
            return await _context.Emprestimos.ToListAsync();
        }

        [HttpGet("porLivro/{livroId}")]
        public async Task<ActionResult<IEnumerable<Emprestimo>>> GetEmprestimosPorLivro(int livroId)
        {
            var emprestimos = await _context.Emprestimos
                .Where(e => e.Livro.Id == livroId)
                .ToListAsync();

            if (emprestimos == null || emprestimos.Count == 0)
            {
                return NotFound();
            }

            return emprestimos;
        }


        [HttpPost]
        public async Task<ActionResult<Emprestimo>> PostEmprestimo(Emprestimo emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmprestimo", new { id = emprestimo.Id }, emprestimo);
        }

    }
}