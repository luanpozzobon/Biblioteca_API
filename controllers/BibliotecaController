using Microsoft.AspNetCore.Mvc;
using Biblioteca_API.models;
using Biblioteca_API.data;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("")]
public class BibliotecaController : ControllerBase {
    private BibliotecaDbContext? _context;

    public BibliotecaController(BibliotecaDbContext context) {
        _context = context;
    }
}