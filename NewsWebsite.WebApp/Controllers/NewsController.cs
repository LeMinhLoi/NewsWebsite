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
        public async Task<IActionResult> CreateNewsView()
        {
            Guid id = new Guid(HttpContext.Session.GetString("UserID"));
            ViewData["UserID"] = id;
            var allCatalog = await _catalogApiClient.GetAll();
            ViewData["ListCatalog"] = allCatalog;
            return View();
        }

        [HttpPost("news/create")]
        public async Task<IActionResult> CreateNewsAsync(NewsCreateRequest request)
        {
            var result = await _newsApiClient.CreateNews(request);
            return new OkObjectResult(result);
        }
        [HttpGet("news/get")]
        public async Task<IActionResult> GetListNews(GetListNewsPagingRequest request)
        {
            var response = await _newsApiClient.GetListNewsPaging(request);
            return new OkObjectResult(response);
        }
        [HttpGet("/news/list-news")]
        public IActionResult ListNewsView()
        {
            return View();
        }
    }
}
