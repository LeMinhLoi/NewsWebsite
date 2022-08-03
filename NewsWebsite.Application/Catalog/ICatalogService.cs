using NewsWebsite.ViewModel.Catalog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Application.Catalog
{
    public interface ICatalogService
    {
        Task<List<CatalogVM>> GetAll();
        Task<CatalogVM> GetByID(int id);
    }
}
