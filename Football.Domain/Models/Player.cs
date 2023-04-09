using Football.Domain.Seedwork;
using System;
using System.Collections.Generic;

namespace Football.Domain.Models
{
    public class Player : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }
        public int MinutesPlayed { get; set; }
        
        //public ICollection<MatchPlayer> HomeMatches { get; set; }
        //public ICollection<MatchPlayer> AwayMatches { get; set; }
        public ICollection<Match> HomeMatches { get; set; }
        public ICollection<Match> AwayMatches { get; set; }
        
        public void Update(string name, int yellowCard, int redCard, int minutesPlayed)
        {
            Name = name;
            YellowCard = yellowCard;
            RedCard = redCard;
            MinutesPlayed = minutesPlayed;
        }
    }
}
