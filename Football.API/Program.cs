using Football.API.Application.Queries;
using Football.Domain.Models;
using Football.Infrastructure;
using Football.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddTransient<IManagerQueries, ManagerQueries>();
builder.Services.AddTransient<IMatchQueries, MatchQueries>();
builder.Services.AddTransient<IPlayerQueries, PlayerQueries>();
builder.Services.AddTransient<IRefereeQueries, RefereeQueries>();

builder.Services.AddTransient<IManagerRepository, ManagerRepository>();
builder.Services.AddTransient<IMatchRepository, MatchRepository>();
builder.Services.AddTransient<IPlayerRepository, PlayerRepository>();
builder.Services.AddTransient<IRefereeRepository, RefereeRepository>();

builder.Services.AddDbContext<FootballContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
