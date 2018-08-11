using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationTest.Models;

namespace WebApplicationTest.VideoParsers
{
    interface IParser
    {
        List<VideoHosting> Parse(string searchValue);
    }
}
