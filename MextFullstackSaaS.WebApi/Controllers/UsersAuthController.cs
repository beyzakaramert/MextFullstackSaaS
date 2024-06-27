using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Login;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Register;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.VerifyEmail;
using MextFullstackSaaS.Domain.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MextFullstackSaaS.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersAuthController: ControllerBase
{    
    private readonly ISender _mediatr;
    private readonly GoogleSettings _googleSettings;
    private const string RedirectUri = "http://localhost:5121/api/UsersAuth/signin-google";
    private readonly string _googleAuthorizationUrl;

    public UsersAuthController(ISender mediatr, IOptions<GoogleSettings> googleSettings)
    {

        _mediatr = mediatr;

        _googleSettings = googleSettings.Value;
        
        _googleAuthorizationUrl = $"https://accounts.google.com/o/oauth2/v2/auth?" +
                                     $"client_id={_googleSettings.ClientId}&" +
                                     $"response_type=code&" +
                                     $"scope=openid%20email%20profile&" +
                                     $"access_type=offline&" +
                                     $"redirect_uri={RedirectUri}";
    }

    [HttpGet("signin-google-start")]
    public IActionResult GoogleSignInStart()    
        => Redirect(_googleAuthorizationUrl);  

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
    {
        return Ok(await _mediatr.Send(command, cancellationToken));
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken)
    {
        return Ok(await _mediatr.Send(command, cancellationToken));
    }

    [HttpGet("verify-email")]
    public async Task<IActionResult> VerifyEmailAsync([FromQuery] UserAuthVerifyEmailCommand command, CancellationToken cancellationToken)
    {
        return Ok(await _mediatr.Send(command, cancellationToken));
    }
}