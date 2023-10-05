using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_API.models
{
    public class Reservation
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }
        public Client? Client { get; set; }
        public Book? Book { get; set; }
        public string? Status { get; set; }
        public DateTime? ReservationDate { get; set; }
    }
}