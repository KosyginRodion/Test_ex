using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationTest.Models;

namespace WebApplicationTest.Controllers
{

       public class HomeController : Controller
   {
        VideoHostingContext db = new VideoHostingContext();

        public ActionResult Index()
        {
            // получаем из БД все объекты VideoHosting
            IEnumerable<VideoHosting> VideoHostings = db.VideoHostings;
            // возвращаем представление
            return View(VideoHostings);
        }
    }
}