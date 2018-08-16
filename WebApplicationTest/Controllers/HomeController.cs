using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplicationTest.Models;
using WebApplicationTest.VideoParsers;

namespace WebApplicationTest.Controllers
{

       public class HomeController : Controller
       {
        VideoHostingContext db = new VideoHostingContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VideoSearch(string hosting)
        {
            IParser parser;
            switch (hosting)
            {
                case HostNames.Yandex:
                    parser = new YandexParser();
                    break;
                case HostNames.Youtube:
                    parser = new YoutubeParser();
                    break;
                default:
                    throw new NotImplementedException();
            }

            var results = parser.Parse();
            SaveToDatabase(results);
            
            return View(results);
        }

        private void SaveToDatabase(IEnumerable<VideoHosting> videos)
        {
            db.VideoHostings.AddRange(videos);
            db.SaveChanges();
        }

    }
}