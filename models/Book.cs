using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_API.models
{
    public class Book 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublishingCompany { get; set; }
        public string Genre { get; set; }
        public int QuantStock { get; set; }
        public string Synopsis { get; set; }

        /*
        private int _id;
        private string? _title;
        private string? _author;
        private string? _publishingCompany;
        private string? _genre;
        private int _quantStock;
        private string? _synopsis;


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id 
        {
            get => _id;
            set => _id = value;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Author
        {
            get => _author;
            set => _author = value;
        }

        public string PublishingCompany
        {
            get => _publishingCompany;
            set => _publishingCompany = value;
        }

        public string Genre 
        {
            get => _genre;
            set => _genre = value;
        }

        public int QuantStock
        {
            get => _quantStock;
            set => _quantStock = value;
        }

        public string Synopsis
        {
            get => _synopsis;
            set => _synopsis = value;
        }
        */
    }
}