using System;
using System.Threading.Tasks;
using Football.Domain.Models;
using Football.Infrastructure;
using Football.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.Serilog;
using Quartz;
using Quartz.Impl;
using Serilog;

class Program
{
    private static IMatchRepository _siteService;
    private static FootballContext _appDbContext;

    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddTransient<IMatchRepository, MatchRepository>();
        services.AddDbContext<FootballContext>(options => options.UseSqlServer("Server=.;Database=FootballDb;Trusted_Connection=True;TrustServerCertificate=True"));

        var serviceProvider = services.BuildServiceProvider();
        _siteService = serviceProvider.GetService<IMatchRepository>();
        _appDbContext = serviceProvider.GetService<FootballContext>();

        var repo = new MatchRepository(_appDbContext);

        #region Configuration

        var schedulerFactory = new StdSchedulerFactory();

        var scheduler = await schedulerFactory.GetScheduler().ConfigureAwait(false);

        await scheduler.Start().ConfigureAwait(false);
        #endregion

        #region scheduleJob
        MatchKickoffNotificationJob.matchRepository = repo;
        var job = JobBuilder.Create<MatchKickoffNotificationJob>().WithIdentity("job1", "group1").Build();

        var trigger = TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
            .StartNow()
            .WithSimpleSchedule(
                action: builder =>
                {
                    builder
                        .WithIntervalInMinutes(1)
                        .RepeatForever();
                })
            .Build();

        await scheduler.ScheduleJob(job, trigger)
            .ConfigureAwait(false);

        #endregion

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();

    }
}