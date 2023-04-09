using System.Threading;
using System.Threading.Tasks;
using Football.Domain.Models;
using MediatR;

namespace Football.API.Application.Commands
{ 
    public class UpdateRefereeCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinutesPlayed { get; set; }
    }

    public class UpdateRefereeCommandHandler : IRequestHandler<UpdateRefereeCommand, bool>
    {
        private readonly IRefereeRepository _repository;
        public UpdateRefereeCommandHandler(IRefereeRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(UpdateRefereeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var referee = await _repository.GetAsync(command.Id);
                if (referee == null) return false; //Can also throw an exception

                referee.Update(command.Name, command.MinutesPlayed);
                _repository.Update(referee);//this is unnecessary as it automatically updates the status.
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
