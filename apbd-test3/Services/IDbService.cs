using apbd_test3.DTOs;

namespace apbd_test3.Services;

public interface IDbService
{
    public Task<GetPlayerMatchesDTO> GetPlayerMatches(int id);
    public Task NewPlayer(NewPlayerDTO playerDto);
}