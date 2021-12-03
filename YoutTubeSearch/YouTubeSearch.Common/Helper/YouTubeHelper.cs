using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace YoutTubeSearch.API.Helpers
{
    public static class YouTubeHelper
    {
        public static async Task<IList<SearchResult>> Search(string name, string type)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyC5_VXAlK0-KnV40-GP9lNx0B1FUk_pXs4"
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = name;

            if (!string.IsNullOrEmpty(type))
            {
                searchListRequest.Type = type;
            }

            var searchListResponse = await searchListRequest.ExecuteAsync();

            return searchListResponse.Items;
        }
    }
}
