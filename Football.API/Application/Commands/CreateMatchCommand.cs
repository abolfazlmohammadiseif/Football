using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Football.Domain.Models;
using MediatR;

namespace Football.API.Application.Commands
{

    public class CreateMatchCommand : IRequest<int>
    {
        public int HomeManagerId { get; set; }
        public int AwayManagerId { get; set; }
        public ICollection<int> HomePlayers { get; set; }
        public ICollection<int> AwayPlayers { get; set; }
        public int RefereeId { get; set; }
        public DateTime KickoffTime { get; set; }
    }

    public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, int>
    {
        private readonly IMatchRepository _repository;
        private readonly IManagerRepository _managerRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IRefereeRepository _refereeRepository;

        public CreateMatchCommandHandler(IMatchRepository repository, IManagerRepository managerRepository, IPlayerRepository playerRepository, IRefereeRepository refereeRepository)
        {
            _repository = repository;
            _managerRepository = managerRepository;
            _playerRepository = playerRepository;
            _refereeRepository = refereeRepository;
        }

        public async Task<int> Handle(CreateMatchCommand command, CancellationToken cancellationToken)
        {
            var homeManager = await _managerRepository.GetAsync(command.HomeManagerId);
            if (homeManager == null) return 0; // I can do many things like throwing an Exception.
            var awayManager = await _managerRepository.GetAsync(command.AwayManagerId);
            if (awayManager == null) return 0;

            var referee = await _refereeRepository.GetAsync(command.RefereeId);
            if (referee == null) return 0;

            var homePlayers = new List<Player>();
            foreach (var playerId in command.HomePlayers)
            {
                var Player = await _playerRepository.GetAsync(playerId);

                if (Player == null) return 0;
                homePlayers.Add(Player);
            }

            var awayPlayers = new List<Player>();
            foreach (var playerId in command.AwayPlayers)
            {
                var Player = await _playerRepository.GetAsync(playerId);

                if (Player == null) return 0;
                awayPlayers.Add(Player);
            }

            var match = new Match();
            match.Update(command.HomeManagerId, command.AwayManagerId, homePlayers, awayPlayers, 
                command.RefereeId, command.KickoffTime);
            var response = _repository.Add(match);
            await _repository.SaveEntitiesAsync(cancellationToken);
            return match.Id;
        }

    }
}
