using Microsoft.AspNetCore.Mvc;
using Biblioteca_API.models;
using Biblioteca_API.data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca_API.Controllers
{
    [ApiController]
    [Route("/reservations")]
    public class ReservationController : ControllerBase
    {
        private readonly BibliotecaDbContext _context;

        public ReservationController(BibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("new-reservation")]
        public async Task<IActionResult> NewReservation([Required][FromForm] int clientId, [Required][FromForm] int bookId)
        {
            if (_context is null || _context.Reservation is null)
                return NotFound();

            if (clientId <= 0)
                return BadRequest("Id do cliente fora do range");
            if (bookId <= 0)
                return BadRequest("Id do livro fora do range");

            var client = await _context.Client.FindAsync(clientId);
            if (client is null)
                return NotFound("Cliente não encontrado!");
            var book = await _context.Book.FindAsync(bookId);
            if (book is null)
                return NotFound("Livro não encontrado!");

            if (book.QuantStock <= 0)
                return BadRequest("Book not available in stock.");

            book.QuantStock--;
            Reservation reservation = new Reservation(client.Id, book.Id, "Reservado", (DateTime.Now.AddDays(7)));

            _context.Book.Update(book);
            await _context.Reservation.AddAsync(reservation);
            await _context.SaveChangesAsync();

            return Created("Reserva criada com sucesso!", reservation);
        }

        [HttpGet]
        [Route("reservation/{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation == null)
                return NotFound();

            return reservation;
        }

        [HttpGet]
        [Route("all-reservations")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllReservations()
        {
            return await _context.Reservation.ToListAsync();
        }

        [HttpPost]
        [Route("check-reservations")]
        public async Task<IActionResult> CheckReservations()
        {
            var expiredReservations = _context.Reservation
                .Where(r => r.ReservationDate < DateTime.Now && r.Status != "Vencido").ToList();

            foreach (var reservation in expiredReservations)
            {
                var book = await _context.Book.FindAsync(reservation.BookId);
                if (book != null)
                {
                    book.QuantStock++;
                    _context.Update(book);
                }
                reservation.Status = "Vencido";
                _context.Reservation.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return Ok("Reservations checked and updated.");
        }
    }
}