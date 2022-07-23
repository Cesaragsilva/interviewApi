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

            RuleFor(x => x.Start)
                .Must(time=> HourWithMinutesOrSeconds(time))
                .WithMessage("{PropertyName} must be equal to HH:00:00");

            RuleFor(x => x.End)
                .Must(time => HourWithMinutesOrSeconds(time))
                .WithMessage("{PropertyName} must be equal to HH:00:00");

            RuleFor(x => x.Start)
                .Must(day => DayOfWeekend(day.DayOfWeek))
                .WithMessage("Start {PropertyValue} it's a weekend and it's not allowed");

            RuleFor(x => x.End)
                .Must(day => DayOfWeekend(day.DayOfWeek))
                .WithMessage("End {PropertyValue} it's a weekend and it's not allowed");

        }

        private static bool DayOfWeekend(DayOfWeek day) => (day != DayOfWeek.Sunday && day != DayOfWeek.Saturday);
        private static bool HourWithMinutesOrSeconds(DateTime time) => (time.Minute == 0 && time.Second == 0);
    }
}
