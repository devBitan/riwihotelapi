using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RiwiHotelApi.Models;
public class Guest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [MaxLength(255)]
    [Column("first_name")]
    public string FirstName { get; set; }

    [MaxLength(255)]
    [Column("last_name")]
    public string LastName { get; set; }

    [MaxLength(255)]
    [Column("email")]
    public string Email { get; set; }

    [MaxLength(20)]
    [Column("identification_number")]
    public string IdentificationNumber { get; set; }

    [MaxLength(20)]
    [Column("phone_number")]
    public string PhoneNumber { get; set; }

    [Column("birthdate")]
    public DateTime Birthdate { get; set; }
}

