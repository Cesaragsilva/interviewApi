using Interview.Application.InputModels;
using Interview.Application.Services;
using Interview.Application.ViewModels;

namespace Interview.Application.Interfaces
{
    public interface ICalendarServiceApplication
    {
        Task<ResultService<List<AvailabilitySlotsViewModel>>> CandidateAvailabilityWithInterviewers(CalendarInputModel calendarInput);
    }
}
