using Football.Domain.Seedwork;

namespace Football.Domain.Models
{
    public class Referee : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public int MinutesPlayed { get; set; }
   
        public void Update(string name, int minutesPlayed)
        {
            Name = name;
            MinutesPlayed = minutesPlayed;
        }
    }
}
