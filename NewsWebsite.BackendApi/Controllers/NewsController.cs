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
        public IActionResult CreateNews([FromBody] NewsCreateRequest request)
        {
            var result = _newsService.CreateNews(request);
            return Ok();
        }
    }
}
