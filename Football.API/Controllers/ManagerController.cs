using Football.API.Application.Commands;
using Football.API.Application.Queries;
using Football.API.Application.Queries.ViewModels;
using Football.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Football.API.Controllers
{
    //Todo: Some Notes-2
    /// <summary>
    /// 1. I added IMediator for commands, and IManagerQueries for queries.(CQRS pattern)
    /// 2. For both I have used EFCore, however you can use different ORMs, like Dapper for Queries.
    /// 3. Within them I have used Repository Pattern, which lets you use different databases too such as nosql ones(elasticsearch, mongoDB,...).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerQueries _queries;
        private readonly IMediator _mediator;
        public ManagerController(IMediator mediator, IManagerQueries queries)
        {
            _queries = queries;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<List<ManagerViewModel>>> Get()
        {
            return this.Ok(await _queries.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ManagerViewModel>> GetById(int id)
        {
            var response = await _queries.GetAsync(id);
            if (response == default)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateManagerCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateManagerCommand command)
        {
            var response = await _mediator.Send(command);
            if (response == false)
                return NotFound();

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteManagerCommand command)
        {
            var response = await _mediator.Send(command);
            if (response == false)
                return NotFound();

            return Ok(response);
        }




    }
}
