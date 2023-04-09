using System.Threading;
using System.Threading.Tasks;
using Football.Domain.Models;
using MediatR;

namespace Football.API.Application.Commands
{ 
    public class CreateRefereeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int MinutesPlayed { get; set; }
    }

    public class CreateRefereeCommandHandler : IRequestHandler<CreateRefereeCommand, int>
    {
        private readonly IRefereeRepository _repository;
        public CreateRefereeCommandHandler(IRefereeRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CreateRefereeCommand command, CancellationToken cancellationToken)
        {
            var referee = new Referee();
            referee.Update(command.Name, command.MinutesPlayed);
            var response = _repository.Add(referee);
            await _repository.SaveEntitiesAsync(cancellationToken);
            return response.Id;
        }

    }
}
