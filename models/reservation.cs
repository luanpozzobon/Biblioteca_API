using System;

namespace Biblioteca_API.models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public Person Person { get; set; }
        public Book Book { get; set; }
        public string Status { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
