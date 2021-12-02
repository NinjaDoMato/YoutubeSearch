using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeSearch.Application.Responses;

namespace YouTubeSearch.Application.Requests
{
    public class GetVideoFilteredRequest : IRequest<VideoPaginatedReponse>
    {
        public string Name { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
