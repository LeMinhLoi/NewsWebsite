using NewsWebsite.ViewModel.ApiResult;
using NewsWebsite.ViewModel.News;
using NewsWebsite.ViewModel.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Application.News
{
    public interface INewsService
    {
        Task<PagedResult<NewsVM>> GetListNewsPaging(GetListNewsPagingRequest request);
        Task<ApiResultVM<string>> CreateNews(NewsCreateRequest request);
    }
}
