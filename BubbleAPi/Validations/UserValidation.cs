using BubbleAPi.Domain.Entities;
using BubbleAPi.Dtoes;
using FluentValidation;

namespace BubbleAPi.Validations
{
    public class UserValidation:AbstractValidator<UserPostDto>
    {
        public UserValidation()
        {
            RuleFor(l => l.Name).NotEmpty().NotNull().WithMessage("Name can not empty or null");
            RuleFor(l => l.Password).NotEmpty().NotNull().WithMessage("Password can not empty or null");
        }
    }
}
