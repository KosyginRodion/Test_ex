using AngleSharp.Dom.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using WebApplicationTest.Models;

namespace WebApplicationTest.VideoParsers
{
    public class YandexParser : ParserBase
    {
        private string ExcludeTagB(string value)
        {
            byte[] bytes = Encoding.Default.GetBytes(value);
            value = Encoding.UTF8.GetString(bytes);
            var regex = new Regex("(.*)<b>(.*)</b>(.*)");
            var matchGroups = regex.Match(value).Groups;
            return matchGroups[1].Value + matchGroups[2].Value + matchGroups[3].Value;

        }

        public override List<VideoHosting> Parse(string searchValue)
        {
            var parser = new AngleSharp.Parser.Html.HtmlParser();
            string htmlSourse;
            using (WebClient client = new WebClient())
            {
                htmlSourse = client.DownloadString(GetUrlLink(searchValue));
            }

            IHtmlDocument document = parser.Parse(htmlSourse);
            var h2s = document
                .GetElementsByTagName("h2");
            var result = document
                .GetElementsByTagName("h2") // Получили массив тэгов h2
                .Where(t => t.ClassList.Contains("serp-item__title")) // Отфильтровали те, которые содержат класс serp-item__title
                .Select(t => new VideoHosting // Преобразовали результаты в нужный вид
                {
                    NameVideo = ExcludeTagB(t.InnerHtml),
                    NameHosting = HostNames.Yandex,
                    Time = DateTime.Now
                })
                .ToList(); // Преобразовали к типу "Список"

            return result;
        }

        protected override string GetUrlLink(string searchValue)
        {
            return $"https://yandex.ru/video/search?text={searchValue}&path=main";
        }
    }
}