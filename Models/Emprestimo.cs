namespace Biblioteca_API.models
{
    public class Emprestimo
    {
        public Pessoa pessoa { get; set; }
        public Livro livro { get; set; }
        public DateTime dataDeEmprestimo { get; set; }
        public DateTime dataDeDevolucao { get; set; }
        public string ? status { get; set; }
        public double? valor { get; set; }
    }
}
