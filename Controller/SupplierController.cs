using Biblioteca_API.models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/supplier")]
public class SupplierController
{
    private BibliotecaDbContext _context;

    public StudyRoomController(BibliotecaDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("new")]
    public async IActionResult NewSupplier(Supplier supplier)
    {
        if (_context is null || _context.Supplier is null)
            return NotFound();
        if (supplier == null)
            return BadRequest();

        _context.Add(supplier);
        _context.SaveChanges();
        return Created(supplier);
    }

    [HttpGet]
    [Route("current")]
    public async Task<ActionResult<IEnumerable<Supplier>>> SearchSupplier()
    {
        if (_context is null || _context.Supplier is null)
            return NotFound();

        return await _context.Supplier
            .Where(supplier => supplier.CurrentContract)
            .ToListAsync();
    }
}
