using NewsWebsite.ViewModel.ApiResult;
using NewsWebsite.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Application.User.Viewer
{
    public interface IViewerService : IUserService
    {
        Task<ApiResultVM<UserVM>> GetById(Guid id);
    }
}
