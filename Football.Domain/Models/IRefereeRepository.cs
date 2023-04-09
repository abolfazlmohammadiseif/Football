using Football.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Domain.Models
{
    public interface IRefereeRepository : IRepository<Referee>
    {
        Task<int> GetMinutesPlayed(int? refereeId);
    }
}
