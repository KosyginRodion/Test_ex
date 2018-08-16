using System;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using WebApplicationTest.Models;

namespace WebApplicationTest.VideoParsers
{
    public class YoutubeParser : ParserBase
    {
        public override List<VideoHosting> Parse()
        
        {

            var youtubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApplicationName = "Youtube parser",
                ApiKey = "AIzaSyCtrxWvxLLF33phNIi6TTWjekgG9NiLpsw",
            });

            int maxResults = 20;

            SearchResource.ListRequest searchListByKeywordRequest = youtubeService.Search.List("snippet");
            searchListByKeywordRequest.MaxResults = maxResults;
            searchListByKeywordRequest.Q = GetUrlLink();
            searchListByKeywordRequest.Type = "video";
            searchListByKeywordRequest.RelevanceLanguage = "ru";
            
            SearchListResponse response = searchListByKeywordRequest.Execute();

            var result = response.Items.Select(t =>
                new VideoHosting
                {
                    NameVideo = t.Snippet.Title,
                    NameHosting = HostNames.Youtube,
                    Time = DateTime.Now
                }).ToList();
            return result;
        }

        protected override string GetUrlLink()
        {
            return $"https://www.youtube.com/results?search_query={HostNames.request}";
        }
    }
}