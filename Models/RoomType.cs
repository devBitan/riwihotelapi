using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RiwiHotelApi.Models;
[Table("room_types")]

public class RoomType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [MaxLength(50)]
    [Column("name")]
    public string Name { get; set; }

    [MaxLength(255)]
    [Column("description")]
    public string Description { get; set; }
}



