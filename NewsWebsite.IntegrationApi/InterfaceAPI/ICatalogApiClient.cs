using NewsWebsite.ViewModel.ApiResult;
using NewsWebsite.ViewModel.Catalog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.IntegrationApi.InterfaceAPI
{
    public interface ICatalogApiClient
    {
        public Task<CatalogVM> GetById(int id);
        Task<List<CatalogVM>> GetAll();
        Task<ApiResultVM<string>> UpdateCatalog(GetRequestUpdateCatalog request);
        Task<bool> Delete(int id);
        Task<List<CatalogVM>> Search(string keyword);
    }
}
