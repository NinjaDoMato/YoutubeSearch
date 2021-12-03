using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YoutTubeSearch.API.Helpers;
using YouTubeSearch.Application.Mappers;
using YouTubeSearch.Application.Requests;
using YouTubeSearch.Application.Responses;
using YouTubeSearch.Core.Repositories;

namespace YouTubeSearch.Application.Handlers
{
    public class GetSearchResultFIlteredHandler : IRequestHandler<GetSearchResultFilteredRequest, SearchPaginatedReponse>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IChannelRepository _channelRepository;
        public GetSearchResultFIlteredHandler(IVideoRepository videoRepository, IChannelRepository channelRepository)
        {
            _videoRepository = videoRepository;
            _channelRepository = channelRepository;
        }
        public async Task<SearchPaginatedReponse> Handle(GetSearchResultFilteredRequest request, CancellationToken cancellationToken)
        {
            var videosPaginated = new SearchPaginatedReponse();

            // Search for the videos/channels on youtube
            var youtubeResult = await YouTubeHelper.Search(request.Name, request.Type.HasValue ? request.Type.Value.ToString() : string.Empty);

            // Adds the result to the database
            foreach (var search in youtubeResult.Items)
            {
                if (!videosPaginated.Results.Any(s => s.Name == search.Snippet.Title))
                {
                    switch (search.Id.Kind)
                    {
                        case "youtube#video":
                            var video = _videoRepository.GetByName(search.Snippet.Title);

                            if (video == null)
                            {
                                video = await _videoRepository.AddAsync(new Core.Entities.Video
                                {
                                    Name = search.Snippet.Title,
                                    ChannelId = search.Snippet.ChannelId,
                                    DateCreated = DateTime.Now,
                                    Description = search.Snippet.Description,
                                    PublishDate = search.Snippet.PublishedAt.Value,
                                    Thumb = search.Snippet.Thumbnails.Medium.Url,
                                    YoutubeId = search.Id.VideoId
                                });
                            }

                            videosPaginated.Results.Add(new SearchResponse
                            {
                                DateCreated = video.PublishDate,
                                Description = video.Description,
                                Id = video.Id,
                                ImageURL = video.Thumb,
                                LastUpdate = video.LastUpdated,
                                Name = video.Name,
                                YoutubeId = video.YoutubeId,
                                Type = "VIDEO"
                            });

                            break;

                        case "youtube#channel":
                            var channel = _channelRepository.GetByName(search.Snippet.Title);

                            if (channel == null)
                            {
                                channel = await _channelRepository.AddAsync(new Core.Entities.Channel
                                {
                                    Name = search.Snippet.Title,
                                    DateCreated = DateTime.Now,
                                    Description = search.Snippet.Description,
                                    DateUploaded = search.Snippet.PublishedAt.Value,
                                    Thumbnail = search.Snippet.Thumbnails.Medium.Url,
                                    YoutubeId = search.Id.ChannelId,
                                });
                            }

                            videosPaginated.Results.Add(new SearchResponse
                            {
                                DateCreated = channel.DateUploaded,
                                Description = channel.Description,
                                Id = channel.Id,
                                ImageURL = channel.Thumbnail,
                                LastUpdate = channel.LastUpdated,
                                Name = channel.Name,
                                YoutubeId = channel.YoutubeId,
                                Type = "CHANNEL"
                            });

                            break;
                    }
                }

            }

            videosPaginated.Total = videosPaginated.Results.Count();
            videosPaginated.Page = request.Page;
            videosPaginated.PageSize = request.PageSize;

            videosPaginated.Results = videosPaginated.Results.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            return videosPaginated;
        }
    }
}
