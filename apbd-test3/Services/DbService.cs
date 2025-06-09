using apbd_test3.Data;
using apbd_test3.DTOs;
using apbd_test3.Exceptions;
using apbd_test3.Models;

namespace apbd_test3.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<GetPlayerMatchesDTO> GetPlayerMatches(int id)
    {
        var player = _context.Players.Where(p => p.PlayerId == id).Select(p => new GetPlayerMatchesDTO()
        {
            PlayerId = p.PlayerId,
            FirstName = p.FirstName,
            LastName = p.LastName,
            BirthDate = p.BirthDate,
            Matches = _context.PlayerMatches.Where(pm => pm.PlayerId == id).Select(pm => new GetPlayerMatchesMatchDTO()
            {
                Tournament = pm.Match.Tournament.Name,
                Map = pm.Match.Map.Name,
                Date = pm.Match.MatchDate,
                MVPs = pm.MVPs,
                Rating = pm.Rating,
                Team1Score = pm.Match.Team1Score,
                Team2Score = pm.Match.Team2Score,
            }).ToList()
        }).ToList();
        
        if(player.Count == 0)
            throw new NotFoundException("The player with the given id was not found");

        return player[0];
    }

    public async Task NewPlayer(NewPlayerDTO playerDto)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var player = _context.Players.Add(new Player()
                {
                    FirstName = playerDto.FirstName,
                    LastName = playerDto.LastName,
                    BirthDate = playerDto.BirthDate,
                }).Entity;
                
                foreach (NewPlayerMatchDTO matchDto in playerDto.Matches)
                {
                    var match = _context.Matches.FirstOrDefault(match => match.MatchId == matchDto.MatchId);
                    if (match == null)
                    {
                        throw new BadRequestException("The match with the given id was not found");
                    }
                    
                    _context.PlayerMatches.Add(new PlayerMatch()
                    {
                        MatchId = matchDto.MatchId,
                        PlayerId = player.PlayerId,
                        MVPs = matchDto.MVPs,
                        Rating = matchDto.Rating,
                        Match = match,
                        Player = player,
                    });

                    if (match.BestRating == null || matchDto.Rating > match.BestRating)
                    {
                        match.BestRating = matchDto.Rating;
                        _context.Matches.Update(match);
                    }
                }
                
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}