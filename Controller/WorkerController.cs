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
    [Route("/worker")]
    public class WorkerController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;

        public WorkerController(BibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("new-worker")]
        public async Task<IActionResult> NewWorker([FromForm] Worker worker)
        {
            if (worker == null || string.IsNullOrEmpty(worker.Cpf))
                return BadRequest("Worker data is invalid.");

            var existingWorker = await _context.Worker.FirstOrDefaultAsync(w => w.Cpf == worker.Cpf);
            if (existingWorker != null)
                return BadRequest("A worker with this CPF already exists.");

            _context.Worker.Add(worker);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorker), new { id = worker.Id }, worker);
        }

        [HttpGet]
        [Route("worker/{id}")]
        public async Task<ActionResult<Worker>> GetWorker(int id)
        {
            var worker = await _context.Worker.FindAsync(id);
            if (worker == null)
                return NotFound();

            return worker;
        }

        [HttpGet]
        [Route("all-workers")]
        public async Task<ActionResult<IEnumerable<Worker>>> GetAllWorkers()
        {
            return await _context.Worker.ToListAsync();
        }
        
        [HttpPut]
        [Route("update-client/{id}")]
        public IActionResult UpdateWorker([FromRoute] int id, Worker updateWorker)
        {
            var worker = _context.Worker.Find(id);
            if (worker == null)
                return NotFound();
            worker.Cpf = updateWorker.Cpf;
            worker.Name = updateWorker.Name;
            worker.Email = updateWorker.Email;
            worker.Phone = updateWorker.Phone;
            worker.Cargo= updateWorker.Cargo;

            _context.Worker.Update(worker);
            _context.SaveChanges();

            return Ok(worker);
        }// n ta funcionando direito


        [HttpDelete]
        [Route("delete-worker/{id}")]
        public IActionResult DeleteLibrary([FromRoute] int id)
        {
            var worker = _context.Worker.Find(id);
            if (worker == null)
                return NotFound();

            _context.Worker.Remove(worker);
            _context.SaveChanges();

            return NoContent();
        }
    } // funcionado
}