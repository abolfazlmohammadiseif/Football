using Football.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Football.API.Application.Commands
{
    public class CreateManagerCommand : IRequest<int>
    {
        public string Name { get;  set; }
        public int YellowCard { get;  set; }
        public int RedCard { get;  set; }
    }

    public class CreateManagerCommandHandler : IRequestHandler<CreateManagerCommand, int>
    {
        private readonly IManagerRepository _repository;

        public CreateManagerCommandHandler(IManagerRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateManagerCommand command, CancellationToken cancellationToken)
        {
            var manager = new Manager();
            manager.Update(command.Name,command.YellowCard, command.RedCard);
            var response = _repository.Add(manager);
            await _repository.SaveEntitiesAsync(cancellationToken);
            return response.Id;
        }

    }

}