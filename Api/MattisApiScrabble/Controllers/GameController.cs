
using Mattis.Api.Scrabble.Business.Game.Command;
using Mattis.Api.Scrabble.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MattisApiScrabble.Controllers
{
    [ApiController]
    [Route("api/Game")]
    public class GameController : ControllerBase
    {
        readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Add-Player")]
        public async Task<ActionResult<int>> CreateAsync([FromBody] CreateGameCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
