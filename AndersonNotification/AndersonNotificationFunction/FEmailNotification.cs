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

        public FEmailNotification(IDEmailNotification iDEmailNotifications) 
        {
            _iDEmailNotification = iDEmailNotifications;
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
           
            return EmailNotification(eEmailNotification);
        }
        #endregion

        #region Send
        #endregion

        #region Read
        public EmailNotification Read(int emailNotificationId)
        {
            var eEmailNotification = _iDEmailNotification.Read<EEmalNotification>(a => a.EmailNotificationId == emailNotificationId);
            return EmailNotification(eEmailNotification);
        }

        public List<EmailNotification> Read(string sortBy)
        {
            var eEmailNotifications = _iDEmailNotification.Read<EEmalNotification>(a => true, sortBy);
            return EmailNotifications(eEmailNotifications);
        }
        #endregion

        #region Update
        public EmailNotification Update(int updatedBy, EmailNotification emailNotification)
        {
            var eEmailNotification = EEmailNotification(emailNotification);
            eEmailNotification.UpdatedDate = DateTime.Now;
            eEmailNotification.UpdatedBy = updatedBy;
            eEmailNotification = _iDEmailNotification.Update(eEmailNotification);
            return EmailNotification(eEmailNotification);
        }
        #endregion

        #region Delete
        public void Delete(int emailNotificationId)
        {
            _iDEmailNotification.Delete<EEmalNotification>(a => a.EmailNotificationId == emailNotificationId);
        }
        #endregion

        #region Other Function
        public EmailNotification Send(int createdBy, EmailNotification emailNotification)
        {
            MailMessage email = new MailMessage();
            email.IsBodyHtml = emailNotification.IsBodyHtml;
            email.Body = emailNotification.Body;
            if (!string.IsNullOrEmpty(emailNotification.Bcc))
                email.Bcc.Add(emailNotification.Bcc);
            if (!string.IsNullOrEmpty(emailNotification.CC))
                email.CC.Add(emailNotification.CC);
            email.From = new MailAddress(emailNotification.From);
            email.Subject = emailNotification.Subject;
            email.To.Add(emailNotification.To);

            SmtpClient smtp = new SmtpClient();
            smtp.Host = emailNotification.Host;
            smtp.Credentials = new NetworkCredential(emailNotification.Username, emailNotification.Password);
            smtp.EnableSsl = emailNotification.EnableSsl;
            smtp.Send(email);
            Create(createdBy, emailNotification);

            return emailNotification;
        }

        private EEmalNotification EEmailNotification(EmailNotification emailNotification)
        {
            return new EEmalNotification
            {
                EnableSsl = emailNotification.EnableSsl,
                IsBodyHtml = emailNotification.IsBodyHtml,

                CreatedDate = emailNotification.CreatedDate,
                UpdatedDate = emailNotification.UpdatedDate,

                CreatedBy = emailNotification.CreatedBy,
                EmailNotificationId = emailNotification.EmailNotificationId,
                UpdatedBy = emailNotification.UpdatedBy,

                Body = emailNotification.Body,
                Bcc = emailNotification.Bcc,
                CC = emailNotification.CC,
                Host = emailNotification.Host,
                From = emailNotification.From,
                Subject = emailNotification.Subject,
                To = emailNotification.To,
                Username = emailNotification.Username,
            };
        }

        private EmailNotification EmailNotification(EEmalNotification eEmailNotification)
        {
            return new EmailNotification
            {
                EnableSsl = eEmailNotification.EnableSsl,
                IsBodyHtml = eEmailNotification.IsBodyHtml,

                CreatedDate = eEmailNotification.CreatedDate,
                UpdatedDate = eEmailNotification.UpdatedDate,

                CreatedBy = eEmailNotification.CreatedBy,
                EmailNotificationId = eEmailNotification.EmailNotificationId,
                UpdatedBy = eEmailNotification.UpdatedBy,

                Body = eEmailNotification.Body,
                Bcc = eEmailNotification.Bcc,
                CC = eEmailNotification.CC,
                Host = eEmailNotification.Host,
                From = eEmailNotification.From,
                Subject = eEmailNotification.Subject,
                To = eEmailNotification.To,
                Username = eEmailNotification.Username,
            };
        }
        private List<EmailNotification> EmailNotifications(List<EEmalNotification> eEmailNotifications)
        {
            return eEmailNotifications.Select(a => new EmailNotification
            {
                EnableSsl = a.EnableSsl,
                IsBodyHtml = a.IsBodyHtml,

                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,

                CreatedBy = a.CreatedBy,
                EmailNotificationId = a.EmailNotificationId,
                UpdatedBy = a.UpdatedBy,

                Body = a.Body,
                Bcc = a.Bcc,
                CC = a.CC,
                Host = a.Host,
                From = a.From,
                Subject = a.Subject,
                To = a.To,
                Username = a.Username,
            }).ToList();
        }
        #endregion

    }
}