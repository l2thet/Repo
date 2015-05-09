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
        
        //
        // GET: /Tracker/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult retrieveTrackedConversations()
        {
            AppHarborDBDataContext db = new AppHarborDBDataContext(ConfigurationManager.AppSettings.Get("SQLSERVER_CONNECTION_STRING"));
            List<prc_RetrieveConversationsResult> fromDb = db.prc_RetrieveConversations().ToList();

            return Json(fromDb, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult saveTrackedConversation(ConversationTrackerObject convo)
        {
            try
            {
                AppHarborDBDataContext db = new AppHarborDBDataContext(ConfigurationManager.AppSettings.Get("SQLSERVER_CONNECTION_STRING"));
                prc_InsertConversationResult sqldata = db.prc_InsertConversation(convo.Date, convo.SettingOrEnvironment, convo.Who, short.Parse(convo.RateOfUnease.ToString()), convo.NotesOfChangeOverTime).FirstOrDefault();
                convo.Id = sqldata.Id.ToString();
                return Json(convo);
            }
            catch(Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public JsonResult deleteTrackedConversation(ConversationTrackerObject convo)
        {
            AppHarborDBDataContext db = new AppHarborDBDataContext(ConfigurationManager.AppSettings.Get("SQLSERVER_CONNECTION_STRING"));
            db.prc_DeleteConversation(int.Parse(convo.Id));
            List<prc_RetrieveConversationsResult> fromDb = db.prc_RetrieveConversations().ToList();
            return Json(fromDb);
        }
    }
}
