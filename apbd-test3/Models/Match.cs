using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd_test3.Models;

public class Match
{
    [Key]
    public int MatchId { get; set; }
    [Required] [ForeignKey(nameof(Tournament))]
    public int TournamentId { get; set; }
    [Required] [ForeignKey(nameof(Map))]
    public int MapId { get; set; }
    [Required]
    public DateTime MatchDate { get; set; }
    [Required]
    public int Team1Score { get; set; }
    [Required]
    public int Team2Score { get; set; }
    [Precision(4,2)]
    public decimal? BestRating { get; set; }
    
    public Tournament Tournament { get; set; }
    public Map Map { get; set; }
}