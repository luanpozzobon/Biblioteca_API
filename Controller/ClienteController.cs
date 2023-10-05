
using Microsoft.AspNetCore.Mvc;
using Biblioteca_API.models;
using Biblioteca_API.data;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> NewClient([FromForm] Client client)
        {
            if (client == null || string.IsNullOrEmpty(client.Cpf))
                return BadRequest("Client data is invalid.");

            var existingClient = await _context.Client.FirstOrDefaultAsync(c => c.Cpf == client.Cpf);
            if (existingClient != null)
                return BadRequest("A client with this CPF already exists.");

            _context.Client.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
        }

        [HttpGet]
        [Route("client/{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _context.Client.FindAsync(id);
            if (client == null)
                return NotFound();

            return client;
        }

        [HttpGet]
        [Route("all-clients")]
        public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
        {
            return await _context.Client.ToListAsync();
        }
        [HttpPut]
        [Route("update-client/{id}")]
        public IActionResult UpdateClient([FromRoute] int id, Client updateClient)
        {
            var client = _context.Client.Find(id);
            if (client == null)
                return NotFound();
            client.Cpf = updateClient.Cpf;
            client.Name = updateClient.Name;
            client.Email = updateClient.Email;
            client.PhoneNumber = updateClient.PhoneNumber;
            client.BorrowedBookCount = updateClient.BorrowedBookCount;
            client.RegistrationDate = updateClient.RegistrationDate;
            client.Owing = updateClient.Owing;

            _context.Client.Update(client);
            _context.SaveChanges();

            return Ok(client);
        }// n ta funcionando direito


        [HttpDelete]
        [Route("delete-client/{id}")]
        public IActionResult DeleteLibrary([FromRoute] int id)
        {
            var client = _context.Client.Find(id);
            if (client == null)
                return NotFound();

            _context.Client.Remove(client);
            _context.SaveChanges();

            return NoContent();
        }
    } // funcionado
}
