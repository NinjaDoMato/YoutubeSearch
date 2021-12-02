using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutTubeSearch.API.Models.Requests;

namespace YoutTubeSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : BaseController
    {
        [HttpGet]
        [Route("Get/")]
        public async Task<IActionResult> Get([FromQuery] SearchRequestPaginated filter)
        {
            try
            {
                //YouTubeHelper.SearchVideos("Jovem Nerd");
                var result = await _mediator.Send(new GetVideoFilteredRequest { Name = filter.Name, PageSize = filter.PageSize, Page = filter.Page});

                return Ok();
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                return BadRequest(new { Message = msg });
            }
        }
    }
}
