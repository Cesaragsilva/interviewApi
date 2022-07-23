using Interview.Application.InputModels;
using Interview.Application.Interfaces;
using Interview.Core.Notifications;

namespace Interview.Application.Services
{
    public class ScheduleSlotServiceApplication : IScheduleSlotServiceApplication
    {
        private readonly NotificationService _notificationService;
        public ScheduleSlotServiceApplication(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public bool AllowedSlots(List<AvailabilitySlotsInputModel> slots)
        {
            slots.ForEach(slot =>
            {
                CheckTotalOfHoursPerSlot(slot);
            });
            return _notificationService.Notifications.Any();
        }
        private void CheckTotalOfHoursPerSlot(AvailabilitySlotsInputModel slot)
        {
            if(slot.SlotWithMoreThanOneHour())
                _notificationService.AddNotification($"Slot Start: {slot.Start} - End {slot.End} it can't be more than One Hour");
        }
    }
}
