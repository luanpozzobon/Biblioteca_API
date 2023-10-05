using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca_API.models
{
    public class Reservation
    {
        
        [Key]
        public int ReservationId { get; set; }
        public Client? Client { get; set; }
        public Book? Book { get; set; }
        public String? Status { get; set; }
        public DateTime? ReservationDate { get; set; }
    }
}