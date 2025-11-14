using Hotel.Application.Modules.Auth.Commands.Login;
using Hotel.Application.Modules.Auth.Commands.Logout;
using Hotel.Application.Modules.Auth.Commands.Refresh;
using Hotel.Application.Modules.Auth.Roles.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers.User
{
    [ApiController]
    [Route("api/roles")]
    public sealed class RolesController(IMediator mediator) : ControllerBase
    {
        [HttpPost("addRole")]
        [AllowAnonymous]

        public async Task<ActionResult<int>> Role([FromBody] CreateRolesCommand command, CancellationToken ct)
        {
            return Ok(await mediator.Send(command, ct));
        }

    }
}
