using FluentValidation;

namespace Interview.Application.InputModels.Validations
{
    public class AvailabilityValidator : AbstractValidator<AvailabilityInputModel>
    {
        public AvailabilityValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(x => x.Availabilities)
                .NotNull()
                .WithMessage("{PropertyName} is required");

            RuleForEach(x => x.Availabilities).SetValidator(new AvailabilitiesSlotsValidator());
        }
    }
}
