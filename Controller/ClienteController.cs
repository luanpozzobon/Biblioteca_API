using Microsoft.AspNetCore.Mvc;
using Biblioteca_API.models;
using Biblioteca_API.data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Biblioteca_API.Controllers
{
    [ApiController]
    [Route("/clients")]
    public class ClientController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;

        public ClientController(BibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("new-client")]
        public async Task<IActionResult> NewClient(Client client)
        {
            if (client == null || string.IsNullOrEmpty(client.CPF))
                return BadRequest("Client data is invalid.");

            var existingClient = await _context.Clients.FirstOrDefaultAsync(c => c.CPF == client.CPF);
            if (existingClient != null)
                return BadRequest("A client with this CPF already exists.");

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
        }

        [HttpGet]
        [Route("client/{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return NotFound();

            return client;
        }

        [HttpGet]
        [Route("all-clients")]
        public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
        {
            return await _context.Clients.ToListAsync();
        }
    }
}
