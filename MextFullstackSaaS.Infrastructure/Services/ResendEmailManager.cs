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
using MextFullstackSaaS.Application.Common.Translations;
using Microsoft.Extensions.Localization;

namespace MextFullstackSaaS.Infrastructure.Services
{
    public class ResendEmailManager : IEmailService
    {

        private readonly IResend _resend;
        private readonly IRootPathService _rootPathService;
        private readonly IStringLocalizer<CommonTranslations> _localizer;

        public ResendEmailManager(IResend resend, IRootPathService rootPathService, IStringLocalizer<CommonTranslations> localizer)
        {
            _resend = resend;
            _rootPathService = rootPathService;
            _localizer = localizer;
        }

        
        private const string WebAppBaseUrl = "https://localhost:7281/api/";
        public async Task SendEmailVerificationAsync(EmailSendEmailVerificationDto emailDto, CancellationToken cancellationToken)
        {
            var encodedEmail = HttpUtility.UrlEncode(emailDto.Email);
            var encodedToken = HttpUtility.UrlEncode(emailDto.Token);
            

            var link = $"{WebAppBaseUrl}verify-email?email={encodedEmail}&token={encodedToken}";

            var htmlContent =
                await File.ReadAllTextAsync($"{_rootPathService.GetRootPath()}/email-templates/userauth-template.html", cancellationToken);

            htmlContent = htmlContent.Replace("{{{link}}}", link);

            htmlContent = htmlContent.Replace("{{{subject}}}", _localizer[CommonTranslationKeys.EmailVerificationSubject]);

            htmlContent = htmlContent.Replace("{{{content}}}", _localizer[CommonTranslationKeys.EmailVerificationContent]);

            htmlContent = htmlContent.Replace("{{{buttonText}}}", _localizer[CommonTranslationKeys.EmailVerificationButtonText]);

            await SendEmailAsync(new EmailSendDto(emailDto.Email, _localizer[CommonTranslationKeys.EmailVerificationSubject], htmlContent), cancellationToken);
        }

        private Task SendEmailAsync(EmailSendDto emailSendDto, CancellationToken cancellationToken)
        {
            var message = new EmailMessage();

            message.From = "noreply@yazilim.academy";

            foreach (var emailAddress in emailSendDto.Addresses)
                message.To.Add(emailAddress);

            message.Subject = emailSendDto.Subject;
            message.HtmlBody = emailSendDto.HtmlContent;

            return _resend.EmailSendAsync(message, cancellationToken);
        }

        public async Task SendForgotPasswordEmailAsync(EmailSendForgotPasswordDto emailDto, CancellationToken cancellationToken)
        {
            var encodedEmail = HttpUtility.UrlEncode(emailDto.Email);
            var encodedToken = HttpUtility.UrlEncode(emailDto.Token);

            var link = $"{WebAppBaseUrl}verify-email?email={encodedEmail}&token={encodedToken}";

            var htmlContent = await File.ReadAllTextAsync($"{_rootPathService.GetRootPath()}/email-templates/userauth-template.html", cancellationToken);

            htmlContent = htmlContent.Replace("{{{link}}}", link);
            htmlContent = htmlContent.Replace("{{{subject}}}", "Forgot Password");
            htmlContent = htmlContent.Replace("{{{content}}}", "Kindly click the button below to reset your password.");
            htmlContent = htmlContent.Replace("{{{buttonText}}}", "Reset Password");

            await SendEmailAsync(new EmailSendDto(emailDto.Email, "Forgot Password", htmlContent), cancellationToken);
        }


        public async Task SendResetPasswordConfirmationAsync(EmailSendResetPasswordConfirmationDto emailDto, CancellationToken cancellationToken)
        {
            var message = new EmailMessage();
            message.From = "support@resend.dev";
            message.To.Add(emailDto.Email);
            message.Subject = "Password Reset Confirmation | IconBuilderAI";
            message.HtmlBody = $"<div><strong>Your password has been successfully reset.</strong></div>";

            await _resend.EmailSendAsync(message, cancellationToken);
        }      
    }
}
