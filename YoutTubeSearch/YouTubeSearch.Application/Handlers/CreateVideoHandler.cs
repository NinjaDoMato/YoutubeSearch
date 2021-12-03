using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YouTubeSearch.Application.Commands;
using YouTubeSearch.Application.Mappers;
using YouTubeSearch.Application.Responses;
using YouTubeSearch.Core.Entities;
using YouTubeSearch.Core.Repositories;

namespace YouTubeSearch.Application.Handlers
{
    public class CreateVideoHandler : IRequestHandler<CreateVideoCommand, SearchResponse>
    {
        private readonly IVideoRepository _videoRepository;
        public CreateVideoHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public async Task<SearchResponse> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
        {
            var videoEntity = VideoMapper.Mapper.Map<Video>(request);
            if (videoEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newVideo = await _videoRepository.AddAsync(videoEntity);
            var videoResponse = VideoMapper.Mapper.Map<SearchResponse>(newVideo);
            return videoResponse;
        }
    }
}
