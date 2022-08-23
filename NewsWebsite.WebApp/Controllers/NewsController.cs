using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsWebsite.IntegrationApi.InterfaceAPI;
using NewsWebsite.ViewModel.News;

namespace NewsWebsite.WebApp.Controllers
{
    public class NewsController : BaseController
    {
        private readonly ICatalogApiClient _catalogApiClient;
        private readonly INewsApiClient _newsApiClient;
        public NewsController(ICatalogApiClient catalogApiClient, INewsApiClient newsApiClient)
        {
            _catalogApiClient = catalogApiClient;
            _newsApiClient = newsApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/news/create-news")]
        public async Task<IActionResult> CreateNewsAsync()
        {
            Guid id = new Guid(HttpContext.Session.GetString("UserID"));
            ViewData["UserID"] = id;
            var a = await _catalogApiClient.GetAll();
            ViewData["ListCatalog"] = a;
            return View();
        }

        [HttpPost("news/create")]
        public IActionResult CreateNews(NewsCreateRequest request)
        {
            var result = _newsApiClient.CreateNews(request);
            return Ok();
        }
    }
}
