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
                TypeOfDay(slot);
            });
            return _notificationService.Notifications.Any();
        }

        private void TypeOfDay(AvailabilitySlotsInputModel slot)
        {
            if (WeekendDay(slot.Start)) AddNotification(slot.Start);
            if (WeekendDay(slot.End)) AddNotification(slot.End);
        }

        private void AddNotification(DateTime slot) =>
            _notificationService.AddNotification($"{slot} it's a weekend and it's not allowed");

        private bool WeekendDay(DateTime date) =>
            (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);
    }
}
