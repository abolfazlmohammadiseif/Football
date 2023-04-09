using Football.API.Application.Queries;
using Football.Domain.Models;
using Football.Infrastructure;
using Football.Infrastructure.Repositories;
using Football.Worker.Hubs;
using Football.Worker.Schedulers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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


MainTaskScheduler.StartAsync().GetAwaiter().GetResult();
//builder.Services.AddSignalR();
//builder.Services.AddHostedService<MyHostedServiceB>();


builder.Services.AddDbContext<FootballContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.RegisterAssemblyTypes(typeof(CreateOrderCommand).GetTypeInfo().Assembly)
//                .AsClosedTypesOf(typeof(IRequestHandler<,>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//app.MapHub<NotificationHub>("/chatHub");

app.Run();
