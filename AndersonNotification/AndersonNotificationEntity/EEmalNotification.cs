using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonNotificationEntity
{
    [Table("EmalNotification")]
    public class EEmalNotification : EBase
    {
        public bool EnableSsl { get; set; }
        public bool IsBodyHtml { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmailNotificationId { get; set; }
        public int Port { get; set; }

        public string Body { get; set; }
        public string Bcc { get; set; }
        public string CC { get; set; }
        public string Host { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string To { get; set; }
        public string Username { get; set; }

    }
}