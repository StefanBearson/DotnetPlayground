using CQRS.Data;
using CQRS.Models;
using MediatR;

namespace CQRS.Features.GetPlayerById;

public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Player?>
{
    private readonly VideoGameAppDbContext _context;
    
    public GetPlayerByIdQueryHandler(VideoGameAppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Player?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        var player = await _context.Players.FindAsync(request.Id);
        
        return player;
    }
}