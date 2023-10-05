using System.ComponentModel.DataAnnotations;

namespace Biblioteca_API.models
{
    public class Client
    {
        [Key]
        public int Id {get; set;}
        public string? Cpf {get; set;}
        public string? Name {get; set;}
        public string? Email {get; set;}
        public string? PhoneNumber {get; set;}
        public DateTime BirthDate {get; set;}
        public string? BorrowedBookCount { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Owing { get; set; }
    }
}