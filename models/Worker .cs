using System.ComponentModel.DataAnnotations;

namespace Biblioteca_API.models
{
    public class Worker
    {
        private int _id;
        private string _cpf;
        private string _name;
        private string _email;
        private string _phone;
        private Address _address;
        private string _cargo;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string CPF
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

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }
    }
}
