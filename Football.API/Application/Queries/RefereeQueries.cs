using AutoMapper;
using Football.API.Application.Queries.ViewModels;
using Football.Domain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.API.Application.Queries
{
    public class RefereeQueries : IRefereeQueries
    {
        private readonly IRefereeRepository _repository;
        private readonly IMapper _mapper;

        public RefereeQueries(IRefereeRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<RefereeViewModel>> GetAllAsync()
        {
            var matches = await _repository.GetAllAsync();

            return _mapper.Map<List<RefereeViewModel>>(matches);
        }

        public async Task<RefereeViewModel> GetAsync(int id)
        {
            var matches = await _repository.GetAsync(id);

            return _mapper.Map<RefereeViewModel>(matches);
        }
    }
}
