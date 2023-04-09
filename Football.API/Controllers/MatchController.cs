using Football.API.Application.Commands;
using Football.API.Application.Queries;
using Football.API.Application.Queries.ViewModels;
using Football.Domain.Models;
using Football.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchQueries _queries;
        private readonly IMediator _mediator;

        public MatchController(IMediator mediator, IMatchQueries queries)
        {
            _queries = queries;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<List<MatchViewModel>>> Get()
        {
            return this.Ok(await _queries.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<MatchViewModel>> GetById(int id)
        {
            var response = await _queries.GetAsync(id);
            if (response == default)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateMatchCommand command)
        {
            var response = await _mediator.Send(command);
            if(response == 0)
                return NotFound();
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMatchCommand command)
        {
            var response = await _mediator.Send(command);
            if (response == false)
                return NotFound();

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteMatchCommand command)
        {
            var response = await _mediator.Send(command);
            if (response == false)
                return NotFound();

            return Ok(response);
        }
    }
}
