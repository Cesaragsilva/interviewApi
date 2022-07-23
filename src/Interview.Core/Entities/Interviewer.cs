using Interview.Core.Entities.Validations;

namespace Interview.Core.Entities
{
    public class Interviewer : BaseEntity
    {
        public Interviewer() { }

        public Interviewer(int id, string name, List<AvailabilitySlots> availabilities)
        {
            Id = id;
            Name = name;
            Availabilities = availabilities;
        }

        public string Name { get; private set; }
        public List<AvailabilitySlots> Availabilities { get; set; }
        public bool Valid => new InterviewerValidator().Validate(this).IsValid;
        public IReadOnlyList<string> Notifications => new InterviewerValidator().Validate(this).Errors.Select(p => p.ErrorMessage).ToList();
    }
}
