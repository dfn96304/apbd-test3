using System.ComponentModel.DataAnnotations;

namespace apbd_test3.Models;

public class Player
{
    [Key]
    public int PlayerId { get; set; }
    [Required] [MaxLength(50)]
    public string FirstName { get; set; }
    [Required] [MaxLength(100)]
    public string LastName { get; set; }
    [Required]
    public DateOnly BirthDate { get; set; } //
}