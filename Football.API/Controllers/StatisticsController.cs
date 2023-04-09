using Football.Domain.Models;
using Football.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Football.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IRefereeRepository _refereeRepository;
        private readonly IManagerRepository _managerRepository;

        public StatisticsController(IPlayerRepository playerRepository,
            IRefereeRepository refereeRepository, IManagerRepository managerRepository)
        {
            _playerRepository = playerRepository;
            _refereeRepository = refereeRepository;
            _managerRepository = managerRepository;
        }

        [HttpGet]
        [Route("yellowcards")]
        public async Task<ActionResult> GetYellowCards(int? playerId, int? managerId)
        {
            var playerYellowCards = await _playerRepository.GetYellowCards(playerId);
            var managerYellowCards = await _managerRepository.GetYellowCards(managerId);

            return Ok(new
            {
                Player_YellowCards = playerYellowCards,
                Manager_YellowCards = managerYellowCards,
                Sum_of_Above_YellowCards = managerYellowCards + playerYellowCards
            });
        }

        [HttpGet]
        [Route("redcards")]
        public async Task<ActionResult> GetRedCards(int? playerId, int? managerId)
        {
            var playerRedCards = await _playerRepository.GetRedCards(playerId);
            var managerRedCards = await _managerRepository.GetRedCards(managerId);

            return Ok(new
            {
                Player_RedCards = playerRedCards,
                manager_RedCards = managerRedCards,
                Sum_of_Above_RedCards = managerRedCards + playerRedCards
            });
        }

        /// <summary>
        /// values are optional.
        /// </summary>
        /// <param name="playerId">optional</param>
        /// <param name="refereeId">optional</param>
        /// <returns></returns>
        [HttpGet]
        [Route("minutesplayed")]
        public async Task<ActionResult> GetMinutesPlayed(int? playerId, int? refereeId)
        {
            var playerMinutesPlayed = await _playerRepository.GetMinutesPlayed(playerId);
            var refereeMinutesPlayed = await _refereeRepository.GetMinutesPlayed(refereeId);

            return Ok(new
            {
                Player_MinutesPlayed = playerMinutesPlayed,
                Referee_MinutesPlayed = refereeMinutesPlayed,
                Sum_of_Above_MinutesPlayed = refereeMinutesPlayed + playerMinutesPlayed
            });


        }
    }
}
