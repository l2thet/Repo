using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConversationTracker.Models
{
    public class ConversationTrackerObject
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string SettingOrEnvironment { get; set; }
        public string Who { get; set; }
        public int RateOfUnease { get; set; }
        public string NotesOfChangeOverTime { get; set; }
    }
}