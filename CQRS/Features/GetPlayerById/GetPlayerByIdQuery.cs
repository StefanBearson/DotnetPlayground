using CQRS.Models;
using MediatR;

namespace CQRS.Features.GetPlayerById;

public record GetPlayerByIdQuery(int Id) : IRequest<Player?>;
