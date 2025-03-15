using CQRS.Controllers;
using CQRS.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<VideoGameAppDbContext>(o =>
{
    o.UseInMemoryDatabase("VideoGameApp");
});
builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
