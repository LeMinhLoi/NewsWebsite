using NewsWebsite.ViewModel.ApiResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Application.Account
{
    public interface IAccountService
    {
        Task<ApiResultVM<string>> SendEmail(string Email);
    }
}
