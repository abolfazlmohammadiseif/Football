using AutoMapper;
using AutoMapper.Internal.Mappers;
using Football.API.Application.Queries.ViewModels;
using Football.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.API.Application.Queries
{
    public class MatchQueries : IMatchQueries
    {
        private readonly IMatchRepository _repository;
        private readonly IMapper _mapper;

        public MatchQueries(IMatchRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<MatchViewModel>> GetAllAsync()
        {
            var matches = await _repository.GetAllAsync();

            return _mapper.Map<List<MatchViewModel>>(matches);
        }

        public async Task<MatchViewModel> GetAsync(int id)
        {
            var matches = await _repository.GetAsync(id);

            return _mapper.Map<MatchViewModel>(matches);
        }

    }
}
