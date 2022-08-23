using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsWebsite.Application.User;
using NewsWebsite.ViewModel.Image.ImageUser;
using NewsWebsite.ViewModel.ModelValidate;
using NewsWebsite.ViewModel.PasswordVM;
using NewsWebsite.ViewModel.User;
using System;
using System.Threading.Tasks;

namespace NewsWebsite.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //---------------------------------------------------------------------------------------
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Authencate(request);

            if (string.IsNullOrEmpty(result.ResultObj))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //---------------------------------------------------------------------------------------
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }
        //---------------------------------------------------------------------------------------
        [HttpPost("{Id}")]
        [Consumes("multipart/form-data")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateInfo(Guid Id, [FromForm] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.UpdateInfo(Id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);

            //return Ok();
        }
        //---------------------------------------------------------------------------------------
        [HttpPost("image/update")]
        [Consumes("multipart/form-data")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateImageUser([FromForm] ImageUserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.UpdateImage(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //---------------------------------------------------------------------------------------
        [HttpPost("password/update/")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdatePassword(PasswordVM request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.UpdatePassword(request.UserID, request.NewPass);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //---------------------------------------------------------------------------------------
        [HttpPost("create-blogger")]
        [Consumes("multipart/form-data")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromForm] UserCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.AddUser(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //---------------------------------------------------------------------------------------
        [HttpGet("bloggers/paging/")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaging([FromQuery] int PageIndex, [FromQuery] int PageSize, [FromQuery] Guid roleID, [FromQuery] String Keyword)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var request = new GetUserPagingRequest()
            {
                PageIndex = PageIndex,
                PageSize = PageSize,
                Keyword = Keyword
            };
            var result = await _userService.GetUserPagingByRole(request, roleID);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //---------------------------------------------------------------------------------------
        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Delete(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //----------------------------------------------------------------------------------------
        [HttpGet("image/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetImageById(Guid id)
        {
            var image = await _userService.GetImageUserById(id);
            return Ok(image);
        }
        //----------------------------------------------------------------------------------------
        [HttpPost("check-exist")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckEmailAndPhoneExist(PhoneEmailVM request)
        {
            var result = await _userService.CheckExistEmailAndPhone(request.Email, request.Phone);
            if (result.IsSuccessed)
            {
                Ok(result);
            }
            return BadRequest(result);
        }
    }
}
