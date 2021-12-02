using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YouTubeSearch.Application.Mappers;
using YouTubeSearch.Application.Requests;
using YouTubeSearch.Application.Responses;
using YouTubeSearch.Core.Repositories;

namespace YouTubeSearch.Application.Handlers
{
    public class GetVideoFilteredHandler : IRequestHandler<GetVideoFilteredRequest, VideoPaginatedReponse>
    {
        private readonly IVideoRepository _repository;
        public GetVideoFilteredHandler(IVideoRepository videoRepository)
        {
            _repository = videoRepository;
        }
        public async Task<VideoPaginatedReponse> Handle(GetVideoFilteredRequest request, CancellationToken cancellationToken)
        {



            var videosPaginated = new VideoPaginatedReponse();

            var videos = _repository.GetAllAsync().Result;
            var result = videos.Where(v => v.Name.ToLower().Contains(request.Name));

            videosPaginated.Total = result.Count();
            videosPaginated.Page = request.Page;
            videosPaginated.PageSize = request.PageSize;

            result = result.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            videosPaginated.Videos = VideoMapper.Mapper.Map<List<VideoResponse>>(result);

            return videosPaginated;
        }
    }
}
