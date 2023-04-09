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
    public class RefereeRepository : IRefereeRepository
    {
        public FootballContext Context { get; private set; }
        public RefereeRepository(FootballContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Referee>> GetAllAsync()
        {
            return await Context.Referee.ToListAsync();
        }
        public async Task<Referee> GetAsync(int refereeId)
        {
            var referee = await Context.Referee.FirstOrDefaultAsync(o => o.Id == refereeId);
            if (referee == null)
            {
                referee = Context
                            .Referee
                            .Local
                            .FirstOrDefault(o => o.Id == refereeId);
            }
            //if (order != null)
            //{
            //    await _context.Entry(order)
            //        .Collection(i => i.OrderItems).LoadAsync();
            //    await _context.Entry(order)
            //        .Reference(i => i.OrderStatus).LoadAsync();
            //}

            return referee;
        }

        public Referee Add(Referee referee)
        {
            return Context.Referee.Add(referee).Entity;
        }
        public void Delete(Referee referee)
        {
            Context.Entry(referee).State = EntityState.Deleted;
        }
        public void Update(Referee referee)
        {
            Context.Entry(referee).State = EntityState.Modified;
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<int> GetMinutesPlayed(int? refereeId)
        {
            if (refereeId != null)
                return await Context.Referee.Where(r => r.Id == refereeId).SumAsync(r => r.MinutesPlayed);
            return await Context.Referee.SumAsync(r => r.MinutesPlayed);
        }
    }
}
