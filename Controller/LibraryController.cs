using Biblioteca_API.data;
using Biblioteca_API.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Biblioteca_API.Controllers
{
    [ApiController]
    [Route("/library")]
    public class LibraryController : ControllerBase
    {
        private BibliotecaDbContext _context;

        public LibraryController(BibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("new-library")]
        public IActionResult NewLibrary([FromForm] Library biblioteca)
        {
            if (biblioteca == null)
                return BadRequest();

            _context.Add(biblioteca);
            _context.SaveChanges();
            return Created("Nova biblioteca cadastrada!", biblioteca);
        }

        [HttpGet]
        [Route("libraries")]
        public async Task<ActionResult<IEnumerable<Library>>> GetAllLibraries()
        {
            var libraries = await _context.Library.ToListAsync();
            return Ok(libraries);
        }

        [HttpGet]
        [Route("library/{id}")]
        public async Task<ActionResult<Library>> GetLibraryById([FromRoute] int id)
        {
            var library = await _context.Library.FindAsync(id);
            if (library == null)
                return NotFound();

            return library;
        }

        [HttpPut]
        [Route("update-library/{id}")]
        public IActionResult UpdateLibrary([FromRoute] int id, Library updatedLibrary)
        {
            var library = _context.Library.Find(id);
            if (library == null)
                return NotFound();

            library.QuantEmployees = updatedLibrary.QuantEmployees;
            library.QuantBook = updatedLibrary.QuantBook;

            _context.Library.Update(library);
            _context.SaveChanges();

            return Ok(library);
        }

        [HttpDelete]
        [Route("delete-library/{id}")]
        public IActionResult DeleteLibrary([FromRoute] int id)
        {
            var library = _context.Library.Find(id);
            if (library == null)
                return NotFound();

            _context.Library.Remove(library);
            _context.SaveChanges();

            return NoContent();
        }
    }
}    
