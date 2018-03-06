using AndersonNotificationModel;
using System.Collections.Generic;

namespace AndersonNotificationFunction
{
    public interface IFEmailNotification
    {
        #region Create
        EmailNotification Create(int createdBy, EmailNotification emailnotification);
        #endregion

        #region Send
        EmailNotification Send(int createdBy, EmailNotification emailnotification, string Password);
        #endregion

        #region Read
        EmailNotification Read(int notificationId);
        List<EmailNotification> Read(string sortBy);
        #endregion

        #region Update
        EmailNotification Update(int updatedBy, EmailNotification emailnotification);
        #endregion

        #region Delete
        void Delete(int notificationId);
        #endregion
        
        #region Other Function

        #endregion
    }
}
