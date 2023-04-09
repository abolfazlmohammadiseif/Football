using Football.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Domain.Models
{
    public interface IMatchRepository : IRepository<Match>
    {
        Task<List<Match>> GetUpcomingMatchesAsync(int minute);
    }
}
