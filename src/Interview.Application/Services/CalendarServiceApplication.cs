using Interview.Application.InputModels;
using Interview.Application.Interfaces;
using Interview.Application.ViewModels;
using Interview.Core.Entities;
using Interview.Core.Interfaces.Repository;

namespace Interview.Application.Services
{
    public class CalendarServiceApplication : ICalendarServiceApplication
    {
        private readonly IBaseRepository<Candidate> _candidateRepository;

        private readonly IBaseRepository<Interviewer> _interviewsRepository;
        public CalendarServiceApplication(IBaseRepository<Candidate> candidateRepository,
            IBaseRepository<Interviewer> interviewsRepository)
        {
            _candidateRepository = candidateRepository;
            _interviewsRepository = interviewsRepository;
        }
        public async Task<ResultService<List<AvailabilitySlotsViewModel>>> CandidateAvailabilityWithInterviewers(CalendarInputModel calendarInput)
        {
            var candidate = await _candidateRepository.GetByIdAsync(calendarInput.CandidateId, c => c.Availabilities);
            var interviewers = await _interviewsRepository.GetAsync(c => calendarInput.InterviewersIds.Contains(c.Id), a => a.Availabilities);
            var slots = SlotsWithOthersInterviewers(candidate.Availabilities, interviewers);

            if (!slots.Any())
                return ResultService.Fail<List<AvailabilitySlotsViewModel>>($"Slots not found");

            return ResultService.Ok(slots);
        }

        private static List<AvailabilitySlotsViewModel> SlotsWithOthersInterviewers(List<AvailabilitySlots> candidateAvailabilites, IEnumerable<Interviewer> interviewers)
        {
            var slots = new List<AvailabilitySlotsViewModel>();
            foreach (var interviewer in interviewers)
            {
                foreach (var candidateAvailability in candidateAvailabilites)
                {
                    var slot = interviewer.Availabilities.Where(c => c.Start >= candidateAvailability.Start
                                                                    && c.End <= candidateAvailability.End).FirstOrDefault();
                    if (slot is not null)
                    {
                        var joinWithAnotherInterviewer = interviewers.Count() <= 1 || interviewers.Any(c => c.Id != interviewer.Id && c.Availabilities.Any(a => a.Start >= slot.Start && a.End <= slot.End));
                        if (joinWithAnotherInterviewer && !slots.Any(a => a.Start == slot.Start && a.End == slot.End))
                            slots.Add(new(slot.Id, slot.Start, slot.End));
                    }
                }
            }
            return slots;
        }
    }
}
