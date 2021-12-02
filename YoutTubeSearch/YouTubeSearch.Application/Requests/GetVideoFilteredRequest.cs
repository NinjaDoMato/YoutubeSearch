using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeSearch.Application.Requests
{
    public class GetVideoFilteredRequest
    {
        public string Name { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
