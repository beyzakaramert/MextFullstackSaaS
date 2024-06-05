using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Common.Models.Emails;
using System.Threading;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.ForgotPassword
{
    public class UserAuthForgotPasswordCommandHandler : IRequestHandler<UserAuthForgotPasswordCommand, ResponseDto<bool>>
    {
        private readonly IIdentityService _identityService;
        private readonly IEmailService _emailService;

        public UserAuthForgotPasswordCommandHandler(IIdentityService identityService, IEmailService emailService)
        {
            _identityService = identityService;
            _emailService = emailService;
        }

        public async Task<ResponseDto<bool>> Handle(UserAuthForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var token = await _identityService.ForgotPasswordAsync(request.Email, cancellationToken);
            await SendEmailForgotPasswordAsync(request.Email, token, cancellationToken);

            return new ResponseDto<bool>(true, "Password reset link has been sent to your email.");
        }

        private Task SendEmailForgotPasswordAsync(string email, string token, CancellationToken cancellationToken)
        {
            var emailDto = new EmailSendForgotPasswordDto(email, token);
            return _emailService.SendForgotPasswordEmailAsync(emailDto, cancellationToken);
        }
    }
}
