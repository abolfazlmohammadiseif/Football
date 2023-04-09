using System.Threading;
using System.Threading.Tasks;
using Football.Domain.Models;
using MediatR;

namespace Football.API.Application.Commands
{
    public class UpdatePlayerCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }
        public int MinutesPlayed { get; set; }
    }

    public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, bool>
    {
        private readonly IPlayerRepository _repository;

        public UpdatePlayerCommandHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdatePlayerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var player = await _repository.GetAsync(command.Id);
                if (player == null) return false; //Can also throw an exception

                player.Update(command.Name, command.YellowCard, command.RedCard, command.MinutesPlayed);
                _repository.Update(player);//this is unnecessary as it automatically updates the status.
                await _repository.SaveEntitiesAsync(cancellationToken);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

    }
}
