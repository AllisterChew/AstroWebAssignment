using Allister_AstroWebAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Allister_AstroWebAssignment.Services
{
    public class WebServices
    {
        #region static readonly variable
        private static readonly HttpClient client = new HttpClient();
        private static readonly string url = "http://ams-api.astro.com.my";
        #endregion

        public Channels GetChannelList()
        {
            Channels channelList = new Channels();
            string getChannelListUrl = url + "/ams/v3/getChannelList";

            var response = InitiateWebRequest(getChannelListUrl);

            if(response.IsSuccessStatusCode)
            {
                channelList = response.Content.ReadAsAsync<Channels>().Result;
            }
            response.Dispose();

            return channelList;
        }

        public ChannelDetail GetChannelDetail(string channelId)
        {
            ChannelDetail channelList = new ChannelDetail();
            string getChannelDetailUrl = url + "/ams/v3/getChannels?channelId="+ channelId;

            var response = InitiateWebRequest(getChannelDetailUrl);

            if (response.IsSuccessStatusCode)
            {
                channelList = response.Content.ReadAsAsync<ChannelDetail>().Result;
            }
            response.Dispose();

            return channelList;
        }

        public ChannelEvent GetEvent(string channelId)
        {
            ChannelEvent channelsEvent = new ChannelEvent();
            DateTime utcTimeNow = DateTime.UtcNow;
            utcTimeNow = utcTimeNow.AddHours(8);
            var start = utcTimeNow.AddHours(-1);
            var end = utcTimeNow.AddHours(1);
            string getChannelEventUrl = url + "/ams/v3/getEvents?channelId=" + channelId + "&periodStart=" + start.ToString("yyyy-MM-dd HH:mm") + "&periodEnd=" + end.ToString("yyyy-MM-dd HH:mm");
            var response = InitiateWebRequest(getChannelEventUrl);

            if (response.IsSuccessStatusCode)
            {
                channelsEvent = response.Content.ReadAsAsync<ChannelEvent>().Result;
            }
            response.Dispose();

            foreach(var channelEvent in channelsEvent.getevent ?? new List<Events>())
            {
                var startTime = channelEvent.displayDateTime;
                TimeSpan duration;

                if (TimeSpan.TryParse(channelEvent.displayDuration, out duration))
                {
                    var endTime = startTime.Add(duration);
                    if (endTime > utcTimeNow)
                        channelEvent.currentlyAired = true;
                }
            }

            return channelsEvent;
        }

        #region common method
        public HttpResponseMessage InitiateWebRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return client.GetAsync(url).Result;
            }
        }
        #endregion
    }
}