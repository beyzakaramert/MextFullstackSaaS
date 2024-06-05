using FluentValidation;
using MextFullstackSaaS.Application.Common.FluentValidation.BaseValidators;
using MextFullstackSaaS.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.ResetPassword
{
    public class UserAuthResetPasswordCommandValidator : UserAuthValidatorBase<UserAuthResetPasswordCommand>
    {
        public UserAuthResetPasswordCommandValidator(IIdentityService identityService) : base(identityService)
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not valid.");

            RuleFor(x => x.Token)
                .NotEmpty().WithMessage("Token is required.")
                .MinimumLength(10).WithMessage("Token must be at least 10 characters long.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.Email)
                .MustAsync(CheckIfUserExists).WithMessage("User with this email does not exist.");
        }

        private async Task<bool> CheckIfUserExists(string email, CancellationToken cancellationToken)
        {
            return await _identityService.IsEmailExistsAsync(email, cancellationToken);
        }
    }
}
