using FluentValidation;
using MextFullstackSaaS.Application.Common.Interfaces;
using System.Text.RegularExpressions;

namespace MextFullstackSaaS.Application.Common.FluentValidation.BaseValidators
{
    public class UserAuthValidatorBase<T> : AbstractValidator<T> where T : class
    {
        protected readonly IIdentityService _identityService;

        public UserAuthValidatorBase(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        protected bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
        }
    }    
}
