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
            List<ConversationTrackerObject> fromDb;

            var connectionstring = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
            var url = new MongoUrl(connectionstring);
            var client = new MongoClient(url);
            var db = client.GetDatabase(url.DatabaseName);
            var collection = db.GetCollection<ConversationTrackerObject>("conversations");
            Task<List<ConversationTrackerObject>> waiting = collection.Find(x => x.RateOfUnease >= 0).ToListAsync();
            waiting.Wait();
            fromDb = waiting.Result;

            return Json(fromDb, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult saveTrackedConversation(ConversationTrackerObject convo)
        {
            try
            {
                var connectionstring = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
                var url = new MongoUrl(connectionstring);
                var client = new MongoClient(url);
                var db = client.GetDatabase(url.DatabaseName);
                var collection = db.GetCollection<ConversationTrackerObject>("conversations");
                collection.InsertOneAsync(convo).Wait();

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
            List<ConversationTrackerObject> fromDb;

            var connectionstring = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
            var url = new MongoUrl(connectionstring);
            var client = new MongoClient(url);
            var db = client.GetDatabase(url.DatabaseName);
            var collection = db.GetCollection<ConversationTrackerObject>("conversations");
            collection.DeleteOneAsync(x => x.Id == convo.Id).Wait();
            Task<List<ConversationTrackerObject>> waiting = collection.Find(x => x.RateOfUnease >= 0).ToListAsync();
            waiting.Wait();
            fromDb = waiting.Result;

            return Json(fromDb);
        }
    }
}
