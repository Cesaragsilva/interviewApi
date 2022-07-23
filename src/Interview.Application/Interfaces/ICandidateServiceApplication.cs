using Interview.Application.InputModels;
using Interview.Application.Services;
using Interview.Application.ViewModels;

namespace Interview.Application.Interfaces
{
    public interface ICandidateServiceApplication
    {
        Task<ResultService<AvailabilityViewModel>> GetCandidateAvailabilityByIdAsync(int id);
        Task<ResultService<AvailabilityViewModel>> AddCandidateAvailabilityAsync(CandidateInputModel availability);
        Task<ResultService> DeleteCandidateAvailabilityAsync(int id);
    }
}
