﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeSearch.Application.Responses;

namespace YouTubeSearch.Application.Queries
{
    public class GetAllVideoQuery : IRequest<SearchResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
