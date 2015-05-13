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


namespace ConversationTracker.Controllers
{
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

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult retrieveTrackedConversations()
        {
            try
            {
                return Json(iRepository.GetConversations(), JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(ex);
            }
        }

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
