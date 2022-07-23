using FluentValidation;

namespace Interview.Core.Entities.Validations
{
    public class InterviewerValidator : AbstractValidator<Interviewer>
    {
        public InterviewerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleForEach(x => x.Availabilities).SetValidator(new AvailabilitySlotsValidator());
        }
    }
}
