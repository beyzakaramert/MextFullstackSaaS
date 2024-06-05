using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models.Emails;
using Resend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resend;
using System.Web;
using MextFullstackSaaS.Domain.Identity;

namespace MextFullstackSaaS.Infrastructure.Services
{
    public class ResendEmailManager : IEmailService
    {
        private readonly IResend _resend;

        public ResendEmailManager(IResend resend)
        {
            _resend = resend;
        }

        private const string ApiBaseUrl = "https://localhost:7281/api/";
        public Task SendEmailVerificationAsync(EmailSendEmailVerificationDto emailDto, CancellationToken cancellationToken)
        {
            var encodedEmail = HttpUtility.UrlEncode(emailDto.Email);
            var encodedToken = HttpUtility.UrlEncode(emailDto.Token);
            

            var link = $"{ApiBaseUrl}UsersAuth/verify-email?email={encodedEmail}&token={encodedToken}";

            

            var message = new EmailMessage();
            message.From = "onboarding@resend.dev";
            message.To.Add(emailDto.Email);
            message.Subject = "Email Verification | IconBuilderAI";
            message.HtmlBody = $"<div><a href=\"{link}\" target=\"_blank\"><strong>Greetings<strong> 👋🏻 from .NET</a></div>";

            return _resend.EmailSendAsync(message,cancellationToken);
        }

        public Task SendForgotPasswordEmailAsync(EmailSendForgotPasswordDto emailDto, CancellationToken cancellationToken)
        {
            var encodedEmail = HttpUtility.UrlEncode(emailDto.Email);
            var encodedToken = HttpUtility.UrlEncode(emailDto.Token);

            var link = $"{ApiBaseUrl}UsersAuth/reset-password?email={encodedEmail}&token={encodedToken}";

            var message = new EmailMessage();
            message.From = "support@resend.dev";
            message.To.Add(emailDto.Email);
            message.Subject = "Password Reset Request | IconBuilderAI";
            message.HtmlBody = $"<div><a href=\"{link}\" target=\"_blank\"><strong>Click here to reset your password</strong></a></div>";

            return _resend.EmailSendAsync(message, cancellationToken);
        }

        public Task SendResetPasswordConfirmationAsync(EmailSendResetPasswordConfirmationDto emailDto, CancellationToken cancellationToken)
        {
            var message = new EmailMessage();
            message.From = "support@resend.dev";
            message.To.Add(emailDto.Email);
            message.Subject = "Password Reset Confirmation | IconBuilderAI";
            message.HtmlBody = $"<div><strong>Your password has been successfully reset.</strong></div>";

            return _resend.EmailSendAsync(message, cancellationToken);
        }

    }
}
