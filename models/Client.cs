using System;

namespace Biblioteca_API.models
{
    public class Client
    {
        private int _id;
        private string _cpf; 
        private string _name;
        private string _email;
        private string _phoneNumber;
        private DateTime _birthDate;
        private Address _address;
        private string _borrowedBookCount; 
        private DateTime _registrationDate;
        private bool _owing;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string BorrowedBookCount
        {
            get { return _borrowedBookCount; }
            set { _borrowedBookCount = value; }
        }

        public DateTime RegistrationDate
        {
            get { return _registrationDate; }
            set { _registrationDate = value; }
        }

        public bool Owing
        {
            get { return _owing; }
            set { _owing = value; }
        }
    }
}
