using AndersonNotificationData;
using AndersonNotificationFunction;
using AndersonNotificationModel;
using System.Web.Http;
using System;

namespace AndersonNotificationWeb.ApiControllers
{
    public class EmailNotificationApiController : BaseApiController
    {
        private IFEmailNotification _iFEmailNotification;
        private IDEmailNotification _iDEmailNotification;
        
        public EmailNotificationApiController()
        {
            _iDEmailNotification  = new DEmailNotification();
            _iFEmailNotification  = new FEmailNotification(_iDEmailNotification);
        }

        [HttpPost]
        public IHttpActionResult Get(EmailNotification emailNotification, string Password)
        {
            FEmailNotification fe = new FEmailNotification();
            fe.Send(CredentialId, emailNotification, Password);

            return Ok(emailNotification);
        }
        
    }
}