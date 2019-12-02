using System.Collections.Generic;

namespace CQSSample.Domain.Notification
{
    public interface IDomainNotificationContext
    {
         bool HasErrorNotifications { get; }
         IEnumerable<string> GetErrorNotifications();         
         void NotifyError(string failure);
    }
}