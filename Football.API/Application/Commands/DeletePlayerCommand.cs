using System.Threading;
using System.Threading.Tasks;
using Football.Domain.Models;
using MediatR;

namespace Football.API.Application.Commands
{
    public class DeletePlayerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand, bool>
    {
        private readonly IPlayerRepository _repository;

        public DeletePlayerCommandHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeletePlayerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var player = await _repository.GetAsync(command.Id);
                if (player == null) return false; //Can also throw an exception

                _repository.Delete(player);
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
