using System;

namespace Biblioteca_API.models
{
    public class Biblioteca
    {
        private int _quantEmployees;
        private int _quantBook;
        private bool _status;
        private DateTime _opened;
        private DateTime _closed;


        public int QuantEmployees
        {
            get => _quantEmployees;
            set => _quantEmployees = value;
        }

        public int QuantBook
        {
            get => _quantBook;
            set => _quantBook = value;
        }

        public bool Status
        {
            get => _status;
            set => _status = value;
        }

        public DateTime Opened
        {
            get => _opened;
            set => _opened = value;
        }
        
        public DateTime Closed
        {
            get => _closed;
            set => _closed = value;
        }
    }
}

