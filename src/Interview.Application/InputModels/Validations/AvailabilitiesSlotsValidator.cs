using FluentValidation;

namespace Interview.Application.InputModels.Validations
{
    public class AvailabilitiesSlotsValidator : AbstractValidator<AvailabilitySlotsInputModel>
    {
        public AvailabilitiesSlotsValidator()
        {
            RuleFor(x => x.Start)
                .NotEqual(default(DateTime))
                .WithMessage("{PropertyName} is required");

            RuleFor(x => x.End)
                .NotEqual(default(DateTime))
                .WithMessage("{PropertyName} is required")
                .GreaterThan(c=> c.Start)
                .WithMessage("{PropertyName} must be Greater Than Start");

            RuleFor(x => x.Start.Minute)
                .Equal(0)
                .WithMessage("{PropertyName} must be equal to 00");

            RuleFor(x => x.End.Minute)
                .Equal(0)
                .WithMessage("{PropertyName} must be equal to 00");
        }
    }
}
