using Football.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Football.API.Application.Commands
{
    public class UpdateManagerCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YellowCard { get; set; }
        public int RedCard { get; set; }
    }

    public class UpdateManagerCommandHandler : IRequestHandler<UpdateManagerCommand, bool>
    {
        private readonly IManagerRepository _repository;

        public UpdateManagerCommandHandler(IManagerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateManagerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var manager = await _repository.GetAsync(command.Id);
                if (manager == null) return false; //Can also throw an exception

                manager.Update(command.Name, command.YellowCard, command.RedCard);
                _repository.Update(manager);//this is unnecessary as it automatically updates the status.
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