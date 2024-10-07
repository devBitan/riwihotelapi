using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiwiHotelApi.Data;
using RiwiHotelApi.Models;

namespace RiwiHotelApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class GuestsController : ControllerBase
{
    private readonly AppDbContext _context;

    public GuestsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/RoomTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Guest>>> GetGuests()
    {
        return await _context.Guests.ToListAsync();
    }

    // GET: api/RoomTypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Guest>> GetGuest(int id)
    {
        var guest = await _context.Guests.FindAsync(id);

        if (guest == null)
        {
            return NotFound();
        }

        return guest;
    }

    // POST: api/RoomTypes
    [HttpPost("login")]
    public async Task<ActionResult<Guest>> PostGuest(Guest guest)
    {
        _context.Guests.Add(guest);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGuest), new { id = guest.Id }, guest);
    }

    // PUT: api/RoomTypes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGuest(int id, Guest guest)
    {
        if (id != guest.Id)
        {
            return BadRequest();
        }

        _context.Entry(guest).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GuestExists(id))
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
    public async Task<IActionResult> DeleteGuest(int id)
    {
        var guest = await _context.Guests.FindAsync(id);
        if (guest == null)
        {
            return NotFound();
        }

        _context.Guests.Remove(guest);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool GuestExists(int id)
    {
        return _context.Rooms.Any(e => e.Id == id);
    }
}
