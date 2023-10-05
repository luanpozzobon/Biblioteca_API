using System.ComponentModel.DataAnnotations;

namespace Biblioteca_API.models
{
    public class EditoraAfiliada
    {
        [Key]
        public int Id { get; set; }
        public string ? contato { get; set; }
        public string ? autores { get ; set; }
        public int qtdLivrosPublicados { get; set;}
    }
}