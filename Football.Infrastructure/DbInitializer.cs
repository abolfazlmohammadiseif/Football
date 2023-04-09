using Football.Domain.Models;
using System.Linq;

namespace Football.Infrastructure
{
    public static class DbInitializer
    {
        public static void Initialize(FootballContext context)
        {
            context.Database.EnsureCreated();

            if (context.Player.Any())
                return;

            var players = new Player[] 
            {
                new Player{ Name = "Lionel" },
                new Player{ Name = "Cristiano" },
                new Player{ Name = "Iker" },
                new Player{ Name = "Gerard" },
                new Player{ Name = "Philippe" },
                new Player{ Name = "Jordi" }
            };

            foreach (var p in players)
                context.Player.Add(p);
            context.SaveChanges();

            var managers = new Manager[] 
            {
                new Manager { Name = "Alex" },
                new Manager { Name = "Zidane" },
                new Manager { Name = "Guardiola" }
            };

            foreach (var m in managers)
                context.Manager.Add(m);
            context.SaveChanges();

            var referees = new Referee[] 
            {
                new Referee { Name = "Pierluigi" },
                new Referee { Name = "Howard" }
            };

            foreach (var r in referees)
                context.Referee.Add(r);
            context.SaveChanges();
        }
    }
}
