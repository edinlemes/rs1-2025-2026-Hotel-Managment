using Hotel.Application.Modules.Auth.Commands.Login;
using Hotel.Domain.Entities.Users;

public sealed class LoginCommandHandler(
    IAppDbContext ctx,
    IJwtTokenService jwt,
    IPasswordHasher<UsersEntity> hasher)
    : IRequestHandler<LoginCommand, LoginCommandDto>
{
    public async Task<LoginCommandDto> Handle(LoginCommand request, CancellationToken ct)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        var user = await ctx.UserTable
            .FirstOrDefaultAsync(x => x.Email.ToLower() == email && x.Active && !x.IsDeleted, ct)
            ?? throw new HotelNotFoundException("Korisnik nije pronađen ili je onemogućen.");

        var verify = hasher.VerifyHashedPassword(user, user.Password, request.Password);

        if (verify == PasswordVerificationResult.Failed)
        {
            throw new HotelConflictException("Pogrešni kredencijali.");
        }

        var tokens = jwt.IssueTokens(user);

        ctx.RefreshTokens.Add(new RefreshTokenEntity
        {
            TokenHash = tokens.RefreshTokenHash,
            ExpiresAtUtc = tokens.RefreshTokenExpiresAtUtc,
            UserId = user.Id,
        });

        await ctx.SaveChangesAsync(ct);

        return new LoginCommandDto
        {
            AccessToken = tokens.AccessToken,
            RefreshToken = tokens.RefreshTokenRaw,
            ExpiresAtUtc = tokens.RefreshTokenExpiresAtUtc
        };
    }
}