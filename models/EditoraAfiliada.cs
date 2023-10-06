using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_API.models
{
    public class EditoraAfiliada
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ? contato { get; set; }
        public string ? autores { get ; set; }
        public int qtdLivrosPublicados { get; set;}
    }
}