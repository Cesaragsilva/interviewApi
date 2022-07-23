using Interview.Application.InputModels;
using Interview.Application.Services;
using Interview.Application.ViewModels;

namespace Interview.Application.Interfaces
{
    public interface IInterviewerServiceApplication
    {
        Task<ResultService<AvailabilityViewModel>> GetInterviewerAvailabilityByIdAsync(int id);
        Task<ResultService<AvailabilityViewModel>> AddInterviewerAvailabilityAsync(InterviewerInputModel interviewer);
        Task<ResultService> DeleteInterviewerAvailabilityAsync(int id);
    }
}
