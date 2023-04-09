using Football.Domain.Seedwork;

namespace Football.Domain.Models
{
    public class Manager : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }

        public void Update(string name, int yellowCard, int redCard)
        {
            Name = name;
            YellowCard = yellowCard;
            RedCard = redCard;
        }
    }
}
