using CQRS.Data;
using CQRS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Features.GetPlayers;

public class GetPlayersQueryHandler: IRequestHandler<GetPlayersQuery, IEnumerable<Player>>
{
    private readonly VideoGameAppDbContext _context;
    
    public GetPlayersQueryHandler(VideoGameAppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Player>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Players.ToListAsync(cancellationToken);
    }
}