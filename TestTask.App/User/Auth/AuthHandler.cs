
using System.Security.Claims;
using DotNetCore.Extensions;
using DotNetCore.Mediator;
using DotNetCore.Results;
using DotNetCore.Security;
using Microsoft.EntityFrameworkCore;
using TestTask.Database;


namespace TestTask.App.User;

public sealed record AuthHandler : IHandler<AuthRequest, AuthResponse> {
    private readonly AppDbContext _context;
    private readonly IHashService _hashService;
    private readonly IJwtService _jwtService;
    private readonly IResultService _resultService;

    public AuthHandler
    (
        AppDbContext context,
        IHashService hashService,
        IJwtService jwtService,
        IResultService resultService
    ) {
        _context = context;
        _hashService = hashService;
        _jwtService = jwtService;
        _resultService = resultService;
    }

    public async Task<Result<AuthResponse>> HandleAsync(AuthRequest request) {
        var error = _resultService.Error<AuthResponse>("AuthError");

        var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == request.Email);

        if (user is null) return error;

        // temp salt
        var passwordHash = _hashService.Create(request.Password, new Guid("79005744-e69a-4b09-996b-08fe0b70cbb9").ToString());

        if (user.PasswordHash != passwordHash) return error;

        var claims = new List<Claim>();

        claims.AddSub(user.Id.ToString());

        claims.AddRoles(user.Roles.ToArray());

        var token = _jwtService.Encode(claims);

        var response = new AuthResponse(token);

        return _resultService.Success(response);
    }
}
