using NewsWebsite.ViewModel.ApiResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.IntegrationApi.InterfaceAPI
{
    public interface IAccountApiClient
    {
        Task<ApiResultVM<string>> SendEmailConfirm(string EmailConfirm);
    }
}
