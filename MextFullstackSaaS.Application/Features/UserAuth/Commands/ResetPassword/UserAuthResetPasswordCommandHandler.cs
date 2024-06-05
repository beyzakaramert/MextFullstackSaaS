using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.ResetPassword
{
    public class UserAuthResetPasswordHandler : IRequestHandler<UserAuthResetPasswordCommand, ResponseDto<bool>>
    {
        private readonly IIdentityService _identityService;

        public UserAuthResetPasswordHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseDto<bool>> Handle(UserAuthResetPasswordCommand request, CancellationToken cancellationToken)
        {
            await _identityService.ResetPasswordAsync(request.Email, request.Token, request.Password, cancellationToken);
            return new ResponseDto<bool>(true, "Password has been reset successfully.");
        }
    }
}
