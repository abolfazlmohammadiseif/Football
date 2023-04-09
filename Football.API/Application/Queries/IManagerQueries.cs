using Football.API.Application.Queries.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.API.Application.Queries
{
    public interface IManagerQueries
    {
        Task<ManagerViewModel> GetAsync(int id);
        Task<List<ManagerViewModel>> GetAllAsync();
    }
}
