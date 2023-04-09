using AutoMapper;
using Football.API.Application.Queries.ViewModels;
using Football.Domain.Models;

namespace Football.API.Application.Queries
{
    public class PlayerQueries : IPlayerQueries
    {
        private readonly IPlayerRepository _repository;
        private readonly IMapper _mapper;

        public PlayerQueries(IPlayerRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<PlayerViewModel>> GetAllAsync()
        {
            var matches = await _repository.GetAllAsync();

            return _mapper.Map<List<PlayerViewModel>>(matches);
        }

        public async Task<PlayerViewModel> GetAsync(int id)
        {
            var matches = await _repository.GetAsync(id);

            return _mapper.Map<PlayerViewModel>(matches);
        }
    }
}
