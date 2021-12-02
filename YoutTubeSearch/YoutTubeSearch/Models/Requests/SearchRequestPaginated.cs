using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoutTubeSearch.API.Models.Requests
{
    public class SearchRequestPaginated : PaginatedRequest
    {
        public string Name { get; set; }
    }
}
