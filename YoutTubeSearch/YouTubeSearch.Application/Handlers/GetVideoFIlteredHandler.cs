using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeSearch.Application.Mappers;
using YouTubeSearch.Application.Requests;
using YouTubeSearch.Application.Responses;
using YouTubeSearch.Core.Repositories;

namespace YouTubeSearch.Application.Handlers
{
    public interface IGetVideoFilteredHandler
    {
        VideoPaginatedReponse Handle(GetVideoFilteredRequest command);
    }

    public class GetVideoFilteredHandler : IGetVideoFilteredHandler
    {
        IVideoRepository _repository;

        public GetVideoFilteredHandler(IVideoRepository repository)
        {
            _repository = repository;
        }
        public VideoPaginatedReponse Handle(GetVideoFilteredRequest command)
        {
            var videosPaginated = new VideoPaginatedReponse();

            var videos = _repository.GetAllAsync().Result;
            var result = videos.Where(v => v.Name.ToLower().Contains(command.Name));

            videosPaginated.Total = result.Count();
            videosPaginated.Page = command.Page;
            videosPaginated.PageSize = command.PageSize;

            result = result.Skip((command.Page - 1) * command.PageSize).Take(command.PageSize).ToList();

            videosPaginated.Videos = VideoMapper.Mapper.Map<List<VideoResponse>>(result);

            return videosPaginated;
        }
    }
}
