using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Football.Domain.Models;
using MediatR;

namespace Football.API.Application.Commands
{

    public class UpdateMatchCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int HomeManagerId { get; set; }
        public int AwayManagerId { get; set; }
        public ICollection<int> HomePlayers { get; set; }
        public ICollection<int> AwayPlayers { get; set; }
        public int RefereeId { get; set; }
        public DateTime KickoffTime { get; set; }
    }

    public class UpdateMatchCommandHandler : IRequestHandler<UpdateMatchCommand, bool>
    {
        private readonly IMatchRepository _repository;
        private readonly IManagerRepository _managerRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IRefereeRepository _refereeRepository;

        public UpdateMatchCommandHandler(IMatchRepository repository, IManagerRepository managerRepository, IPlayerRepository playerRepository, IRefereeRepository refereeRepository)
        {
            _repository = repository;
            _managerRepository = managerRepository;
            _playerRepository = playerRepository;
            _refereeRepository = refereeRepository;
        }

        public async Task<bool> Handle(UpdateMatchCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var match = await _repository.GetAsync(command.Id);
                if (match == null) return false; //Can also throw an exception

                var homeManager = await _managerRepository.GetAsync(command.HomeManagerId);
                if (homeManager == null) return false; // I can do many things like throwing an Exception.
                var awayManager = await _managerRepository.GetAsync(command.AwayManagerId);
                if (awayManager == null) return false;

                var referee = await _refereeRepository.GetAsync(command.RefereeId);
                if (referee == null) return false;

                var homePlayers = new List<Player>();
                foreach (var playerId in command.HomePlayers)
                {
                    var Player = await _playerRepository.GetAsync(playerId);

                    if (Player == null) return false;
                    homePlayers.Add(Player);
                }

                var awayPlayers = new List<Player>();
                foreach (var playerId in command.AwayPlayers)
                {
                    var Player = await _playerRepository.GetAsync(playerId);

                    if (Player == null) return false;
                    awayPlayers.Add(Player);
                }

                match.Update(command.HomeManagerId, command.AwayManagerId, homePlayers, 
                    awayPlayers, command.RefereeId, command.KickoffTime);
                _repository.Update(match);
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
