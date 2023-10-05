using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_API.models
{
    public class Reservation
    {
        public int _id;
        public int _clientId;
        public int _bookId;
        public string _status;
        public DateTime _reservationDate;


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        [ForeignKey(nameof(Client))]
        public int ClientId
        {
            get => _clientId;
            set => _clientId = value;
        }

        [ForeignKey(nameof(Book))]
        public int BookId
        {
            get => _bookId;
            set => _bookId = value;
        }

        public string Status
        {
            get => _status;
            set => _status = value;
        }

        public DateTime ReservationDate
        {
            get => _reservationDate;
            set => _reservationDate = value;
        }

        public Reservation() { }

        public Reservation (int clientId, int bookId, string status, DateTime reservationDate)
        {
            _clientId = clientId;
            _bookId = bookId;
            _status = status;
            _reservationDate = reservationDate;
        }

        public Reservation(int id, int clientId, int bookId, string status, DateTime reservationDate)
        {
            _id = id;
            _clientId = clientId;
            _bookId = bookId;
            _status = status;
            _reservationDate = reservationDate;
        }
    }
}