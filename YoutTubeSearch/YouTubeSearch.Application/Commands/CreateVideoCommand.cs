using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeSearch.Application.Responses;

namespace YouTubeSearch.Application.Commands
{
    public class CreateVideoCommand : IRequest<VideoResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
