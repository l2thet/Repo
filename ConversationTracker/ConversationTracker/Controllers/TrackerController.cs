using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConversationTracker.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Security;


namespace ConversationTracker.Controllers
{
    [RequireHttps]
    public class TrackerController : Controller
    {
        private readonly IConversationRepository iRepository;

        public TrackerController() : this(new ConversationLinqRepo()) { }

        public TrackerController(IConversationRepository repository)
        {
            iRepository = repository;
        }

        //
        // GET: /Tracker/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string returnUrl = "/")
        {
            try
            {
                if (iRepository.UserExists(username, password))
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [Authorize]
        public JsonResult retrieveTrackedConversations()
        {
            try
            {
                return Json(iRepository.GetConversations(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [Authorize]
        [HttpPost]
        public JsonResult saveTrackedConversation(ConversationTrackerObject convo)
        {
            try
            {
                convo.Id = iRepository.SaveConversation(convo);
                return Json(convo);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [Authorize]
        [HttpPost]
        public JsonResult deleteTrackedConversation(ConversationTrackerObject convo)
        {
            try
            {
                iRepository.DeleteConversation(convo);
                return Json(iRepository.GetConversations());
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}
