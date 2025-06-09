using apbd_test3.Models;

namespace apbd_test3.DTOs;

public class NewPlayerDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public ICollection<NewPlayerMatchDTO> Matches { get; set; }
}

public class NewPlayerMatchDTO
{
    public int MatchId { get; set; }
    public int MVPs { get; set; }
    public decimal Rating { get; set; }
}