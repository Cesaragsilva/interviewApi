using Interview.Application.InputModels;
using Interview.Application.Interfaces;
using Interview.Application.Mappings;
using Interview.Application.ViewModels;
using Interview.Core.Entities;
using Interview.Core.Interfaces.Repository;
using Interview.Core.Notifications;

namespace Interview.Application.Services
{
    public class InterviewerServiceApplication : IInterviewerServiceApplication
    {
        private readonly IBaseRepository<Interviewer> _interviewerRepository;
        private readonly IScheduleSlotServiceApplication _scheduleSlotServiceApplication;
        private readonly NotificationService _notificationService;

        public InterviewerServiceApplication(IBaseRepository<Interviewer> interviewerRepository,
            IScheduleSlotServiceApplication scheduleSlotServiceApplication,
            NotificationService notificationService)
        {
            _interviewerRepository = interviewerRepository;
            _notificationService = notificationService;
            _scheduleSlotServiceApplication = scheduleSlotServiceApplication;
        }

        public async Task<ResultService<AvailabilityViewModel>> AddInterviewerAvailabilityAsync(InterviewerInputModel interviewer)
        {
            if (interviewer is null)
                return ResultService.Fail<AvailabilityViewModel>("Object can't be null");

            if (!interviewer.Valid)
                return ResultService.RequestError<AvailabilityViewModel>(interviewer.Notifications);

            if (_scheduleSlotServiceApplication.AllowedSlots(interviewer.Availabilities))
                return ResultService.RequestError<AvailabilityViewModel>(_notificationService.Notifications);

            var data = await _interviewerRepository.AddAsync(interviewer.ToEntity());  
            
            return ResultService.Ok(data.ToViewModel());
        }

        public async Task<ResultService> DeleteInterviewerAvailabilityAsync(int id)
        {
            var data = await _interviewerRepository.GetByIdAsync(id);
            if (data is null)
                return ResultService.Fail($"Interviewer Availability with id {id} not found");

            await _interviewerRepository.DeleteAsync(data);
            return ResultService.Ok($"Interviewer Availability {id} deleted");
        }

        public async Task<ResultService<AvailabilityViewModel>> GetInterviewerAvailabilityByIdAsync(int id)
        {
            var data = await _interviewerRepository.GetByIdAsync(id, i=> i.Availabilities);
            if (data is null)
                return ResultService.Fail<AvailabilityViewModel>($"Interviewer Availability with id {id} not found");

            return ResultService.Ok(data.ToViewModel());
        }
    }
}
