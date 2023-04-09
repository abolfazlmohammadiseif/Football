using AutoMapper;
using Football.API.Application.Queries.ViewModels;
using Football.Domain.Models;
using System.Text.RegularExpressions;

namespace Football.API.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerViewModel>();

        }
    }
}
