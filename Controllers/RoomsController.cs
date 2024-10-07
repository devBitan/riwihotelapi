using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiwiHotelApi.Data;
using RiwiHotelApi.Models;

namespace RiwiHotelApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RoomsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/RoomTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
    {
        return await _context.Rooms.ToListAsync();
    }
    [HttpGet("occupied")]
    public async Task<ActionResult<IEnumerable<Room>>> GetOccupiedRooms()
    {
        var occupiedRooms = await _context.Rooms
            .Where(r => r.Availability == false) // O false, según cómo definas el estado
            .ToListAsync();

        return occupiedRooms;
    }

    [HttpGet("status")]
    public async Task<ActionResult<IEnumerable<object>>> GetRoomStatus()
    {
        var roomStatus = await _context.Rooms
            .Select(r => new
            {
                r.RoomNumber,
                r.PricePerNight,
                r.Availability, // Puedes mostrar esto como "Disponible" o "Ocupada" si es booleano
                Status = r.Availability ? "Disponible" : "Ocupada"
            })
            .ToListAsync();

        return roomStatus;
    }
    
    [HttpGet("available")]
    public async Task<ActionResult<IEnumerable<Room>>> GetAvailableRooms()
    {
        var availableRooms = await _context.Rooms
            .Where(r => r.Availability == true) // true representa habitaciones disponibles
            .ToListAsync();

        return availableRooms;
    }

    // GET: api/RoomTypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetRoom(int id)
    {
        var room = await _context.Rooms.FindAsync(id);

        if (room == null)
        {
            return NotFound();
        }

        return room;
    }

    // POST: api/RoomTypes
    [HttpPost]
    public async Task<ActionResult<Room>> PostRoom(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRoom), new { id = room.Id }, room);
    }

    // PUT: api/RoomTypes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRoom(int id, Room room)
    {
        if (id != room.Id)
        {
            return BadRequest();
        }

        _context.Entry(room).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RoomExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/RoomTypes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null)
        {
            return NotFound();
        }

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RoomExists(int id)
    {
        return _context.Rooms.Any(e => e.Id == id);
    }
}
