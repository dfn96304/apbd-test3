using System.ComponentModel.DataAnnotations;

namespace apbd_test3.Models;

public class Tournament
{
    [Key]
    public int TournamentId { get; set; }
    [Required] [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
}