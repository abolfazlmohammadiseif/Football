using AutoMapper;
using Football.API.Application.Queries.ViewModels;
using System.Text.RegularExpressions;

namespace Football.API.Profiles
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            CreateMap<Domain.Models.Match, MatchViewModel>();

        }
    }
}
