using Mattis.Api.Scrabble.Business.MultipleHistory.Command;
using Mattis.Api.Scrabble.Business.Player.Command;
using Mattis.Api.Scrabble.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MattisApiScrabble.Controllers
{
    [ApiController]
    [Route("api/MultipleHistory")]
    public class MultipleController : ControllerBase
    {
        readonly IMediator _mediator;

        public MultipleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Add-MultipleHistory")]
        public async Task<ActionResult<int>> CreateAsync([FromBody] CreateMultipleHistoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}