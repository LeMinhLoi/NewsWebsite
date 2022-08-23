using Microsoft.AspNetCore.Mvc;
using NewsWebsite.IntegrationApi.InterfaceAPI;
using NewsWebsite.ViewModel.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebsite.WebApp.Controllers
{
    public class CatalogController : BaseController
    {
        private readonly ICatalogApiClient _catalogApiClient;
        public CatalogController(ICatalogApiClient catalogApiClient)
        {
            _catalogApiClient = catalogApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("catalog/all")]
        public async Task<IActionResult> GetAll()
        {
            var listCatalog = await _catalogApiClient.GetAll();
            return new OkObjectResult(listCatalog);
        }
        [HttpGet("catalog/id")]
        public async Task<IActionResult> GetById(int id)
        {
            var catalog = await _catalogApiClient.GetById(id);
            return new OkObjectResult(catalog);
        }

        [Route("/all-catalogs")]
        public IActionResult Catalogs() //view list catalog
        { 
            return View();
        }
        [HttpPost("catalog/update")]
        public async Task<IActionResult> UpdateAsync(GetRequestUpdateCatalog request) //view list catalog
        {
            var result = await _catalogApiClient.UpdateCatalog(request);
            return new OkObjectResult(result);
        }

        [HttpGet("catalog/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _catalogApiClient.Delete(id);
            return RedirectToAction("Catalogs");
        }

        [HttpGet("catalog/search")]
        public async Task<IActionResult> Search(string Keyword = "")
        {
            var data = await _catalogApiClient.Search(Keyword);
            return new OkObjectResult(data);
        }
    }
}
