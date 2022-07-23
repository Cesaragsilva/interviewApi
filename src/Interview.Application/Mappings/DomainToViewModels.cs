using Interview.Application.ViewModels;
using Interview.Core.Entities;

namespace Interview.Application.Mappings
{
    public static class DomainToViewModels
    {
        public static AvailabilityViewModel ToViewModel(this Candidate candidate)
        {
            return new AvailabilityViewModel() 
            {
                Availabilities = candidate.Availabilities.ToViewModel(),
                Id = candidate.Id,
                Name = candidate.Name
            };
        }

        public static AvailabilityViewModel ToViewModel(this Interviewer interviewer)
        {
            return new AvailabilityViewModel()
            {
                Availabilities = interviewer.Availabilities.ToViewModel(),
                Id = interviewer.Id,
                Name = interviewer.Name
            };
        }

        public static List<AvailabilitySlotsViewModel> ToViewModel(this List<AvailabilitySlots> availabilitySlots) {
            var availabilitySlotsViewModel = new List<AvailabilitySlotsViewModel>();
            availabilitySlots?.ForEach(availabilitySlot =>
            {
                availabilitySlotsViewModel.Add(new AvailabilitySlotsViewModel()
                {
                    End = availabilitySlot.End,
                    Id = availabilitySlot.Id,
                    Start = availabilitySlot.Start
                });
            });
            return availabilitySlotsViewModel;
        }
    }
}
