namespace Biblioteca_API.Repositorios
{
    public class BookRepositorio : IBookRepositorio
    {
        private readonly Biblioteca_API _dbContext;
        public BookRepositorio(BookDbContext)
        {
            _dbContext = BookDbContext;
        }

        public async Task<Book> BuscarPorId( int _id)
        {
            return _dbContext.Book.FirstOrDefaultAsync(x => x._id == _id)
        }

        public async Task<List<Book>> BuscarTodosOsLivros()
        {
            return _dbContext.Book.ToListAsync();
        }

        public async Task<Book> Adicionar(Book book)
        {
            await _dbContext.Book.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            return book;
        }
        public async Task<Book> Atualizar(Book book, int _id)
        {
            Book BookPorId = await BuscarPorId(_id)
            if (BookPorId == null)
            {
                throw new Exception($"Book para o id: {_id} Não foi encontrado no bacno de dados.");
            }

            BookPorId._title = book._title;
            BookPorId._author = book._author;
            BookPorId._publishingCompany = book._publishingCompany;
            BookPorId._genre = book._genre;
            BookPorId._synopsis = book._synopsis;

            _dbContext.Book.Update(BookPorId);
            await _dbContext.SaveChangesAsync();

            return BookPorId;
        }
        public async Task<bool> Apagar(int _id)
        {
            Book BookPorId = await BuscarPorId(_id)
            if (BookPorId == null)
            {
                throw new Exception($"Book para o id: {_id} Não foi encontrado no bacno de dados.");
            }

            _dbContext.Book.Remove(BookPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}