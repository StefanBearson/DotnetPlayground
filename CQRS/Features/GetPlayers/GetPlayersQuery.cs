using CQRS.Models;
using MediatR;

namespace CQRS.Features.GetPlayers;

public record GetPlayersQuery : IRequest<IEnumerable<Player>>;
