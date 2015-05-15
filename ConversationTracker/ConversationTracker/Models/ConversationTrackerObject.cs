﻿using MongoDB.Bson.Serialization.Attributes;
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
        [DisplayName("DateTime")]
        public DateTime Date { get; set; }
        public string SettingOrEnvironment { get; set; }
        public string Who { get; set; }
        public int RateOfUnease { get; set; }
        public string NotesOfChangeOverTime { get; set; }
    }
}