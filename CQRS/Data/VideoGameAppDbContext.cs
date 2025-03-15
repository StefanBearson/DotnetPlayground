using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Data;

public class VideoGameAppDbContext(DbContextOptions<VideoGameAppDbContext> options) : DbContext(options)
{
    public DbSet<Player> Players { get; set; }
}