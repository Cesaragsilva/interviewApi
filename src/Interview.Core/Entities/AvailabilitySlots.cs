using Interview.Core.Entities.Validations;

namespace Interview.Core.Entities
{
    public class AvailabilitySlots : BaseEntity
    {
        public AvailabilitySlots() { }
        public AvailabilitySlots(int id, DateTime start, DateTime end)
        {
            Id = id;
            Start = start;
            End = end;
        }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public Interviewer Interviewer { get; private set; }
        public Candidate Candidate { get; private set; }
        public bool Valid => new AvailabilitySlotsValidator().Validate(this).IsValid;
        public IReadOnlyList<string> Notifications => new AvailabilitySlotsValidator().Validate(this).Errors.Select(p => p.ErrorMessage).ToList();
    }
}
