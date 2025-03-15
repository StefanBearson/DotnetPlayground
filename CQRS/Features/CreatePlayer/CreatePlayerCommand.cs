using CQRS.Models;
using MediatR;

namespace CQRS.Features.CreatePlayer;

public record CreatePlayerCommand(string Name, int Level, int Score) : IRequest<int>;

// public class CreatePlayerCommand : IRequest<int>
// {
//     public string Name { get; set; } = String.Empty;
//     public int Level { get; set; } 
//     public int Score { get; set; }
// }

