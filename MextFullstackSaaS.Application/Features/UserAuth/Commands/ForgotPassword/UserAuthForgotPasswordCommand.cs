using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.ForgotPassword
{
    public class UserAuthForgotPasswordCommand : IRequest<ResponseDto<bool>>
    {
        public string Email { get; set; }

    }
}
