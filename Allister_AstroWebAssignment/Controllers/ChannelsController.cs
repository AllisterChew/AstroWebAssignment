using Allister_AstroWebAssignment.Models;
using Allister_AstroWebAssignment.Models.ViewModel;
using Allister_AstroWebAssignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Allister_AstroWebAssignment.Controllers
{
    public class ChannelsController : ApiController
    {
        #region static readonly variable
        private static readonly WebServices services = new WebServices();
        #endregion

        public ApiViewModel Get(string channelId)
        {
            ApiViewModel channelDetail = new ApiViewModel();

            channelDetail.channelsData = services.GetChannelDetail(channelId);
            channelDetail.channelsEventData = services.GetEvent(channelId);
            return channelDetail;
        }
    }
}
