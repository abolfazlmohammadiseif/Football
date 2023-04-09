using Football.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Football.API.Application.Commands
{
    public class DeleteManagerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteManagerCommandHandler : IRequestHandler<DeleteManagerCommand, bool>
    {
        private readonly IManagerRepository _repository;

        public DeleteManagerCommandHandler(IManagerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteManagerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var manager = await _repository.GetAsync(command.Id);
                if (manager == null) return false; //Can also throw an exception

                _repository.Delete(manager);
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