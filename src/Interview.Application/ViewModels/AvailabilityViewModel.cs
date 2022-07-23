namespace Interview.Application.ViewModels
{
    public class AvailabilityViewModel
    {
        public AvailabilityViewModel()
        {
        }

        public AvailabilityViewModel(int id, string name, List<AvailabilitySlotsViewModel> availabilities)
        {
            Id = id;
            Name = name;
            Availabilities = availabilities;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<AvailabilitySlotsViewModel> Availabilities { get; set; }
    }
    public class AvailabilitySlotsViewModel
    {
        public AvailabilitySlotsViewModel() { }
        public AvailabilitySlotsViewModel(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
