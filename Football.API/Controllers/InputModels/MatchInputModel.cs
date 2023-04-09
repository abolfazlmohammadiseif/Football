using System.Collections.Generic;

namespace Football.API.Controllers.InputModels
{
    public class MatchInputModel
    {
        public int Id { get; set; }

        public ManagerInputModel HouseManager { get; set; }
        public ManagerInputModel AwayManager { get; set; }

        public ICollection<int> HousePlayers { get; set; }
        public ICollection<int> AwayPlayers { get; set; }

        public RefereeInputModel Referee { get; set; }
    }
}
