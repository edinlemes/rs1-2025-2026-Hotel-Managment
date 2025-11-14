using Hotel.Application.Modules.Auth.Commands.Login;
using Hotel.Application.Modules.Auth.Commands.Logout;
using Hotel.Application.Modules.Auth.Commands.Refresh;
using Hotel.Application.Modules.Auth.Roles.Commands.Create;
using Hotel.Application.Modules.Auth.Roles.Querries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers.User
{
    [ApiController]
    [Route("api/roles")]
    public sealed class RolesController(ISender sender) : ControllerBase
    {
        [HttpPost("addRole")]
        [AllowAnonymous]

        public async Task<ActionResult<int>> Role([FromBody] CreateRolesCommand command, CancellationToken ct)
        {
            return Ok(await sender.Send(command, ct));
        }
        [HttpGet("listRoles")]
        [AllowAnonymous]
        public async Task<PageResult<ListRolesQueryDto>> List([FromQuery] ListRolesQuery query, CancellationToken ct)
        {
            var result = await sender.Send(query, ct);
            return result;
        }

    }
}
