using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Allister_AstroWebAssignment.Models
{
    public class Channels
    {
        public List<Channel> channels { get; set; }
    }

    public class ChannelDetail
    {
        public List<Channel> channel { get; set; }
    }

    public class ChannelEvent
    {
        public List<Events> getevent { get; set; }
    }

    public class Channel
    {
        public int channelId { get; set; }
        public string channelTitle { get; set; }
        public int channelStbNumber { get; set; }
        public string channelDescription { get; set; }
        public string channelLanguage { get; set; }
        public string channelCategory { get; set; }
        public List<ExtensionReference> channelExtRef { get; set; }
        public bool isFavourite { get; set; }
        public List<Events> getevent { get; set; }
    }

    public class ExtensionReference
    {
        public string system { get; set; }
        public string value { get; set; }
    }

    public class Events
    {
        public string epgEventImage { get; set; }
        public string programmeTitle { get; set; }
        public string shortSynopsis { get; set; }
        public string genre { get; set; }
        public DateTime displayDateTime { get; set; }
        public string displayDuration { get; set; }
        public bool currentlyAired { get; set; }
    }
}