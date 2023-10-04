using System;

namespace Biblioteca_API.models
{
    public class Book 
    {
        private int _id;
        private string? _title;
        private string? _author;
        private string? _publishingCompany;
        private string? _genre;
        private int _quantStock;
        private string? _synopsis;


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
    }
}