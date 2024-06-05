using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Application.Common.Models.Emails;
using System.Threading;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.ResetPassword
{
    public class UserAuthResetPasswordHandler : IRequestHandler<UserAuthResetPasswordCommand, ResponseDto<bool>>
    {
        private readonly IIdentityService _identityService;
        private readonly IEmailService _emailService;

        public UserAuthResetPasswordHandler(IIdentityService identityService, IEmailService emailService)
        {
            _identityService = identityService;
            _emailService = emailService;
        }

        public async Task<ResponseDto<bool>> Handle(UserAuthResetPasswordCommand request, CancellationToken cancellationToken)
        {
            await _identityService.ResetPasswordAsync(request.Email, request.Token, request.Password, cancellationToken);
            await SendEmailResetPasswordConfirmationAsync(request.Email, cancellationToken);

            return new ResponseDto<bool>(true, "Password has been reset successfully.");
        }

        private Task SendEmailResetPasswordConfirmationAsync(string email, CancellationToken cancellationToken)
        {
            var emailDto = new EmailSendResetPasswordConfirmationDto(email);
            return _emailService.SendResetPasswordConfirmationAsync(emailDto, cancellationToken);
        }
    }
}
