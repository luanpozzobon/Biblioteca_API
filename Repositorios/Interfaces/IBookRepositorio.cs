using Biblioteca_API.models;

namespace Biblioteca_API.Repositorios.Interface 
{
    public interface IBookRepositorio
    {
        Task<List<Book>> BuscarTodosOsLivros();
        Task<Book> BuscarPorId( int _id);
        Task<Book> Adicionar(Book book);
        Task<Book> Atualizar(Book book, int _id);
        Task<bool> Apagar(int _id);

    }
}