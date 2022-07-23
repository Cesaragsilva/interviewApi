using FluentValidation;

namespace Interview.Core.Entities.Validations
{
    public class CandidateValidator : AbstractValidator<Candidate>
    {
        public CandidateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleForEach(x => x.Availabilities).SetValidator(new AvailabilitySlotsValidator());
        }
    }
}
