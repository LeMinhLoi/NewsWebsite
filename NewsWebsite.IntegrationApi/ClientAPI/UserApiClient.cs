using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NewsWebsite.IntegrationApi.InterfaceAPI;
using NewsWebsite.Utilities.Constants;
using NewsWebsite.ViewModel.ApiResult;
using NewsWebsite.ViewModel.Image.ImageUser;
using NewsWebsite.ViewModel.Pagination;
using NewsWebsite.ViewModel.User;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.IntegrationApi.ClientAPI
{
    public class UserApiClient : BaseApiClient, IUserApiClient 
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {

            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResultVM<string>> Authenticate(LoginRequest request)

        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.BaseAddress = new Uri("https://localhost:5001/api/user/authenticate");

            var response = await client.PostAsync("/api/user/authenticate", httpContent);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResultVM<string>>(await response.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<ApiErrorResultVM<string>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ApiResultVM<bool>> Delete(Guid id)
        {
            //var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            //var client = _httpClientFactory.CreateClient();
            //client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            //var response = await client.DeleteAsync($"/api/user/delete/{id}");
            //var body = await response.Content.ReadAsStringAsync();
            //if (response.IsSuccessStatusCode)
            //    return JsonConvert.DeserializeObject<ApiSuccessResultVM<string>>(body);

            //return JsonConvert.DeserializeObject<ApiErrorResultVM<string>>(body);
            return null;
        }

        public async Task<ApiResultVM<UserVM>> GetById(Guid id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/user/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResultVM<UserVM>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResultVM<UserVM>>(body);
        }

        public Task<ApiResultVM<PagedResult<UserVM>>> GetUsersPagings(GetUserPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResultVM<bool>> RegisterUser(RegisterRequest registerRequest)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> AddBlogger(UserCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var requestContent = new MultipartFormDataContent();
            if (request.ImageUser != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ImageUser.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ImageUser.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ImageUser", request.ImageUser.FileName);
            }
            requestContent.Add(new StringContent(request.FirstName), "FirstName");
            requestContent.Add(new StringContent(request.LastName), "LastName");
            requestContent.Add(new StringContent(request.NickName), "NickName");
            requestContent.Add(new StringContent("Default"), "UserName");
            requestContent.Add(new StringContent(request.DoB.ToString()), "DoB");
            requestContent.Add(new StringContent(request.Phone), "Phone");
            requestContent.Add(new StringContent(request.Email), "Email");
            requestContent.Add(new StringContent(request.Gender.ToString()), "Gender");
            requestContent.Add(new StringContent("Loi!@1234"), "Password");
            requestContent.Add(new StringContent("true"), "IsActive");
            requestContent.Add(new StringContent("3F2BE8B9-769D-49F5-8387-F34413DAA629"), "RoleID");

            var response = await client.PostAsync($"/api/user/create-blogger", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateImageUser(ImageUserUpdateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var requestContent = new MultipartFormDataContent();
            if (request.ImageFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ImageFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ImageFile.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ImageFile", request.ImageFile.FileName);
            }
            requestContent.Add(new StringContent(request.Id.ToString()), "Id");
            var response = await client.PostAsync($"/api/user/image/update", requestContent);
            return response.IsSuccessStatusCode;
        }
        public async Task<ApiResultVM<bool>> UpdateUser(Guid id, UserUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/user/{id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResultVM<bool>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResultVM<bool>>(result);
        }

        public async Task<ApiResultVM<ImageUserVM>> GetImageUserById(Guid id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/user/image/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResultVM<ImageUserVM>>(body);

            return JsonConvert.DeserializeObject<ApiErrorResultVM<ImageUserVM>>(body);
        }
        public async Task<ApiResultVM<string>> ChangePassword(Guid id, string newPassword)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(newPassword);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/user/password/{id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResultVM<string>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResultVM<string>>(result);
        }
        public async Task<PagedResult<UserVM>> GetPagings(GetUserPagingRequest request)
        {
            var roleID  = new Guid("3F2BE8B9-769D-49F5-8387-F34413DAA629");
            var data = await GetAsync<PagedResult<UserVM>>(
                $"/api/user/bloggers/paging?PageIndex={request.PageIndex}" +
                $"&PageSize={request.PageSize}" +
                $"&roleID={roleID}");
            return data;
        }

    }
}
