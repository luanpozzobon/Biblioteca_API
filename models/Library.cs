using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_API.models
{
    public class Library
    {
        private int _id;
        private int _quantEmployees;
        private int _quantBook;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get => _id;
            set => _id = value;
        }
    
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
    }
}

