using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NewsWebsite.IntegrationApi.InterfaceAPI;
using NewsWebsite.ViewModel.ApiResult;
using NewsWebsite.ViewModel.News;
using NewsWebsite.ViewModel.Pagination;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.IntegrationApi.ClientAPI
{
    public class NewsApiClient : BaseApiClient, INewsApiClient 
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NewsApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {

            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ApiResultVM<string>> CreateNews(NewsCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/news/create", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResultVM<string>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResultVM<string>>(result);
        }

        public async Task<PagedResult<NewsVM>> GetListNewsPaging(GetListNewsPagingRequest request)
        {
            var data = await GetAsync<PagedResult<NewsVM>>(
                $"/api/news/get-list-news?PageIndex={request.PageIndex}" +
                $"&PageSize={request.PageSize}");
            return data;
        }

    }
}
