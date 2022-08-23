using NewsWebsite.ViewModel.ApiResult;
using NewsWebsite.ViewModel.Image.ImageUser;
using NewsWebsite.ViewModel.Pagination;
using NewsWebsite.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Application.User
{
    public interface IUserService // T is viewmodel among of: manager, blogger or viewer
    {
        Task<ApiResultVM<string>> Authencate(LoginRequest request);
        Task<ApiResultVM<bool>> Register(RegisterRequest request);


        Task<ApiResultVM<bool>> UpdateInfo(Guid id, UserUpdateRequest request);
        Task<ApiResultVM<string>> UpdateImage(ImageUserUpdateRequest request);
        Task<ApiResultVM<string>> UpdatePassword(Guid id, string password);


        Task<ApiResultVM<string>> AddUser(UserCreateRequest request);


        Task<ApiResultVM<string>> Delete(Guid id);
        Task<ApiResultVM<string>> CheckExistEmailAndPhone(string email, string phone);

        Task<ApiResultVM<UserVM>> GetById(Guid id);
        Task<ApiResultVM<ImageUserVM>> GetImageUserById(Guid id);
        Task<PagedResult<UserVM>> GetUserPagingByRole(GetUserPagingRequest request, Guid idRole);

    }
}
