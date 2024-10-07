using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RiwiHotelApi.Models;

public class Room
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [MaxLength(10)]
    [Column("room_number")]
    public string RoomNumber { get; set; }

    [Column("price_per_night")]
    public double PricePerNight { get; set; }

    [Column("availability")]
    public bool Availability { get; set; }

    [Column("max_occupancy_persons")]
    public int MaxOccupancyPersons { get; set; }

    [ForeignKey("room_types")]
    [Column("room_type_id")]
    public int RoomTypeId { get; set; }
}



