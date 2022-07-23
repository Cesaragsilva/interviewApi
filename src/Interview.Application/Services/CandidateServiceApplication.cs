using Interview.Application.InputModels;
using Interview.Application.Interfaces;
using Interview.Application.Mappings;
using Interview.Application.ViewModels;
using Interview.Core.Entities;
using Interview.Core.Interfaces.Repository;
using Interview.Core.Notifications;

namespace Interview.Application.Services
{
    public class CandidateServiceApplication : ICandidateServiceApplication
    {
        private readonly IBaseRepository<Candidate> _candidateRepository;
        private readonly IScheduleSlotServiceApplication _scheduleSlotServiceApplication;
        private readonly NotificationService _notificationService;
        public CandidateServiceApplication(IBaseRepository<Candidate> candidateRepository,
            IScheduleSlotServiceApplication scheduleSlotServiceApplication, 
            NotificationService notificationService)
        {
            _candidateRepository = candidateRepository;
            _scheduleSlotServiceApplication = scheduleSlotServiceApplication;
            _notificationService = notificationService;
        }

        public async Task<ResultService<AvailabilityViewModel>> AddCandidateAvailabilityAsync(CandidateInputModel candidate)
        {
            if (!candidate.Valid) return ResultService.RequestError<AvailabilityViewModel>(candidate.Notifications);

            if (_scheduleSlotServiceApplication.AllowedSlots(candidate.Availabilities))
                return ResultService.RequestError<AvailabilityViewModel>(_notificationService.Notifications);

            var data = await _candidateRepository.AddAsync(candidate.ToEntity());            
            return ResultService.Ok(data.ToViewModel());
        }

        public async Task<ResultService> DeleteCandidateAvailabilityAsync(int id)
        {
            var data = await _candidateRepository.GetByIdAsync(id);
            if (data is null)
                return ResultService.Fail($"Id {id} not found");

            await _candidateRepository.DeleteAsync(data);
            return ResultService.Ok($"Candidate Availability {id} deleted");
        }

        public async Task<ResultService<AvailabilityViewModel>> GetCandidateAvailabilityByIdAsync(int id)
        {
            var data = await _candidateRepository.GetByIdAsync(id, c=> c.Availabilities);
            if (data is null)
                return ResultService.Fail<AvailabilityViewModel>($"Id {id} not found");

            return ResultService.Ok(data.ToViewModel());
        }
    }
}
