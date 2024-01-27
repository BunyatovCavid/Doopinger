using BubbleAPi.Dtoes;
using FluentValidation;

namespace BubbleAPi.Validations
{
    public class CourseReportValidation : AbstractValidator<CourseReportPostDto>
    {
        public CourseReportValidation()
        {
            RuleFor(cr=>cr.CourseId).NotNull().NotEmpty().WithMessage("Please choose a course");
        }
    }
}
