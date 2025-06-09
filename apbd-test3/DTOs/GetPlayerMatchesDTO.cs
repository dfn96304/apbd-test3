namespace apbd_test3.DTOs;

public class GetPlayerMatchesDTO
{
    public int PlayerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    
    public ICollection<GetPlayerMatchesMatchDTO> Matches { get; set; }
}

public class GetPlayerMatchesMatchDTO
{
    public string Tournament { get; set; }
    public string Map { get; set; }
    public DateTime Date { get; set; }
    public int MVPs { get; set; }
    public decimal Rating { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
}