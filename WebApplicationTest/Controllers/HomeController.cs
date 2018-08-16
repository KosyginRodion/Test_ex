using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplicationTest.Models;
using WebApplicationTest.VideoParsers;

namespace WebApplicationTest.Controllers
{

       public class HomeController : Controller
       {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        VideoHostingContext db = new VideoHostingContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VideoSearch(string hosting)
        {
            logger.Info($"Got hosting {hosting}");
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
            logger.Info("Results parsed");
            SaveToDatabase(results);
            logger.Info($"Results saved to DB, count is {results.Count}");
            return View(results);
            }

        private void SaveToDatabase(IEnumerable<VideoHosting> videos)
        {
            db.VideoHostings.AddRange(videos);
            db.SaveChanges();
        }

    }
}