using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsWebsite.Application.News;
using NewsWebsite.ViewModel.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebsite.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateNewsAsync([FromBody] NewsCreateRequest request)
        {
            var result = await _newsService.CreateNews(request);
            return Ok(result);
        }
        [HttpGet("get-list-news")]
        public async Task<IActionResult> GetNewsAsync([FromQuery] GetListNewsPagingRequest request)
        {
            var result = await _newsService.GetListNewsPaging(request);
            return Ok(result);
        }
    }
}
