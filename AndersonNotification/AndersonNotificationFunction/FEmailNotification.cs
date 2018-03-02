using AndersonNotificationData;
using AndersonNotificationEntity;
using AndersonNotificationModel;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Net.Mail;
using System.Net;

namespace AndersonNotificationFunction
{
    public class FEmailNotification : IFEmailNotification
    {
        private IDEmailNotification _iDEmailNotification;

        public FEmailNotification(IDEmailNotification iDNotifications) 
        {
            _iDEmailNotification = iDNotifications;
        }

        public FEmailNotification()
        {
            _iDEmailNotification = new DEmailNotification();

        }
        #region Create
        public EmailNotification Create(int createdBy, EmailNotification emailNotification)
        {   
            var eEmailNotification = EEmailNotification(emailNotification);
            eEmailNotification.CreatedDate = DateTime.Now;
            eEmailNotification.CreatedBy = createdBy;
            eEmailNotification = _iDEmailNotification.Insert(eEmailNotification);
           
            return Notification(eEmailNotification);
        }

        public void Send(object credentialId, EmailNotification emailNotification)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Send
        public EmailNotification Send(int createdBy,EmailNotification emailNotification, string Password)

        {
     
            Create(createdBy, emailNotification);
            MailMessage email = new MailMessage();
            email.To.Add(emailNotification.Receiver);
            email.From = new MailAddress(emailNotification.Sender);
            email.Subject = emailNotification.Subject;
            string Body = emailNotification.Body;
            email.Body = emailNotification.Body;
            email.CC.Add(emailNotification.CC);

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential(emailNotification.Sender, Password);
            smtp.EnableSsl = true;
            smtp.Send(email);

     return emailNotification;
        }
        #endregion

        #region Read
        public EmailNotification Read(int notificationId)
        {
            var eEmailNotification = _iDEmailNotification.Read<EEmalNotification>(a => a.NotificationId == notificationId);
            return Notification(eEmailNotification);
        }

        public List<EmailNotification> Read(string sortBy)
        {
            var eEmailNotifications = _iDEmailNotification.Read<EEmalNotification>(a => true, sortBy);
            return Notifications(eEmailNotifications);
        }
        #endregion

        #region Update
        public EmailNotification Update(int updatedBy, EmailNotification emailNotification)
        {
            var eEmailNotification = EEmailNotification(emailNotification);
            eEmailNotification.UpdatedDate = DateTime.Now;
            eEmailNotification.UpdatedBy = updatedBy;
            eEmailNotification = _iDEmailNotification.Update(eEmailNotification);
            return Notification(eEmailNotification);
        }
        #endregion

        #region Delete
        public void Delete(int notificationId)
        {
            _iDEmailNotification.Delete<EEmalNotification>(a => a.NotificationId == notificationId);
        }
        #endregion

        #region Other Function
        private EEmalNotification EEmailNotification(EmailNotification emailnotification)
        {
            return new EEmalNotification
            {
                CreatedDate = emailnotification.CreatedDate,
                UpdatedDate = emailnotification.UpdatedDate,

                CreatedBy = emailnotification.CreatedBy,
                UpdatedBy = emailnotification.UpdatedBy,

                NotificationId = emailnotification.NotificationId,
  Sender = emailnotification.Sender,
                CC = emailnotification.CC,
                Receiver = emailnotification.Receiver,
                Subject = emailnotification.Subject,
                Body = emailnotification.Body,
            };
        }

        private EmailNotification Notification(EEmalNotification eemailnotification)
        {
            return new EmailNotification
            {
                CreatedDate = eemailnotification.CreatedDate,
                UpdatedDate = eemailnotification.UpdatedDate,

                CreatedBy = eemailnotification.CreatedBy,
                UpdatedBy = eemailnotification.UpdatedBy,
                CC = eemailnotification.CC,
                NotificationId = eemailnotification.NotificationId,
                Sender = eemailnotification.Sender,
               
                Receiver = eemailnotification.Receiver,
                Subject = eemailnotification.Subject,
                Body = eemailnotification.Body,
            };
        }
        private List<EmailNotification> Notifications(List<EEmalNotification> eemailnotifications)
        {
            return eemailnotifications.Select(a => new EmailNotification
            {
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy,

                NotificationId = a.NotificationId,
                Sender = a.Sender,
                CC = a.CC,
                Receiver = a.Receiver,
                Subject = a.Subject,
                Body = a.Body,
            }).ToList();
        }
        #endregion

    }
}