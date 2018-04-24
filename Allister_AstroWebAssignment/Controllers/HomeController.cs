using Allister_AstroWebAssignment.Models.ViewModel;
using Allister_AstroWebAssignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Allister_AstroWebAssignment.Controllers
{
    public class HomeController : Controller
    {
        private static readonly WebServices services = new WebServices();

        public ActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.channelsData = services.GetChannelList();

            var retrieveCookies = RetrieveCookies();
            if(retrieveCookies != null && viewModel.channelsData.channels != null && viewModel.channelsData.channels.Count > 0)
            {
                string[] channelIds = retrieveCookies.Split(',');
                int channelIdsCookies = channelIds.Count();
                foreach (var channels in viewModel.channelsData.channels)
                {
                    if (channels.channelId > 0)
                    {
                        for (int i = 0; i < channelIdsCookies; i++)
                        {
                            int channelId = 0;
                            if (Int32.TryParse(channelIds[i], out channelId))
                            {
                                if (channels.channelId.Equals(channelId))
                                {
                                    channels.isFavourite = true;
                                }
                            }
                        }
                    }
                }
            }

            return View(viewModel);
        }

        public ActionResult ReleaseNote()
        {
            return View();
        }

        public string RetrieveCookies()
        {
            return Request.Cookies["favourite"] != null ? Request.Cookies["favourite"].Value : null;
        }
    }
}