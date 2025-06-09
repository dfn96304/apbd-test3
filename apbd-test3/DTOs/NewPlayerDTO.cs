using System.ComponentModel.DataAnnotations;
using apbd_test3.Models;

namespace apbd_test3.DTOs;

public class NewPlayerDTO
{
    [Required] [MaxLength(50)]
    public string FirstName { get; set; }
    [Required] [MaxLength(100)]
    public string LastName { get; set; }
    [Required]
    public DateOnly BirthDate { get; set; }
    [Required]
    public ICollection<NewPlayerMatchDTO> Matches { get; set; }
}

public class NewPlayerMatchDTO
{
    [Required]
    public int MatchId { get; set; }
    [Required]
    public int MVPs { get; set; }
    [Required]
    public decimal Rating { get; set; }
}