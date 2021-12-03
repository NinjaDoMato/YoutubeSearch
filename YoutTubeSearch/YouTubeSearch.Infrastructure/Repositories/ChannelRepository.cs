using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeSearch.Core.Entities;
using YouTubeSearch.Core.Repositories;
using YouTubeSearch.Infrastructure;
using YouTubeSearch.Infrastructure.Repositories.Base;

namespace YouTubeSearch.Infrastructure.Repositories
{
    public class ChannelRepository : Repository<Channel>, IChannelRepository
    {
        public ChannelRepository(DatabaseContext videoContext) : base(videoContext) { }

        public Channel GetByName(string name)
        {
            return _context.Channel.FirstOrDefault(v => v.Name == name);
        }
    }
}
