using NewsWebsite.ViewModel.ApiResult;
using NewsWebsite.ViewModel.News;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.IntegrationApi.InterfaceAPI
{
    public interface INewsApiClient
    {
        Task<ApiResultVM<string>> CreateNews(NewsCreateRequest request);
    }
}
