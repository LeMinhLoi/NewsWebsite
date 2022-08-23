using NewsWebsite.ViewModel.ApiResult;
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
        Task<ApiResultVM<string>> UpdateCatalog(GetRequestUpdateCatalog request);
        Task<bool> Delete(int id);
        Task<List<CatalogVM>> SearchByKeyword(string keyword);
    }
}
