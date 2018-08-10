using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationTest.Models
{
    public class VideoHosting
    {
        public int Id { get; set; }
        public string NameVideo { get; set; }
        public string NameHosting { get; set; }
        public DateTime Time { get; set; }
    }
}