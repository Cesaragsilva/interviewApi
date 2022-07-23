using FluentValidation;

namespace Interview.Core.Entities.Validations
{
    public class AvailabilitySlotsValidator : AbstractValidator<AvailabilitySlots>
    {
        public AvailabilitySlotsValidator()
        {
            RuleFor(x => x.Start)
                  .NotEqual(default(DateTime))
                  .WithMessage("{PropertyName} is required");

            RuleFor(x => x.End)
                    .NotEqual(default(DateTime))
                    .WithMessage("{PropertyName} is required")
                    .GreaterThan(c => c.Start)
                    .WithMessage("{PropertyName} must be Greater Than Start");

        }
    }
}
