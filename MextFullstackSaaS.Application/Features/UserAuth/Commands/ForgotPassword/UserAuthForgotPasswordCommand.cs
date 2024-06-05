using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserAuthLoginCommand : IRequest<ResponseDto<JwtDto>>
{
    public string Email { get; set; }
   
}

   
