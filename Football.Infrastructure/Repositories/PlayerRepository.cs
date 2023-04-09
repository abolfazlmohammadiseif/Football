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
    public class PlayerRepository : IPlayerRepository
    {
        public FootballContext Context { get; private set; }

        public PlayerRepository(FootballContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Player>> GetAllAsync()
        {
            return await Context.Player.ToListAsync();
        }
        public async Task<Player> GetAsync(int playerId)
        {
            var player = await Context.Player.FirstOrDefaultAsync(o => o.Id == playerId);
            if (player == null)
            {
                player = Context
                            .Player
                            .Local
                            .FirstOrDefault(o => o.Id == playerId);
            }
            //if (order != null)
            //{
            //    await _context.Entry(order)
            //        .Collection(i => i.OrderItems).LoadAsync();
            //    await _context.Entry(order)
            //        .Reference(i => i.OrderStatus).LoadAsync();
            //}

            return player;
        } 

        public Player Add(Player player)
        {
            return Context.Player.Add(player).Entity;
        }
        public void Update(Player player)
        {
            Context.Entry(player).State = EntityState.Modified;
        }
        public void Delete(Player player)
        {
            Context.Entry(player).State = EntityState.Deleted;
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<int> GetMinutesPlayed(int? playerId)
        {
            if (playerId != null)
                return await Context.Player.Where(r => r.Id == playerId).SumAsync(r => r.MinutesPlayed);
            return await Context.Player.SumAsync(r => r.MinutesPlayed);
        }

        public async Task<int> GetYellowCards(int? playerId)
        {
            if (playerId != null)
                return await Context.Player.Where(r => r.Id == playerId).SumAsync(r => r.YellowCard);
            return await Context.Player.SumAsync(r => r.YellowCard);
        }

        public async Task<int> GetRedCards(int? playerId)
        {
            if (playerId != null)
                return await Context.Player.Where(r => r.Id == playerId).SumAsync(r => r.RedCard);
            return await Context.Player.SumAsync(r => r.RedCard);
        }
    }
}
