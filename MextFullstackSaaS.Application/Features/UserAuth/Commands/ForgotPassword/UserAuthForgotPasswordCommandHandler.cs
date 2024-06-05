using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.ForgotPassword
{
    public class UserAuthForgotPasswordCommandHandler : IRequestHandler<UserAuthForgotPasswordCommand, ResponseDto<bool>>
    {
        private readonly IIdentityService _identityService;

        public UserAuthForgotPasswordCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseDto<bool>> Handle(UserAuthForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            await _identityService.ForgotPasswordAsync(request.Email, cancellationToken);
            return new ResponseDto<bool>(true, "Password reset link has been sent to your email.");
        }
    }
}
