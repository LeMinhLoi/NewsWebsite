using NewsWebsite.Data.EF;
using NewsWebsite.ViewModel.Catalog;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NewsWebsite.Application.Catalog
{
    public class CatalogService : ICatalogService
    {
        private readonly WebsiteDBContext _context;
        public CatalogService(WebsiteDBContext context)
        {
            _context = context;
        }
        public async Task<List<CatalogVM>> GetAll()
        {
            var query = from c in _context.Catalogs
                        select new CatalogVM
                        { Id = c.IdCatalog, Name = c.Name, Description = c.Description };
            return await query.ToListAsync();
        }

        public Task<CatalogVM> GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
