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
        public async Task<IActionResult> NewReservation(Reservation reservation)
        {
            if (reservation == null || string.IsNullOrEmpty(reservation.Pessoa.CPF) || reservation.Livro == null)
                return BadRequest("Reservation data is invalid.");
            var book = await _context.Books.FindAsync(reservation.Livro.Id);
            if (book != null && book.QuantidadeEmEstoque > 0)
            {
                book.QuantidadeEmEstoque--;
                _context.Update(book);
            }
            else
            {
                return BadRequest("Book not available in stock.");
            }

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReservation), new { id = reservation.IdReserva }, reservation);
        }

        [HttpGet]
        [Route("reservation/{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
                return NotFound();

            return reservation;
        }

        [HttpGet]
        [Route("all-reservations")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        [HttpPost]
        [Route("check-reservations")]
        public async Task<IActionResult> CheckReservations()
        {
            var expiredReservations = _context.Reservations.Where(r => r.DataReserva < DateTime.Now && r.Situacao != "Vencido").ToList();

            foreach (var reservation in expiredReservations)
            {
                var book = await _context.Books.FindAsync(reservation.Livro.Id);
                if (book != null)
                {
                    book.QuantidadeEmEstoque++;
                    _context.Update(book);
                }
                reservation.Situacao = "Vencido";
                _context.Reservations.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return Ok("Reservations checked and updated.");
        }
    }
}
