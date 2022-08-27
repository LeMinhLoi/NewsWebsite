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
            //1.Select join
            var query = from news in _websiteDBContext.Newss
                        join user in _websiteDBContext.UserInfos on news.IdAuthor equals user.Id
                        select new { news, user };

            //2. Paging
            int totalRow = await query.CountAsync();
            var data = await query.OrderByDescending(x => x.news.DateCreate).Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new NewsVM()
                {
                    IdNews = x.news.IdNews,
                    DateCreate = x.news.DateCreate,
                    NameAuthor = x.user.LastName + " " + x.user.FirstName,
                    Title = x.news.Tittle,
                    Catalogs = (from ca in _websiteDBContext.Catalogs
                                join k in _websiteDBContext.NewsInCatalogs on ca.IdCatalog equals k.IdCatalog
                                where k.IdNews == x.news.IdNews
                                select ca.Name).ToList(),
                }).ToListAsync();
            //var data = await (from news in _websiteDBContext.Newss
            //            join user in _websiteDBContext.UserInfos on news.IdAuthor equals user.Id
            //            join newscatalog in _websiteDBContext.NewsInCatalogs on news.IdNews equals newscatalog.IdNews
            //            join catalog in _websiteDBContext.Catalogs on newscatalog.IdCatalog equals catalog.IdCatalog
            //            group catalog by new { news.IdNews, news.DateCreate, user.LastName, user.FirstName, news.Tittle } into g
            //            select new NewsVM()
            //            {
            //                IdNews = g.Key.IdNews,
            //                DateCreate = g.Key.DateCreate,
            //                NameAuthor = "",
            //                Title = g.Select(x=>x.Name).Count().ToString(),
            //                Catalogs = null
            //            }).ToListAsync();

            //3. Select and projection
            var pagedResult = new PagedResult<NewsVM>()
            {
                TotalRecords = data.Count(),
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
    }
}
