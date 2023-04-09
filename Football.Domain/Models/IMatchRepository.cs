using Football.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Domain.Models
{
    public interface IMatchRepository : IRepository<Match>
    {
        //Task<Match> GetAsync(int matchId);
        //Match Add(Match match);
        //void Update(Match match);
        //void Delete(Match match);
    }
}
