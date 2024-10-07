using Microsoft.EntityFrameworkCore;
using RiwiHotelApi.Models;
using RiwiHotelApi.Seeders;

namespace RiwiHotelApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Guest> Guests { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Seeders
        RoomTypeSeeder.Seed(modelBuilder);
    }
}
