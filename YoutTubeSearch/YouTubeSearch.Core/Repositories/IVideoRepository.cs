using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeSearch.Core.Entities;
using YouTubeSearch.Core.Repositories.Base;

namespace YouTubeSearch.Core.Repositories
{
    public interface IVideoRepository : IRepository<Video>
    {
        public List<Video> GetByName(string name);
    }
}
