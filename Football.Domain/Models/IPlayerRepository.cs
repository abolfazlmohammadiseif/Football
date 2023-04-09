using Football.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Domain.Models
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<int> GetMinutesPlayed(int? playerId);
        Task<int> GetYellowCards(int? playerId);
        Task<int> GetRedCards(int? playerId);


    }
}
