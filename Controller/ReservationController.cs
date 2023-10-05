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
        // Receber só o id do cliente e livro
        public async Task<IActionResult> NewReservation([FromForm] Reservation reservation)
        {
            // Search do livro e cliente
            if (reservation == null || string.IsNullOrEmpty(reservation.Client.Cpf) || reservation.Book == null)
                return BadRequest("Reservation data is invalid.");
            var book = await _context.Book.FindAsync(reservation.Book.Id);
            if (book != null && book.QuantStock > 0)
            {
                book.QuantStock--;
                _context.Update(book);
            }
            else
            {
                return BadRequest("Book not available in stock.");
            }

            _context.Reservation.Add(reservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReservation), new { id = reservation.ReservationId }, reservation);
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
            var expiredReservations = _context.Reservation.Where(r => r.ReservationDate < DateTime.Now && r.Status != "Vencido").ToList();

            foreach (var reservation in expiredReservations)
            {
                var book = await _context.Book.FindAsync(reservation.Book.Id);
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