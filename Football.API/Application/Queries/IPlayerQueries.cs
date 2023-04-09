using Football.API.Application.Queries.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.API.Application.Queries
{
    public interface IPlayerQueries
    {
        Task<PlayerViewModel> GetAsync(int id);
        Task<List<PlayerViewModel>> GetAllAsync();
    }
}
