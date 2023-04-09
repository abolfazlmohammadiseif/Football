using System.Threading;
using System.Threading.Tasks;
using Football.Domain.Models;
using MediatR;

namespace Football.API.Application.Commands
{ 
    public class DeleteRefereeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteRefereeCommandHandler : IRequestHandler<DeleteRefereeCommand, bool>
    {
        private readonly IRefereeRepository _repository;
        public DeleteRefereeCommandHandler(IRefereeRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteRefereeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var referee = await _repository.GetAsync(command.Id);
                if (referee == null) return false; //Can also throw an exception

                _repository.Delete(referee);
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
