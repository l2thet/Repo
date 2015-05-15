using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationTracker.Models
{
    public interface IConversationRepository
    {
        IList<ConversationTrackerObject> GetConversations();
        string SaveConversation(ConversationTrackerObject cto);
        bool DeleteConversation(ConversationTrackerObject cto);
        bool UserExists(string username, string password);

    }
}
