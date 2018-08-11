using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplicationTest.Models
{
    public class VideoHostingDbInitializer : DropCreateDatabaseAlways<VideoHostingContext>
    {
        protected override void Seed(VideoHostingContext db)
        {
            //db.VideoHostings.Add(new VideoHosting { NameVideo = "Первое", NameHosting = HostNames.Yandex, Time = new DateTime(2018, 8, 10, 00, 00, 01) });
            //db.VideoHostings.Add(new VideoHosting { NameVideo = "Второе", NameHosting = HostNames.Youtube, Time = new DateTime(2018, 8, 10, 12, 34, 56) });
            //db.VideoHostings.Add(new VideoHosting { NameVideo = "Третье", NameHosting = HostNames.Yandex, Time = new DateTime(2018, 8, 10, 23, 59, 59) });

            base.Seed(db);
        }
    }
}