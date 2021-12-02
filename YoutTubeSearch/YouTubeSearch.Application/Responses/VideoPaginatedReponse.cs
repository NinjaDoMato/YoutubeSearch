using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeSearch.Application.Responses
{
    public class VideoPaginatedReponse
    {
        public List<VideoResponse> Videos { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }

        public VideoPaginatedReponse()
        {
            Videos = new List<VideoResponse>();
        }
    }
}
