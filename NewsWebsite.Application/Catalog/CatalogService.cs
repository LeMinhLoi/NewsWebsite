using NewsWebsite.Data.EF;
using NewsWebsite.ViewModel.Catalog;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsWebsite.ViewModel.ApiResult;
using System;
namespace NewsWebsite.Application.Catalog
{
    public class CatalogService : ICatalogService
    {
        private readonly WebsiteDBContext _context;
        public CatalogService(WebsiteDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var catalog = await _context.Catalogs.FirstOrDefaultAsync(a => a.IdCatalog == id);
            if (catalog == null)
            {
                return false;
            }
            try
            {
                _context.Catalogs.Remove(catalog);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<CatalogVM>> GetAll()
        {
            var query = from c in _context.Catalogs
                        select new CatalogVM
                        { Id = c.IdCatalog, Name = c.Name, Description = c.Description };
            return await query.ToListAsync();
        }

        public async Task<CatalogVM> GetByID(int id)
        {
            var catalog = await _context.Catalogs.FindAsync(id);
            var catalogVM = new CatalogVM() 
            {
                Id = catalog.IdCatalog,
                Name = catalog.Name,
                Description = catalog.Description
            };
            return catalogVM;
        }

        public async Task<List<CatalogVM>> SearchByKeyword(string keyword)
        {
            var query = from catalog in _context.Catalogs
                        where catalog.Description.Contains(keyword) || catalog.Name.Contains(keyword)
                        select catalog;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            var data = await query
                .Select(x => new CatalogVM()
                {
                    Id = x.IdCatalog,
                    Name = x.Name,
                    Description = x.Description,
                }).ToListAsync();
            return data;
        }

        public async Task<ApiResultVM<string>> UpdateCatalog(GetRequestUpdateCatalog request)
        {
            if(request.Id != 0)
            {
                var catalog = await _context.Catalogs.FindAsync(request.Id);
                if (catalog == null)
                {
                    return new ApiErrorResultVM<string>("Không tìm thấy danh mục");
                }
                catalog.Name = request.Name;
                catalog.Description = request.Description;
                try
                {
                    await _context.SaveChangesAsync();
                    return new ApiSuccessResultVM<string>();
                }
                catch (Exception)
                {
                    return new ApiErrorResultVM<string>("Lỗi");
                }
            }
            else
            {
                
                var catalog = new NewsWebsite.Data.Entities.Catalog()
                {
                    Name = request.Name,
                    Description = request.Description
                };
                await _context.Catalogs.AddAsync(catalog);
                await _context.SaveChangesAsync();
                return new ApiSuccessResultVM<string>();
            }
        }

    }
}
