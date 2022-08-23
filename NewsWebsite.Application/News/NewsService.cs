using Microsoft.EntityFrameworkCore;
using NewsWebsite.Data.EF;
using NewsWebsite.Data.Entities;
using NewsWebsite.ViewModel.ApiResult;
using NewsWebsite.ViewModel.News;
using NewsWebsite.ViewModel.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebsite.Application.News
{
    public class NewsService : INewsService
    {
        private readonly WebsiteDBContext _websiteDBContext;
        public NewsService(WebsiteDBContext websiteDBContext)
        {
            _websiteDBContext = websiteDBContext;
        }

        public async Task<ApiResultVM<string>> CreateNews(NewsCreateRequest request)
        {
            try
            {
                var valueGuid = Guid.NewGuid();
                var news = new NewsWebsite.Data.Entities.News()
                {
                    IdAuthor = request.IdAuthor,
                    Content = request.Content,
                    SrcCoverImage = request.SrcCoverImage,
                    Tittle = request.Tittle,
                    DateCreate = DateTime.Now,
                    IdNews = valueGuid,
                    ViewCount = 0,
                    IsAccept = false,
                };
                var list = new List<NewsInCatalog>();
                foreach (int item in request.Catalogs)
                {
                    list.Add(new NewsInCatalog()
                    {
                        IdNews = valueGuid,
                        IdCatalog = item
                    });
                }
                await _websiteDBContext.Newss.AddAsync(news);
                await _websiteDBContext.NewsInCatalogs.AddRangeAsync(list);
                await _websiteDBContext.SaveChangesAsync();
                return new ApiSuccessResultVM<string>();
            }
            catch (Exception e)
            {
                var ex = e;
                return new ApiErrorResultVM<string>("Lỗi");
            }
            
        }

        public async Task<PagedResult<NewsVM>> GetListNewsPaging(GetListNewsPagingRequest request)
        {
            ////1.Select join
            //var query = from news in _websiteDBContext.Newss
            //            join nic in _websiteDBContext.NewsInCatalogs on news.IdNews equals nic.IdNews
            //            join c in _websiteDBContext.Catalogs on nic.IdCatalog equals c.IdCatalog
            //            join user in _websiteDBContext.UserInfos on news.IdAuthor equals user.Id
            //            where c.IdCatalog == request.CatalogID
            //            select new { news, c, user };
            ////2. Filter
            //if (request.CatalogID != 0)
            //{
            //    query = query.Where(p => p.c.IdCatalog == request.CatalogID);
            //}
            ////3. Paging
            //int totalRow = await query.CountAsync();
            //var data = await query.OrderByDescending(x => x.news.DateCreate).Skip((request.PageIndex - 1) * request.PageSize)
            //    .Take(request.PageSize)
            //    .Select()
            throw new NotImplementedException();
        }
    }
}
