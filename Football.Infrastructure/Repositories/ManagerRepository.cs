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
    public class ManagerRepository : IManagerRepository
    {
        public FootballContext Context { get; private set; }

        public ManagerRepository(FootballContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Manager>> GetAllAsync()
        {
            try
            {
                var tt = await Context.Manager.ToListAsync();

                return tt;

            }
            catch (Exception eeee)
            {

                throw;
            }
        }
        public async Task<Manager> GetAsync(int managerId)
        {
            var manager = await Context.Manager.FirstOrDefaultAsync(o => o.Id == managerId);
            if (manager == null)
            {
                manager = Context
                            .Manager
                            .Local
                            .FirstOrDefault(o => o.Id == managerId);
            }

            return manager;
        }

        public Manager Add(Manager manager)
        {
            return Context.Manager.Add(manager).Entity;
        }
        public void Update(Manager manager)
        {
            Context.Entry(manager).State = EntityState.Modified;
        }
        public void Delete(Manager manager)
        {
            Context.Entry(manager).State = EntityState.Deleted;
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<int> GetYellowCards(int? managerId)
        {
            if (managerId != null)
                return await Context.Manager.Where(r => r.Id == managerId).SumAsync(r => r.RedCard);
            return await Context.Manager.SumAsync(r => r.RedCard);
        }

        public async Task<int> GetRedCards(int? managerId)
        {
            if (managerId != null)
                return await Context.Manager.Where(r => r.Id == managerId).SumAsync(r => r.RedCard);
            return await Context.Manager.SumAsync(r => r.RedCard);
        }
    }
}
