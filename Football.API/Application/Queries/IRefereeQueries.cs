using Football.API.Application.Queries.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.API.Application.Queries
{
    public interface IRefereeQueries
    {
        Task<RefereeViewModel> GetAsync(int id);
        Task<List<RefereeViewModel>> GetAllAsync();
    }
}
