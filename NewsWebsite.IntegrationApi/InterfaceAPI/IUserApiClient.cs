    using NewsWebsite.ViewModel.ApiResult;
using NewsWebsite.ViewModel.Image.ImageUser;
using NewsWebsite.ViewModel.Pagination;
using NewsWebsite.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.IntegrationApi.InterfaceAPI
{
    public interface IUserApiClient
    {
        Task<ApiResultVM<string>> Authenticate(LoginRequest request);

        Task<ApiResultVM<ImageUserVM>> GetImageUserById(Guid id);
        Task<ApiResultVM<PagedResult<UserVM>>> GetUsersPagings(GetUserPagingRequest request);

        Task<ApiResultVM<bool>> RegisterUser(RegisterRequest registerRequest);
        Task<bool> AddBlogger(UserCreateRequest request);

        Task<ApiResultVM<bool>> UpdateUser(Guid id, UserUpdateRequest request);

        Task<ApiResultVM<UserVM>> GetById(Guid id);

        Task<ApiResultVM<bool>> Delete(Guid id);

        Task<bool> UpdateImageUser(ImageUserUpdateRequest request);
        Task<ApiResultVM<string>> ChangePassword(Guid id, string newPassword);

        Task<PagedResult<UserVM>> GetPagings(GetUserPagingRequest request);
    }
}
