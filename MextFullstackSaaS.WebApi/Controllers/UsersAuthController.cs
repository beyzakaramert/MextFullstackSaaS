using MediatR;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.ForgotPassword;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Login;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Register;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.ResetPassword;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.VerifyEmail;
using Microsoft.AspNetCore.Mvc;

namespace MextFullstackSaaS.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UsersAuthController : ControllerBase
{
    private readonly ISender _mediatr;

    public UsersAuthController(ISender mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
    {
        //throw new ArgumentNullException(command.FirstName, "First name is required");
        return Ok(await _mediatr.Send(command, cancellationToken));
    }
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken)
    {
        //throw new ArgumentNullException(command.FirstName, "First name is required");
        return Ok(await _mediatr.Send(command, cancellationToken));
    }
    [HttpGet("verify-email")]
    public async Task<IActionResult> VerifyEmailAsync([FromQuery]UserAuthVerifyEmailCommand command, CancellationToken cancellationToken)
    {
        //throw new ArgumentNullException(command.FirstName, "First name is required");
        return Ok(await _mediatr.Send(command, cancellationToken));
    }

    [HttpGet("forgot-password")]
    public async Task<IActionResult> ForgotPasswordAsync(UserAuthForgotPasswordCommand command, CancellationToken cancellationToken)
    {
        return Ok(await _mediatr.Send(command, cancellationToken));
    }

    [HttpGet("reset-password")]
    public async Task<IActionResult> ResetPasswordAsync(UserAuthResetPasswordCommand command, CancellationToken cancellationToken)
    {
        return Ok(await _mediatr.Send(command, cancellationToken));
    }
}
