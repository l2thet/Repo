using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ConversationTracker.Models
{
    public class ConversationLinqRepo: IConversationRepository
    {
        AppHarborDBDataContext db = new AppHarborDBDataContext(ConfigurationManager.AppSettings.Get("SQLSERVER_CONNECTION_STRING"));

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
            catch(Exception ex)
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
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}