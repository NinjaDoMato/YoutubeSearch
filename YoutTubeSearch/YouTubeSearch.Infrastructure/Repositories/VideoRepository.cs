using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeSearch.Core.Entities;
using YouTubeSearch.Core.Repositories;
using YouTubeSearch.Infrastructure.Data;
using YouTubeSearch.Infrastructure.Repositories.Base;

namespace YouTubeSearch.Infrastructure.Repositories
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository(DatabaseContext videoContext) : base(videoContext) { }
    }
}
