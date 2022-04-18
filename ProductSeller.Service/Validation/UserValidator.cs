using FluentValidation;
using ProductSeller.Domain.Entities;

namespace ProductSeller.Service.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        private const string _passwordRegex = "";

        public UserValidator()
        {
            RuleFor(c => c.Password).NotEmpty().NotNull().Length(12, 32).Matches(_passwordRegex);
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
            RuleFor(c => c.Name).NotEmpty().NotNull();
        }
    }
}
