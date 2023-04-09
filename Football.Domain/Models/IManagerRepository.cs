using Football.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Domain.Models
{
    public interface IManagerRepository : IRepository<Manager>
    {
        Task<int> GetYellowCards(int? managerId);
        Task<int> GetRedCards(int? managerId);

    }
}
