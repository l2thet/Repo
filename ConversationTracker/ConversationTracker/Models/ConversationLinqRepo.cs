using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ConversationTracker.Models
{
    public class ConversationLinqRepo: IConversationRepository
    {
        AppHarborDBDataContext db = new AppHarborDBDataContext(ConfigurationManager.ConnectionStrings["ConversationTrackerConnectionString"].ToString());

        public IList<ConversationTrackerObject> GetConversations()
        {
            return db.prc_RetrieveConversations()
                    .Select(a => new ConversationTrackerObject() { 
                        Id = a.Id.ToString(),
                        Date = a.Date.Value,
                        NotesOfChangeOverTime = a.NotesOfChangeOverTime,
                        RateOfUnease = a.RateOfUnease.Value,
                        SettingOrEnvironment = a.SettingOrEnvironment,
                        Who = a.Who
                    }).ToList();
        }

        public string SaveConversation(ConversationTrackerObject cto)
        {
            try
            {
                prc_InsertConversationResult sqlresult = db.prc_InsertConversation(cto.Date, cto.SettingOrEnvironment, cto.Who, short.Parse(cto.RateOfUnease.ToString()), cto.NotesOfChangeOverTime).FirstOrDefault();
                return sqlresult.Id.ToString();
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
                db.prc_DeleteConversation(Int32.Parse(cto.Id));
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool UserExists(string username, string password)
        {
            try
            {
                prc_CheckForUserResult dbresults = db.prc_CheckForUser(username, password).FirstOrDefault();
                if(dbresults.Exists.Value)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}