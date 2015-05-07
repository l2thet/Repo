using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConversationTracker.Models;
using Raven.Abstractions.Commands;

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

            using (IDocumentStore store = new DocumentStore
            {
                Url = "http://localhost:8080/"
            })
            {
                store.Initialize();
                using (IDocumentSession session = store.OpenSession())
                {
                    fromDb = session.Query<ConversationTrackerObject>().ToList();
                }
            }

            return Json(fromDb, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult saveTrackedConversation(ConversationTrackerObject convo)
        {
            using (IDocumentStore store = new DocumentStore
            {
                Url = "http://localhost:8080"
            })
            {
                store.Initialize();
                using (IDocumentSession session = store.OpenSession())
                {
                    session.Store(convo);
                    session.SaveChanges();
                }
            }
            return Json(convo);
        }

        [HttpPost]
        public JsonResult deleteTrackedConversation(ConversationTrackerObject convo)
        {
            List<ConversationTrackerObject> fromDb;
            using (IDocumentStore store = new DocumentStore
            {
                Url = "http://localhost:8080"
            })
            {
                store.Initialize();
                using (IDocumentSession session = store.OpenSession())
                {
                    session.Advanced.Defer(new DeleteCommandData { Key = convo.Id });
                    session.SaveChanges();
                    fromDb = session.Query<ConversationTrackerObject>().ToList();
                }
            }
            return Json(fromDb);
        }
    }
}
