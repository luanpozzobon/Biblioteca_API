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
    public async Task<IActionResult> NewRoom([FromForm] StudyRoom studyRoom)
    {
        if (_context is null || _context.StudyRoom is null)
            return NotFound();

        if (studyRoom is null)
            return BadRequest();

        await _context.AddAsync(studyRoom);
        await _context.SaveChangesAsync();
        return Created("Criada nova sala de estudo!", studyRoom);
    }

    [HttpGet]
    [Route("free-rooms")]
    public async Task<ActionResult<IEnumerable<StudyRoom>>> FreeRooms()
    {
        if (_context is null || _context.StudyRoom is null)
            return NotFound();
        
        return await _context.StudyRoom
            .Where(room => room.IsAvailable)
            .ToListAsync();
    }

    [HttpGet]
    [Route("number")]
    public async Task<ActionResult<StudyRoom>> SearchRoom(int number)
    {
        if (_context is null || _context.StudyRoom is null)
            return NotFound();
        
        var room = await _context.StudyRoom.FindAsync(number);
        if (room is null)
            return NotFound();

        return room;
    }

    [HttpGet]
    [Route("capacity")]
    public async Task<ActionResult<IEnumerable<StudyRoom>>> FindRoomsByCapacity(int capacity)
    {
        if (_context is null || _context.StudyRoom is null)
            return NotFound();

        return await _context.StudyRoom
            .Where (room => room.IsAvailable)
            .Where (room => room.Capacity >= capacity)
            .ToListAsync();
    }

    [HttpPatch]
    [Route("change-occupation")]
    public async Task<ActionResult> ChangeOccupation(int number)
    {
        if (_context is null || _context.StudyRoom is null)
            return NotFound();
        
        var room = await _context.StudyRoom.FindAsync(number);

        room.IsAvailable = !room.IsAvailable;
        _context.StudyRoom.Update(room);
        await _context.SaveChangesAsync();
        return Ok();
    }
}