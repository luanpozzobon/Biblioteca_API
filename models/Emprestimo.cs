using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_API.models
{
    public class Emprestimo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int BookId { get; set; }
        public DateTime DataDeEmprestimo { get; set; }
        public DateTime DataDeDevolucao { get; set; }
    }
}
