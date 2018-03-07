using AndersonNotificationFunction;
using AndersonNotificationModel;
using System.Web.Mvc;

namespace AndersonNotificationWeb.Controllers
{
    public class EmailNotificationController : BaseController
    {
        private IFEmailNotification _iFEmailNotification;
        public EmailNotificationController(IFEmailNotification iFEmailNotification)
        {
            _iFEmailNotification = iFEmailNotification;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new EmailNotification());
        }

        [HttpPost]
        public ActionResult Create(EmailNotification notification)
        {
            _iFEmailNotification.Send(CredentialId,notification);
            return View(notification);
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        TempData["message"] = "Email has been sent, successfully!";
            //    }
            //    return RedirectToAction("Create");
            //}
            //catch (Exception )
            //{
            //    if (ModelState.IsValid)
            //    {
            //        TempData["message"] = "Opps! Something went wrong. Please, try again.";
            //    }
            //    return RedirectToAction("Create");
            //}
        }

        #endregion

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFEmailNotification.Read("Name"));
        }
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion

        #region Other Function
        #endregion
    }
}