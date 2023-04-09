using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Football.Domain.Models;
using MediatR;

namespace Football.API.Application.Commands
{

    public class DeleteMatchCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteMatchCommandHandler : IRequestHandler<DeleteMatchCommand, bool>
    {
        private readonly IMatchRepository _repository;

        public DeleteMatchCommandHandler(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteMatchCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var match = await _repository.GetAsync(command.Id);
                if (match == null) return false; //Can also throw an exception

                _repository.Delete(match);
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
