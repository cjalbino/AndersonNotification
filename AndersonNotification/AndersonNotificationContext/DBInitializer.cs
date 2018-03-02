using AndersonNotificationEntity;
using System.Data.Entity;

namespace AndersonNotificationContext
{
    public class DBInitializer : CreateDatabaseIfNotExists<Context>
    {
        public DBInitializer()
        {
        }
        protected override void Seed(Context context)
        {
            context.EmailNotifications.Add(
            new EEmalNotification
            {
                Sender = "notification@testing.com",
                Receiver = "notification@testing.com",
                CC = "notification@testing.com",
                Subject = "Testing",
                Body = "notification@testing.com",
            });
            context.SaveChanges();

        }
    }
}