using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NewsWebsite.IntegrationApi.InterfaceAPI;
using NewsWebsite.ViewModel.ApiResult;
using NewsWebsite.ViewModel.Catalog;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.IntegrationApi.ClientAPI
{
    public class CatalogApiClient : BaseApiClient, ICatalogApiClient 
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CatalogApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {

            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> Delete(int id)
        {
            return await Delete($"/api/catalog/delete/{id}");
        }

        public async Task<List<CatalogVM>> GetAll()
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/catalog/all/");
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CatalogVM>>(body);
        }

        public async Task<CatalogVM> GetById(int id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/catalog/{id}");
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CatalogVM>(body);
        }

        public async Task<List<CatalogVM>> Search(string keyword)
        {
            var data = await GetAsync<List<CatalogVM>>($"/api/catalog/search?Keyword={keyword}");
            return data;
        }

        public async Task<ApiResultVM<string>> UpdateCatalog(GetRequestUpdateCatalog request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PostAsync("/api/catalog/update", httpContent);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResultVM<string>>(await response.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<ApiErrorResultVM<string>>(await response.Content.ReadAsStringAsync());
        }
    }
}
