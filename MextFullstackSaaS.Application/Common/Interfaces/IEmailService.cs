using MextFullstackSaaS.Application.Common.Models.Emails;

namespace MextFullstackSaaS.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailVerificationAsync(EmailSendEmailVerificationDto emailDto, CancellationToken cancellationToken);
        Task SendForgotPasswordEmailAsync(EmailSendForgotPasswordDto emailDto, CancellationToken cancellationToken);
        Task SendResetPasswordConfirmationAsync(EmailSendResetPasswordConfirmationDto emailDto, CancellationToken cancellationToken);
    }
}
