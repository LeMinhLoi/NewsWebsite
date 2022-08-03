using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsWebsite.Application.User;
using NewsWebsite.Utilities.AttributeForUploadFile;
using NewsWebsite.ViewModel.Image.ImageUser;
using NewsWebsite.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpPut("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateInfo(Guid Id, [FromBody] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.UpdateInfo(Id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //---------------------------------------------------------------------------------------
        [HttpPost("image/update")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateImageUser([FromForm]ImageUserUpdateRequest request)
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
        [HttpPut("password/{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdatePassword(Guid Id, [FromBody] string Password)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.UpdatePassword(Id, Password);
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
        public async Task<IActionResult> GetAllPaging([FromQuery] int PageIndex, [FromQuery] int PageSize, [FromQuery] Guid roleID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var request = new GetUserPagingRequest()
            {
                PageIndex = PageIndex,
                PageSize = PageSize
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
    }
}
