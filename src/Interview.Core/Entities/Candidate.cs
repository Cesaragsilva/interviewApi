using Interview.Core.Entities.Validations;

namespace Interview.Core.Entities
{
    public sealed class Candidate : BaseEntity
    {
        public Candidate() { }

        public Candidate(int id, string name, List<AvailabilitySlots> availabilities)
        {
            Id = id;
            Name = name;
            Availabilities = availabilities;
        }

        public string Name { get; private set; }
        public List<AvailabilitySlots> Availabilities { get; set; }
        public bool Valid => new CandidateValidator().Validate(this).IsValid;
        public IReadOnlyList<string> Notifications => new CandidateValidator().Validate(this).Errors.Select(p => p.ErrorMessage).ToList();
    }
}
