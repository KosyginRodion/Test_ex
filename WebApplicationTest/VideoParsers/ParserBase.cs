using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationTest.Models;

namespace WebApplicationTest.VideoParsers
{
    public abstract class ParserBase : IParser
    {
        public abstract List<VideoHosting> Parse();

        protected abstract string GetUrlLink();
    }
}