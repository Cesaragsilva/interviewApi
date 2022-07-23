namespace Interview.Application.InputModels
{
    public class CandidateInputModel : AvailabilityInputModel
    {
        public CandidateInputModel(string name, List<AvailabilitySlotsInputModel> availabilities) : base(name, availabilities)
        {
        }
    }
}
