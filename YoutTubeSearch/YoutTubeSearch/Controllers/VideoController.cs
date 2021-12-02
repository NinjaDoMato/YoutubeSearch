using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutTubeSearch.API.Helpers;
using YoutTubeSearch.API.Models.Requests;
using YoutTubeSearch.Controllers;
using YouTubeSearch.Application.Requests;
using YouTubeSearch.Application.Responses;
using YouTubeSearch.Core.Entities;

namespace YoutTubeSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VideoController : BaseController
    {
        private readonly IMediator _mediator;
        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var result = await _mediator.Send(new GetVideoByIdRequest());

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                return BadRequest(new { Message = msg });
            }
        }

    }
}
