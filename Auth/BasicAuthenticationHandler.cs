using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TaskerAPI.Entities;
using TaskerAPI.Services.Interfaces;

namespace TaskerAPI.Auth;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IUserService _userService;

    public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IUserService userService)
        : base(options, logger, encoder, clock)
    {
        _userService = userService;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // skip authentication if endpoint has [AllowAnonymous] attribute
        var endpoint = Context.GetEndpoint();
        if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
        {
            return AuthenticateResult.NoResult();
        }

        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.Fail("Missing Authorization Header");
        }

        return await Authenticate();
    }

    private string[] GetCredentials(AuthenticationHeaderValue authHeader)
    {
        var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
        return Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
    }

    private AuthenticationTicket GetAuthenticationTicket(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
        };

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        return new AuthenticationTicket(principal, Scheme.Name);
    }

    private async Task<User> GetCredentialsAndTryToAuthenticate()
    {
        var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
        var credentials = GetCredentials(authHeader);
        var username = credentials[0];
        var password = credentials[1];
        return await _userService.Authenticate(username, password);
    }

    private async Task<AuthenticateResult> Authenticate()
    {
        User user;
        try
        {
            user = await GetCredentialsAndTryToAuthenticate();
        }
        catch
        {
            return AuthenticateResult.Fail("Invalid Authorization Header");
        }

        if (user == null)
        {
            return AuthenticateResult.Fail("Invalid Username or Password");
        }

        var ticket = GetAuthenticationTicket(user);

        return AuthenticateResult.Success(ticket);
    }
}