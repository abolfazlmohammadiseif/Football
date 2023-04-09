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
    public class RefereeController : ControllerBase
    {
        private readonly IRefereeQueries _queries;
        private readonly IMediator _mediator;

        public RefereeController(IMediator mediator, IRefereeQueries queries)
        {
            _queries = queries;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<List<RefereeViewModel>>> Get()
        {
            return this.Ok(await _queries.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PlayerViewModel>> GetById(int id)
        {
            var response = await _queries.GetAsync(id);
            if (response == default)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateRefereeCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRefereeCommand command)
        {
            var response = await _mediator.Send(command);
            if (response == false)
                return NotFound();

            return Ok(response);
        }
   
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteRefereeCommand command)
        {
            var response = await _mediator.Send(command);
            if (response == false)
                return NotFound();

            return Ok(response);
        }
    }
}
