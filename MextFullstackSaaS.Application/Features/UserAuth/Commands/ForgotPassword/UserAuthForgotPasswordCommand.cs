using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.ForgotPassword
{
    public class UserAuthForgotPasswordCommand : IRequest<ResponseDto<bool>>
    {
      
        public string Email { get; set; }

        public UserAuthForgotPasswordCommand(string email)
        {
            Email = email;
        }

        public UserAuthForgotPasswordCommand()
        {
            
        }
    }
}
