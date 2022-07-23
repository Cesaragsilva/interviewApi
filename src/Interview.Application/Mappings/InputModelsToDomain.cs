using Interview.Application.InputModels;
using Interview.Core.Entities;

namespace Interview.Application.Mappings
{
    public static class InputModelsToDomain
    {
        public static Candidate ToEntity(this CandidateInputModel candidate) =>
             new Candidate(candidate.Id, candidate.Name, candidate.Availabilities.ToEntity());

        public static Interviewer ToEntity(this InterviewerInputModel interviewer) =>
             new Interviewer(interviewer.Id,interviewer.Name, interviewer.Availabilities.ToEntity());

        public static List<AvailabilitySlots> ToEntity(this List<AvailabilitySlotsInputModel> slots)
        {
            var slotsViewModel = new List<AvailabilitySlots>();
            slots.ForEach(slot =>
            {
                slotsViewModel.Add(new AvailabilitySlots(slot.Id, slot.Start, slot.End));
            });
            return slotsViewModel;
        }
    }
}
