using Microsoft.AspNetCore.Mvc;
using Biblioteca_API.Models;
using Biblioteca_API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
        public IActionResult NewLibrary(Biblioteca biblioteca)
        {
            if (biblioteca == null)
                return BadRequest();

            _context.Add(biblioteca);
            _context.SaveChanges();
            return Created("Nova biblioteca cadastrada!", biblioteca);
        }

        [HttpGet]
        [Route("libraries")]
        public async Task<ActionResult<IEnumerable<Biblioteca>>> GetAllLibraries()
        {
            var libraries = await _context.Libraries.ToListAsync();
            return Ok(libraries);
        }

        [HttpGet]
        [Route("library/{id}")]
        public async Task<ActionResult<Biblioteca>> GetLibraryById([FromRoute] int id)
        {
            var library = await _context.Libraries.FindAsync(id);
            if (library == null)
                return NotFound();

            return library;
        }

        [HttpPut]
        [Route("update-library/{id}")]
        public IActionResult UpdateLibrary([FromRoute] int id, Biblioteca updatedLibrary)
        {
            var library = _context.Libraries.Find(id);
            if (library == null)
                return NotFound();

            library.QuantEmployees = updatedLibrary.QuantEmployees;
            library.QuantBook = updatedLibrary.QuantBook;
            library.Status = updatedLibrary.Status;
            library.Opened = updatedLibrary.Opened;
            library.Closed = updatedLibrary.Closed;

            _context.Libraries.Update(library);
            _context.SaveChanges();

            return Ok(library);
        }

        [HttpDelete]
        [Route("delete-library/{id}")]
        public IActionResult DeleteLibrary([FromRoute] int id)
        {
            var library = _context.Libraries.Find(id);
            if (library == null)
                return NotFound();

            _context.Libraries.Remove(library);
            _context.SaveChanges();

            return NoContent();
        }
    }
}    
