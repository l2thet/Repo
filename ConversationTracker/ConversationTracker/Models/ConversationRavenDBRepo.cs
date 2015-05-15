using Raven.Abstractions.Commands;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConversationTracker.Models
{
    public class ConversationRavenDBRepo : IConversationRepository
    {
        public IList<ConversationTrackerObject> GetConversations()
        {
            try
            {
                IList<ConversationTrackerObject> fromDb;

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

                return fromDb;
            }
            catch
            {
                throw;
            }
        }

        public string SaveConversation(ConversationTrackerObject cto)
        {
            try
            {
                using (IDocumentStore store = new DocumentStore
                {
                    Url = "http://localhost:8080"
                })
                {
                    store.Initialize();
                    using (IDocumentSession session = store.OpenSession())
                    {
                        session.Store(cto);
                        session.SaveChanges();
                    }
                }
                return cto.Id;
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteConversation(ConversationTrackerObject cto)
        {
            try
            {
                using (IDocumentStore store = new DocumentStore
                {
                    Url = "http://localhost:8080"
                })
                {
                    store.Initialize();
                    using (IDocumentSession session = store.OpenSession())
                    {
                        session.Advanced.Defer(new DeleteCommandData { Key = cto.Id });
                        session.SaveChanges();
                    }
                }
                return true;
            }
            catch
            {
                throw;
            }
        }


        public bool UserExists(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}