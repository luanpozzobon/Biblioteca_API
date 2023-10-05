using System.ComponentModel.DataAnnotations;

namespace Biblioteca_API.models
{
    public class Worker
    {
        
        [Key]
        public int Id { get; set; }
        public string? Cpf { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Cargo { get; set; }    
    }
}
