using Biblioteca_API.data;
using Biblioteca_API.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("/library")]
public class BookController : ControllerBase
{
    private BibliotecaDbContext _context;

    public BookController(BibliotecaDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("new-book")]
    public IActionResult NewBook([FromForm]Book book)
    {
        if (book == null)
            return BadRequest();

        _context.Add(book);
        _context.SaveChanges();
        return Created("Novo livro cadastrado!", book);
    }

    [HttpGet]
    [Route("books")]
    public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
    {
        var books = await _context.Book.ToListAsync();
        return Ok(books);
    }

    [HttpGet]
    [Route("book/{id}")]
    public async Task<ActionResult<Book>> GetBookById([FromRoute] int id)
    {
        var book = await _context.Book.FindAsync(id);
        if (book == null)
            return NotFound();

        return book;
    }

    [HttpPut]
    [Route("update-book/{id}")]
    public IActionResult UpdateBook([FromRoute] int id, Book updatedBook)
    {
        var book = _context.Book.Find(id);
        if (book == null)
            return NotFound();

        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;
        book.PublishingCompany = updatedBook.PublishingCompany;
        book.Genre = updatedBook.Genre;
        book.QuantStock = updatedBook.QuantStock;
        book.Synopsis = updatedBook.Synopsis;

        _context.Book.Update(book);
        _context.SaveChanges();

        return Ok(book);
    }

    [HttpDelete]
    [Route("delete-book/{id}")]
    public IActionResult DeleteBook([FromRoute] int id)
    {
        var book = _context.Book.Find(id);
        if (book == null)
            return NotFound();

        _context.Book.Remove(book);
        _context.SaveChanges();

        return NoContent();
    }
}