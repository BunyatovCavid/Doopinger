using BubbleAPi.Dtoes;
using FluentValidation;

namespace BubbleAPi.Validations
{
    public class CourseValidation: AbstractValidator<CoursePostDto>
    {
        public CourseValidation()
        {
            RuleFor(c=>c.Name).NotEmpty().NotNull().WithMessage("Name can not null or empty");
        }
    }
}
