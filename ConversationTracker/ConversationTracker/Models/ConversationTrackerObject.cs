using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ConversationTracker.Models
{
    public class ConversationTrackerObject
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        [DisplayName("Setting(Environment)")]
        public string SettingOrEnvironment { get; set; }
        public string Who { get; set; }
        [DisplayName("Rate of Unease")]
        public int RateOfUnease { get; set; }
        [DisplayName("Notes")]
        public string NotesOfChangeOverTime { get; set; }
    }
}