using FluentValidation.Results;

namespace Interview.Core.Notifications
{
    public class NotificationService
    {
        private readonly List<string> _notifications;
        public IReadOnlyCollection<string> Notifications => _notifications;
        public bool HasNotifications => _notifications.Any();

        public NotificationService()
        {
            _notifications = new List<string>();
        }

        public void AddNotification(string message)
        {
            _notifications.Add(message);
        }
        public void AddNotifications(IEnumerable<string> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                AddNotification(error.ErrorMessage);
        }
    }
}
