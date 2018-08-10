using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplicationTest.Models
{
    public class VideoHostingContext : DbContext
    {
        public DbSet<VideoHosting> VideoHostings { get; set; }
    }
}