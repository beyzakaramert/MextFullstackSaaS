namespace MextFullstackSaaS.Application.Common.Models.Emails
{
    public class EmailSendEmailVerificationDto
    {
        public string Email { get; set; }

        public string Subject { get; set; }

        public string FirstName { get; set; }

        public string Token { get; set; }

        public EmailSendEmailVerificationDto(string email, string firstName, string token)
        {
            Email = email;
            FirstName = firstName;
            Token = token;
        }

        public EmailSendEmailVerificationDto()
        {

        }
    }
    public class EmailSendForgotPasswordDto
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public EmailSendForgotPasswordDto(string email, string token)
        {
            Email = email;
            Token = token;
        }

        public EmailSendForgotPasswordDto()
        {
        }
    }

    public class EmailSendResetPasswordConfirmationDto
    {
        public string Email { get; set; }

        public EmailSendResetPasswordConfirmationDto(string email)
        {
            Email = email;
        }

        public EmailSendResetPasswordConfirmationDto()
        {
        }
    }
}