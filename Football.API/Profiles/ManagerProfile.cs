

using AutoMapper;
using Football.API.Application.Commands;
using Football.API.Application.Queries.ViewModels;
using Football.Domain.Models;

namespace Football.API.Profiles
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<Manager, ManagerViewModel>();
        }
    }
}
