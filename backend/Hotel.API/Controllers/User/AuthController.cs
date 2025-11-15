using Hotel.Application.Modules.Auth.Commands.Create;
using Hotel.Application.Modules.Auth.Commands.Login;
using Hotel.Application.Modules.Auth.Commands.Logout;
using Hotel.Application.Modules.Auth.Commands.Refresh;
using Hotel.Application.Modules.Auth.Queries.GetById;

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
    public async Task<ActionResult<UserGetByIdQueryDto>> GetById([FromQuery] int id, CancellationToken ct)
    {
        var query = new UserGetByIdQuery { Id = id };
        return Ok(await sender.Send(query, ct));
    }
}
