using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.IntegrationApi.InterfaceAPI
{
    public interface IBaseApiClient
    {
        Task<TResponse> GetAsync<TResponse>(string url);

        Task<List<T>> GetListAsync<T>(string url, bool requiredLogin = false);
        
        public Task<bool> Delete(string url);
    }
}
