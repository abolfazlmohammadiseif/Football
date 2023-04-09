using AutoMapper;
using Football.API.Application.Queries.ViewModels;
using Football.Domain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.API.Application.Queries
{
    //Todo: Some Notes-1
    /// <summary>
    /// I have splitted Commands from Queries to implement CQRS pattern. 
    /// I have used the same ORM (EF core), however, other tools can also be used here, such as Dapper, ADO.Net, etc.
    /// </summary>
    public class ManagerQueries : IManagerQueries
    {
        private readonly IManagerRepository _repository;
        private readonly IMapper _mapper;

        public ManagerQueries(IManagerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ManagerViewModel>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<List<ManagerViewModel>>(result);
        }

        public async Task<ManagerViewModel> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);
            return _mapper.Map<ManagerViewModel>(result);
        }
    
    }
}
