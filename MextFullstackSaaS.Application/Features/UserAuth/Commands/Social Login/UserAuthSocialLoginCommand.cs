using MediatR;
using MextFullstackSaaS.Application.Common.Models;

namespace MextFullstackSaaS.Application.Features.UserAuth.Commands.Social_Login
{
    public class UserAuthSocialLoginCommand :IRequest<ResponseDto<JwtDto>>
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserAuthSocialLoginCommand(string email, string firstName,string lastName) 
        {

            Email = email;

            FirstName = firstName;

            LastName = lastName;        
        }

        public UserAuthSocialLoginCommand() 
        {

        }
    }
}
