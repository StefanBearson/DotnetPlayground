using CQRS.Data;
using CQRS.Models;
using MediatR;

namespace CQRS.Features.CreatePlayer;

public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
{
    private readonly VideoGameAppDbContext _context;
    
    public CreatePlayerCommandHandler(VideoGameAppDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        Player player = new()
        {
            Name = request.Name,
            Level = request.Level,
            Score = request.Score
        };
        
        _context.Players.Add(player);
        await _context.SaveChangesAsync(cancellationToken);

        return player.Id;
    }
}