using System.Collections.Generic;

namespace CQSSample.Domain.Notification
{
    public class DomainNotificationContext : IDomainNotificationContext
    {
        private List<string> failures;

        public DomainNotificationContext()
        {
            failures = new List<string>();
        }

        public bool HasErrorNotifications { get => failures.Count > 0 ? true : false; }

        public IEnumerable<string> GetErrorNotifications()
        {
            return failures;
        }

        public void NotifyError(string failure)
        {
            this.failures.Add(failure);
        }
    }
}