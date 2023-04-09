using System.Threading;
using System.Threading.Tasks;
using Football.Domain.Models;
using MediatR;

namespace Football.API.Application.Commands
{
    public class CreatePlayerCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }
        public int MinutesPlayed { get; set; }
    }

    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly IPlayerRepository _repository;

        public CreatePlayerCommandHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreatePlayerCommand command, CancellationToken cancellationToken)
        {
            var player = new Player();
            player.Update(command.Name, command.YellowCard, command.RedCard, command.MinutesPlayed);
            var response = _repository.Add(player);
            await _repository.SaveEntitiesAsync(cancellationToken);
            return response.Id;
        }

    }
}
