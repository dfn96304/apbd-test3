using apbd_test3.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_test3.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Map> Maps { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerMatch> PlayerMatches { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Map>().HasData(new List<Map>
        {
            new Map(){ MapId = 1, Name = "a", Type = "a"}
        });

        modelBuilder.Entity<Tournament>().HasData(new List<Tournament>
        {
            new Tournament(){ TournamentId = 1, Name = "a", StartDate = DateTime.Parse("2025-01-01"), EndDate = DateTime.Parse("2025-01-02")},
        });

        modelBuilder.Entity<Player>().HasData(new List<Player>
        {
            new Player(){ PlayerId = 1, FirstName = "A", LastName = "B", BirthDate = DateOnly.Parse("2001-01-01")},
            new Player(){ PlayerId = 2, FirstName = "C", LastName = "D", BirthDate = DateOnly.Parse("2002-01-01")},
        });

        modelBuilder.Entity<Match>().HasData(new List<Match>
        {
            new Match(){ MatchId = 1, TournamentId = 1, MapId = 1, MatchDate = DateTime.Parse("2025-01-01"), Team1Score = 2, Team2Score = 1 },
        });

        modelBuilder.Entity<PlayerMatch>().HasData(new List<PlayerMatch>
        {
            new PlayerMatch(){ MatchId = 1, MVPs = 1, PlayerId = 1, Rating = 1}
        });
    }
}