using apbd_test3.DTOs;
using apbd_test3.Exceptions;
using apbd_test3.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_test3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly IDbService _dbService;

    public PlayersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}/matches")]
    public async Task<IActionResult> GetPlayerMatches(int id)
    {
        try
        {
            var player = await _dbService.GetPlayerMatches(id);
            return Ok(player);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> NewPlayer(NewPlayerDTO playerDto)
    {
        try
        {
            await _dbService.NewPlayer(playerDto);
            return Created();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}