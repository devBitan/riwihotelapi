using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RiwiHotelApi.Models;
public class Booking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("start_date")]
    public DateTime StartDate { get; set; }

    [Column("end_date")]
    public DateTime EndDate { get; set; }

    [Column("total_cost")]
    public double TotalCost { get; set; }

    [ForeignKey("rooms")]
    [Column("room_id")]
    public int RoomId { get; set; }

    [ForeignKey("guests")]
    [Column("guest_id")]
    public int GuestId { get; set; }

    [ForeignKey("employees")]
    [Column("employee_id")]
    public int EmployeeId { get; set; }
}

