using CQRS.Data;
using CQRS.Features.CreatePlayer;
using CQRS.Features.GetPlayerById;
using CQRS.Features.GetPlayers;
using CQRS.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly ISender _sender;
    
    public PlayerController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post(CreatePlayerCommand command)
    {
        var playerId = await _sender.Send(command);
        
        return Ok(playerId);
    }
    
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Player>> GetPlayerById(int id)
    {
        var player = await _sender.Send(new GetPlayerByIdQuery(id));

        if (player == null) return NotFound();
        
        return Ok(player);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Player>>> GetPlayers()
    {
        var players = await _sender.Send(new GetPlayersQuery());

        return Ok(players);
    }
}