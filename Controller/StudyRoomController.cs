using Microsoft.AspNetCore.Mvc;
using Biblioteca_API.models;
using Biblioteca_API.data;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("/study-room")]
public class StudyRoomController : ControllerBase
{
    private readonly BibliotecaDbContext _context;

    public StudyRoomController(BibliotecaDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("new-room")]
    public IActionResult NewRoom([FromForm] StudyRoom studyRoom)
    {
        if (studyRoom == null)
            return BadRequest();

        _context.Add(studyRoom);
        _context.SaveChanges();
        return Created("Criada nova sala de estudo!", studyRoom);
    }

    [HttpGet]
    [Route("free-rooms")]
    public async Task<ActionResult<IEnumerable<StudyRoom>>> FreeRooms()
    {
        if (_context is null)
            return NotFound();
        if (_context.StudyRoom is null)
            return NotFound();

        return await _context.StudyRoom
            .Where(room => room.IsAvailable)
            .ToListAsync();
    }

    [HttpGet]
    [Route("room/{number}")]
    public async Task<ActionResult<StudyRoom>> SearchRoom([FromRoute] int number)
    {
        if (_context is null)
            return NotFound();
        if (_context.StudyRoom is null)
            return NotFound();

        var room = await _context.StudyRoom.FindAsync(number);
        if (room is null)
            return NotFound();

        return room;
    }

    [HttpPatch]
    [Route("change-occupation/{number}")]
    public async Task<ActionResult> ChangeOccupation([FromRoute] int number)
    {
        if (_context is null)
            return NotFound();
        if (_context.StudyRoom is null)
            return NotFound();

        var room = await _context.StudyRoom.FindAsync(number);

        room.IsAvailable = !room.IsAvailable;
        _context.StudyRoom.Update(room);
        await _context.SaveChangesAsync();
        return Ok();
    }
}