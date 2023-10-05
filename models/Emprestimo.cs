using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_API.models
{
    public class Emprestimo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Client pessoa { get; set; }
        public Book livro { get; set; }
        public DateTime dataDeEmprestimo { get; set; }
        public DateTime dataDeDevolucao { get; set; }
        public string ? status { get; set; }
        public double valor { get; set; }
    }
}
