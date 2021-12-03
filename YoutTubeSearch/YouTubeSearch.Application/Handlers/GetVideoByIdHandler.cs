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
    public interface IGetVideoByIdHandler
    {
        SearchResponse Handle(GetVideoByIdRequest command);
    }

    public class GetVideoByIdHandler : IGetVideoByIdHandler
    {
        IVideoRepository _repository;

        public GetVideoByIdHandler(IVideoRepository repository)
        {
            _repository = repository;
        }
        public SearchResponse Handle(GetVideoByIdRequest command)
        {
            var video = _repository.GetByIdAsync(command.Id).Result;

            return VideoMapper.Mapper.Map<SearchResponse>(video);
        }
    }
}
