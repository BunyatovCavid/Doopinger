using BubbleAPi.Dtoes;
using FluentValidation;

namespace BubbleAPi.Validation
{
    public class LoginValidation : AbstractValidator<LoginDto>
    {
        public LoginValidation()
        {
            RuleFor(l=>l.Name).NotEmpty().NotNull().WithMessage("Name can not empty or null");
            RuleFor(l=>l.Password).NotEmpty().NotNull().WithMessage("Password can not empty or null");
        }
    }
}
