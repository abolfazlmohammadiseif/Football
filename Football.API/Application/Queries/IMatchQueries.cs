using Football.API.Application.Queries.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.API.Application.Queries
{
    public interface IMatchQueries
    {
        Task<MatchViewModel> GetAsync(int id);
        Task<List<MatchViewModel>> GetAllAsync();
    }
}
