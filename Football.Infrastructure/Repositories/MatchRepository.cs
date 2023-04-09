using Arch.EntityFrameworkCore.UnitOfWork;
using Football.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Football.Infrastructure.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        public FootballContext Context { get; private set; }

        public MatchRepository(FootballContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Match>> GetAllAsync()
        {
            return await Context.Match
                .Include(m => m.HomeManager)
                .Include(m => m.AwayManager)
                .Include(m => m.Referee)
                .Include(m => m.HomePlayers)
                .Include(m => m.AwayPlayers)
                .ToListAsync();
        }
        public async Task<Match> GetAsync(int matchId)
        {
            var match = await Context.Match.FirstOrDefaultAsync(o => o.Id == matchId);
            if (match == null)
            {
                match = Context
                            .Match
                            .Local
                            .FirstOrDefault(o => o.Id == matchId);
            }
            //if (order != null)
            //{
            //    await _context.Entry(order)
            //        .Collection(i => i.OrderItems).LoadAsync();
            //    await _context.Entry(order)
            //        .Reference(i => i.OrderStatus).LoadAsync();
            //}

            return match;
        }

        public Match Add(Match match)
        {
            return Context.Match.Add(match).Entity;
        }
        public void Update(Match match)
        {
            Context.Entry(match).State = EntityState.Modified;
        }
        public void Delete(Match match)
        {
            Context.Entry(match).State = EntityState.Deleted;
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<Match>> GetUpcomingMatchesAsync(int minute)
        {
            return await Context.Match
                .Where(m => m.KickoffTime <= DateTime.Now.AddMinutes(minute) && m.KickoffTime >= DateTime.Now.AddMinutes(minute - 1))
                .Include(m => m.HomePlayers)
                .Include(m => m.AwayPlayers)
                .ToListAsync();
        }
    }
}
