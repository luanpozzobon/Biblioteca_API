using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_API.models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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