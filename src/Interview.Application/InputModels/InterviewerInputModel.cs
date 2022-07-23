namespace Interview.Application.InputModels
{
    public class InterviewerInputModel : AvailabilityInputModel
    {
        public InterviewerInputModel(string name, List<AvailabilitySlotsInputModel> availabilities) : base(name, availabilities)
        {
        }
    }
}
