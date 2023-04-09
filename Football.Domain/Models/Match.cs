using Football.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Football.Domain.Models
{
    public class Match : Entity, IAggregateRoot
    {
        public Manager HomeManager { get; set; }
        public int HomeManagerId { get; set; }
        public Manager AwayManager { get; set; }
        public int AwayManagerId { get; set; }

        public ICollection<Player> HomePlayers { get; set; }
        public ICollection<Player> AwayPlayers { get; set; }

        public Referee Referee { get; set; }
        public int RefereeId { get; set; }

        public DateTime KickoffTime { get; set; }  

        public Match() { }
        public void Update(int homeManagerId, int awayManagerId,
            ICollection<Player> homePlayers, ICollection<Player> awayPlayers,
            int refereeId, DateTime kickoffTime)
        {
            HomeManagerId = homeManagerId;
            AwayManagerId = awayManagerId;
            HomePlayers = homePlayers;
            AwayPlayers = awayPlayers;
            RefereeId = refereeId;
            KickoffTime = kickoffTime;
        }


    }
}
