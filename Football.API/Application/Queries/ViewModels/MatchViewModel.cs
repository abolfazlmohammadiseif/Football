using System.Collections.Generic;

namespace Football.API.Application.Queries.ViewModels
{
    public class MatchViewModel
    {
        public int Id { get; set; }

        public ManagerViewModel HomeManager { get; set; }
        public ManagerViewModel AwayManager { get; set; }

        public ICollection<PlayerViewModel> HomePlayers { get; set; }
        public ICollection<PlayerViewModel> AwayPlayers { get; set; }

        public RefereeViewModel Referee { get; set; }
        public DateTime KickoffTime { get; set; }
    }
}
