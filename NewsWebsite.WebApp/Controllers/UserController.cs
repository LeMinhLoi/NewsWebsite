using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NewsWebsite.IntegrationApi.InterfaceAPI;
using NewsWebsite.Utilities.CreatePathImage;
using NewsWebsite.ViewModel.Image.ImageUser;
using NewsWebsite.ViewModel.PasswordVM;
using NewsWebsite.ViewModel.User;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NewsWebsite.WebApp.Controllers
{
    public class UserController : BaseController
    {

        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;

        public UserController(IUserApiClient userApiClient,
            IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        //function log out
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); //delete old cookie
            HttpContext.Session.Remove("Token");//delete session, which contain JWT protect api
            HttpContext.Session.Remove("UserID");
            return RedirectToAction("Index", "Login");//redirect to login page
        }


        //function get detail info of user, need ID
        [HttpGet("detail/info/{id}")]
        public async Task<IActionResult> DetailsUser(Guid id)
        {
            var result = await _userApiClient.GetById(id); //call api
            ViewData["UserID"] = result.ResultObj.Id;
            return View(result.ResultObj);
        }


        //function get detail info myself, myID was saved in IdentityClaims
        [HttpGet("detail/info/myself")]
        public async Task<IActionResult> DetailsUser()
        {
            Guid id = new Guid(HttpContext.Session.GetString("UserID")); //get ID
            var result = await _userApiClient.GetById(id); //call api
            ViewData["UserID"] = result.ResultObj.Id;
            return View(result.ResultObj);
        }

        //function update info of user
        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateRequest request) //object include ID
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Home");

            var result = await _userApiClient.UpdateUser(request.Id, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật người dùng thành công";
                return RedirectToAction("DetailsUser","User", new { id = request.Id}); //redirect to page detail info
            }

            ModelState.AddModelError("", result.Message);
            return RedirectToAction("Index", "Home");
        }

        //fuction get Image of user via ID User and display
        [HttpGet("image/{UserID}")]
        public async Task<IActionResult> GetImageUser(Guid UserID)
        {
            //Guid id = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var apiResult = await _userApiClient.GetImageUserById(UserID);//apiResult<ImageUserVM>
            if (apiResult.IsSuccessed)
            {
                String pathImage = "https://localhost:5001/" + CreatePathImage.PathImage(apiResult.ResultObj.ImagePath);
                ViewData["path"] = pathImage;
            }
            ViewData["UserID"] = UserID;
            return View();
        }

        //function change/update image
        [HttpPost("update/image")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateImageUser(ImageUserUpdateRequest request)
        {

            var result = await _userApiClient.UpdateImageUser(request);
            if(result == true)
            {
                return Redirect("image/" + request.Id.ToString());
            }
            return Redirect("index");
        }


        //redirect to view change password of user
        [Route("update/password/{UserID}")]
        public IActionResult ChangePassword(Guid UserID)
        {
            ViewData["UserID"] = UserID;
            return View();
        }

        //change password
        //[HttpPost("change-password/{UserID}")]
        //public async Task<IActionResult> ChangePassword(string newPassword, string confirmPassword)
        //{
        //    var result = await _userApiClient.ChangePassword(id, newPassword);
        //    if (result.IsSuccessed)
        //    {
        //        return RedirectToAction("DetailsMyself");

        //    }
        //    return RedirectToAction("Index", "Home");
        //}
        //[HttpPost("change-password")]
        //public async Task<IActionResult> ChangePassword(string newPassword, string confirmPassword)
        //{
        //    var result = await _userApiClient.ChangePassword(id, newPassword);
        //    if(result.IsSuccessed)
        //    {
        //        return RedirectToAction("DetailsMyself");

        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        [HttpGet("bloggers")]
        public async Task<IActionResult> ListBlogger()
        {
            var request = new GetUserPagingRequest()
            {
                PageIndex = 1,
                PageSize = 10
            };
            var data = await _userApiClient.GetPagings(request);
            return View(data);
        }

        [HttpGet("delete/{UserID}")]
         public IActionResult Delete(Guid UserID)
        {
            return null;

        }

        [Route("/view/add-blogger")]
        public IActionResult ViewAddBlogger()
        {
            return View();
        }

        [HttpPost()]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddBloggerAsync(UserCreateRequest request)
        {
            var result = await _userApiClient.AddBlogger(request);
            if(result == true)
            {
                return RedirectToAction("ListBlogger");
            }
            return RedirectToAction("ViewAddBlogger");
        }
    }
}
