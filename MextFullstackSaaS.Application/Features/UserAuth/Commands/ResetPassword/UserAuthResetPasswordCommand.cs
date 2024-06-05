﻿using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.ResetPassword
{
    public class UserAuthResetPasswordCommand : IRequest<ResponseDto<bool>>
    {
            
        public string Token { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }

        public string Email { get; set; }

        public UserAuthResetPasswordCommand(string email ,string token, string password, string newPassword)
        {
            Token = token;
            Password = password;
            NewPassword = newPassword;
            Email = email;
        }

        
    }
}
