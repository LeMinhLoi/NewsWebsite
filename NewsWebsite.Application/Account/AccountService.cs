using Microsoft.AspNetCore.Identity;
using NewsWebsite.Data.Entities;
using NewsWebsite.Utilities.SendEmail;
using NewsWebsite.ViewModel.ApiResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Application.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<UserInfo> _userManager;


        public AccountService(UserManager<UserInfo> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ApiResultVM<string>> SendEmail(string email)
        {
            //var user = await _userManager.FindByEmailAsync(email);
            //if (user == null)
            //    return new ApiErrorResultVM<string>("Không tìm thấy người dùng");

            //var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            //var link = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);

            //EmailHelper emailHelper = new EmailHelper();
            //bool emailResponse = emailHelper.SendEmailPasswordReset(user.Email, link);

            //if (emailResponse)
            //    return RedirectToAction("ForgotPasswordConfirmation");
            //else
            //{
            //    log email failed
            //}
            return new ApiResultVM<string>();
        }
    }
}
