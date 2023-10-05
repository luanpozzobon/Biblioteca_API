using Microsoft.AspNetCore.Mvc;
using Biblioteca_API.models;
using Biblioteca_API.data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks; // Adicione esta diretiva para trabalhar com tarefas assíncronas
using System.Linq;
using System.Collections.Generic;

namespace Biblioteca_API.Controller
{
    [ApiController]
    [Route("supplier")]
    public class SupplierController : ControllerBase // Herde de ControllerBase para evitar o erro no retorno NotFound()
    {
        private BibliotecaDbContext _context;

        public SupplierController(BibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> NewSupplier([FromForm] Supplier supplier) // Marque o método como assíncrono
        {
            if (_context is null || _context.Supplier is null)
                return NotFound();
            if (supplier == null)
                return BadRequest();

            await _context.AddAsync(supplier);
            await _context.SaveChangesAsync(); // Use await aqui
            return Created(nameof(NewSupplier), supplier); // Corrija o retorno para Created
        }

        [HttpGet]
        [Route("current")]
        public async Task<ActionResult<IEnumerable<Supplier>>> SearchSupplier()
        {
            if (_context is null || _context.Supplier is null)
                return NotFound();

            var suppliers = await _context.Supplier
                .Where(supplier => supplier.ContractStatus)
                .ToListAsync();

            return Ok(suppliers); // Use Ok() para retornar 200 OK com os dados
        }
    }
}
