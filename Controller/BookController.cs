using Biblioteca_API.models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_API.data
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("/book")]

    public class BookController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> BuscarTodosOsLivros()
        {
            return Ok();
        }
    }
}
