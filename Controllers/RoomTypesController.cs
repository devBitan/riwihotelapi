using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiwiHotelApi.Data;
using RiwiHotelApi.Models;

[ApiController]
[Route("api/[controller]")]
public class RoomTypesController : ControllerBase
{
    private readonly AppDbContext _context;

    public RoomTypesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/RoomTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoomType>>> GetRoomTypes()
    {
        return await _context.RoomTypes.ToListAsync();
    }

    // GET: api/RoomTypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RoomType>> GetRoomType(int id)
    {
        var roomType = await _context.RoomTypes.FindAsync(id);

        if (roomType == null)
        {
            return NotFound();
        }

        return roomType;
    }

    // POST: api/RoomTypes
    [HttpPost]
    public async Task<ActionResult<RoomType>> PostRoomType(RoomType roomType)
    {
        _context.RoomTypes.Add(roomType);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRoomType), new { id = roomType.Id }, roomType);
    }

    // PUT: api/RoomTypes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRoomType(int id, RoomType roomType)
    {
        if (id != roomType.Id)
        {
            return BadRequest();
        }

        _context.Entry(roomType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RoomTypeExists(id))
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
    public async Task<IActionResult> DeleteRoomType(int id)
    {
        var roomType = await _context.RoomTypes.FindAsync(id);
        if (roomType == null)
        {
            return NotFound();
        }

        _context.RoomTypes.Remove(roomType);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RoomTypeExists(int id)
    {
        return _context.RoomTypes.Any(e => e.Id == id);
    }
}
