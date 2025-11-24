using Hotel.Application.Modules.Auth.Commands.Create;
using Hotel.Application.Modules.Auth.Commands.Delete;
using Hotel.Application.Modules.Auth.Commands.Login;
using Hotel.Application.Modules.Auth.Commands.Logout;
using Hotel.Application.Modules.Auth.Commands.Refresh;
using Hotel.Application.Modules.Auth.Queries.GetById;
using Hotel.Application.Modules.Auth.Queries.GetList;

namespace Hotel.API.Controllers.User;

[ApiController]
[Route("api/auth")]
public sealed class AuthController(ISender sender) : ControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginCommandDto>> Login([FromBody] LoginCommand command, CancellationToken ct)
    {
        return Ok(await sender.Send(command, ct));
    }

    [HttpPost("refresh")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginCommandDto>> Refresh([FromBody] RefreshTokenCommand command, CancellationToken ct)
    {
        return Ok(await sender.Send(command, ct));
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task Logout([FromBody] LogoutCommand command, CancellationToken ct)
    {
        await sender.Send(command, ct);
    }
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult<RegisterUserCommandDto>> Register([FromBody] RegisterUserCommand command, CancellationToken ct)
    {
        return Ok(await sender.Send(command, ct));
    }
    [HttpGet("GetById")]
    [AllowAnonymous]
    public async Task<ActionResult<UserGetByIdQueryDto>> GetById([FromQuery] int id, CancellationToken ct)
    {
        var query = new UserGetByIdQuery { Id = id };
        return Ok(await sender.Send(query, ct));
    }
    [HttpGet("name")]
    [AllowAnonymous]
    public async Task<PageResult<UserGetListQueryDto>> List([FromQuery] UserGetListQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }
    [HttpDelete("DeleteById")]
    [AllowAnonymous]
    public async Task<ActionResult<int>> DeleteById([FromQuery] int id, CancellationToken ct)
    {
        var query = new DeleteUserCommand { Id = id };
        return Ok(await sender.Send(query, ct));
    }
}
