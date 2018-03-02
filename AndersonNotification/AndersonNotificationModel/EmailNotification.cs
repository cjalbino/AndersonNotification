using BaseModel;

namespace AndersonNotificationModel
{
    public class EmailNotification : Base
    {
        public int NotificationId { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string CC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
    