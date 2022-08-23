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

        //function get detail info myself, myID was saved in IdentityClaims
        [HttpGet("edit/myself")]
        public async Task<IActionResult> EditUser()
        {
            Guid id = new Guid(HttpContext.Session.GetString("UserID")); //get ID
            var result = await _userApiClient.GetById(id); //call api
            if (result.ResultObj.PathImageAvatar != null)
            {
                result.ResultObj.PathImageAvatar = _configuration["BaseAddress"] + CreatePathImage.PathImage(result.ResultObj.PathImageAvatar);
            }
            return View(result.ResultObj);
        }
        //function get detail info of user, need ID
        [HttpGet("edit/info/{id}")]
        public async Task<IActionResult> EditUser(Guid id)
        {
            var result = await _userApiClient.GetById(id); //call api
            if(result.ResultObj.PathImageAvatar != null)
            {
                result.ResultObj.PathImageAvatar = _configuration["BaseAddress"] + CreatePathImage.PathImage(result.ResultObj.PathImageAvatar);
            }
            return View(result.ResultObj);
        }

        public async Task<IActionResult> GetUserById(Guid id)
        {
            var result = await _userApiClient.GetById(id); //call api
            return new OkObjectResult(result.ResultObj);
        }



        //function update info of user
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit(UserUpdateRequest request) //object include ID
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Home");
            var result = await _userApiClient.UpdateUser(request.Id, request);
            if (result.IsSuccessed)
            {
                return RedirectToAction("ListBlogger", "User"); //redirect to page detail info
            }
            return BadRequest(result);
        }

        //fuction get Image of user via ID User and display
        [HttpGet("image/{UserID}")]
        public async Task<IActionResult> GetImageUser(Guid UserID)
        {
            //Guid id = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var apiResult = await _userApiClient.GetImageUserById(UserID);//apiResult<ImageUserVM>
            if (apiResult.IsSuccessed)
            {
                String pathImage = _configuration["BaseAddress"] + CreatePathImage.PathImage(apiResult.ResultObj.ImagePath);
                ViewData["path"] = pathImage;
            }
            ViewData["UserID"] = UserID;
            return View();
        }

        //function change/update image
        [HttpPost()]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateImageAsync(ImageUserUpdateRequest request)
        {

            var result = await _userApiClient.UpdateImageUser(request);
            if(result == true)
            {
                return RedirectToAction("GetImageUser", "User", new { UserID = request.Id });
            }
            return RedirectToAction("DetailsUser", "User", new { id = request.Id });
        }


        //redirect to view change password of user
        [Route("update/password/{UserID}")]
        public IActionResult ChangePassword(Guid UserID)
        {
            ViewData["UserID"] = UserID;
            return View();
        }

        //change password
        [HttpPost("change-password")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ChangePasswordUser(PasswordVM request)
        {
            var result = await _userApiClient.ChangePassword(request);
            if (result.IsSuccessed)
            {
                return RedirectToAction("EditUser", "User", new { id = request.UserID });

            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("user/bloggers")]
        public async Task<IActionResult> GetBloggerPaging(int PageIndex = 1, int PageSize = 5, String Keyword ="")
        {
            var request = new GetUserPagingRequest()
            {
                PageIndex = PageIndex,
                PageSize = PageSize,
                Keyword = Keyword
            };
            var data = await _userApiClient.GetPagings(request);
            return new OkObjectResult(data);
        }
        [HttpGet("view-list-blogger")]
        public IActionResult ListBlogger()
        {
            return View();  
        }

        [HttpGet("delete/{UserID}")]
         public async Task<IActionResult> DeleteAsync(Guid UserID)
        {
            var result = await _userApiClient.Delete(UserID);
            if (result)
            {
                return RedirectToAction("ListBlogger");
            }
            return RedirectToAction("Index");
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
            return RedirectToAction("ListBlogger");
        }


        public IActionResult Error()
        {
            return View();
        }

        [HttpPost("check-phone-email-exist")]
        public async Task<IActionResult> CheckExist(string email, string phone)
        {
            var result = await _userApiClient.CheckExist(email, phone);
            return new OkObjectResult(result);
        }
    }
}
