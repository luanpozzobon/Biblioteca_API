using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_API.models
{

    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DataDoEvento { get; set; }
        public decimal ValorDoEvento { get; set; }
        public int QuantidadeDePessoa { get; set; }
        public string? Editora { get; set; }
        public string? Livro { get; set;}
        }
    }