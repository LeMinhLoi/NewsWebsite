using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsWebsite.Application.Catalog;
using NewsWebsite.ViewModel.Catalog;
using System.Threading.Tasks;

namespace NewsWebsite.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CatalogController : ControllerBase
    {

        private readonly ICatalogService _catalogService;
        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var catalog = await _catalogService.GetByID(id);
            return Ok(catalog);
        }
        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync()
        {
            var catalogs = await _catalogService.GetAll();
            return Ok(catalogs);
        }
        [HttpPost("update")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateCatalog([FromBody] GetRequestUpdateCatalog request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _catalogService.UpdateCatalog(request);
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _catalogService.Delete(id);
            return Ok(result);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchByKeyword([FromQuery] string Keyword)
        {
            var catalogs = await _catalogService.SearchByKeyword(Keyword);
            return Ok(catalogs);
        }
    }
}
