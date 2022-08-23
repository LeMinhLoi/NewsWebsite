using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NewsWebsite.Data.EF;
using NewsWebsite.Data.Entities;
using NewsWebsite.Utilities.Constants;
using NewsWebsite.ViewModel.ApiResult;
using NewsWebsite.ViewModel.Image.ImageUser;
using NewsWebsite.ViewModel.Pagination;
using NewsWebsite.ViewModel.User;
using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using NewsWebsite.Utilities.Generate;
using Microsoft.Extensions.Configuration;

namespace NewsWebsite.Application.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserInfo> _userManager;
        private readonly SignInManager<UserInfo> _signInManager;
        private readonly WebsiteDBContext _websiteDBContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _config;


        public UserService(UserManager<UserInfo> userManager, IConfiguration config,
            SignInManager<UserInfo> signInManager, WebsiteDBContext websiteDBContext, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _websiteDBContext = websiteDBContext;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
        }
        public async Task<ApiResultVM<string>> AddUser(UserCreateRequest request)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email))
            {
                return new ApiErrorResultVM<string>("Email này đã tồn tại!");
            }
            if (await _userManager.Users.AnyAsync(x => x.PhoneNumber == request.Phone))
            {
                return new ApiErrorResultVM<string>("Số điện thoại này đã tồn tại!");
            }
            //create GUID for user
            Guid guidIDUser = Guid.NewGuid();
            var hasher = new PasswordHasher<IdentityUser>();
            var userInfo = new UserInfo()
            {
                Id = guidIDUser,
                FirstName = request.FirstName,
                LastName = request.LastName,
                NickName = request.NickName,
                DoB = request.DoB,
                Gender = request.Gender,
                PhoneNumber = request.Phone,
                Email = request.Email,
                IsActive = request.IsActived,
                UserName = request.UserName,
                PasswordHash = hasher.HashPassword(null, request.Password),
                SecurityStamp = new Guid().ToString(),
                DateCreate = DateTime.Now
            };
            //create role of user
            var userRole = new IdentityUserRole<Guid>()
            {   
                RoleId = request.RoleID,
                UserId = guidIDUser
            };
            try
            {

                int check = 0;
                var idImageUser = new Guid();
                //create image of user
                //first: create guid of image
                ImageUser imageUser = null;
                if (request.ImageUser != null)
                {
                    check = 1;
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + SystemConstants.pathImageUser))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + SystemConstants.pathImageUser);
                    }
                    String nameFile = RandomString.Result(10);
                    String pathFile = SystemConstants.pathImageUser + nameFile + ".png";
                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + pathFile))
                    {
                        await request.ImageUser.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();

                    }
                    imageUser = new ImageUser()
                    {
                        IdImage = idImageUser,
                        Path = pathFile
                    };
                    
                }
                if(check == 0)
                {
                    userInfo.ImageUser = null;
                }
                else
                {
                    userInfo.ImageUser = imageUser;
                }
                //await _websiteDBContext.ImageUsers.AddAsync(imageUser);
                await _websiteDBContext.UserInfos.AddAsync(userInfo);
                await _websiteDBContext.UserRoles.AddAsync(userRole);
                await _websiteDBContext.SaveChangesAsync();
                return new ApiSuccessResultVM<string>();
            }
            catch (Exception ex)
            {
                return new ApiErrorResultVM<string>(ex.ToString());
            }
            
        }
        public async Task<ApiResultVM<string>> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.MyEmail);
            if (user == null)
            { 
                return new ApiErrorResultVM<string>("EMAIL không tồn tại"); 
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);
            if (!result.Succeeded)
            {
                return new ApiErrorResultVM<string>("Mật khẩu đăng nhập không đúng");

            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.GivenName,user.FirstName),
                    new Claim(ClaimTypes.Role, string.Join(";",roles)),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.HomePhone, user.PhoneNumber),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }
                );
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = _config["Tokens:Issuer"],//issuer 
                Audience = _config["Tokens:Issuer"],//audience
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new ApiSuccessResultVM<string>(tokenHandler.WriteToken(token));
        }
        public Task<ApiResultVM<bool>> Register(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
        public async Task<ApiResultVM<string>> Delete(Guid id)
        {
            var usr = await _websiteDBContext.Users.Include(a => a.ImageUser).FirstOrDefaultAsync(a => a.Id == id);
            if (usr == null)
            {
                return new ApiErrorResultVM<string>("Not found user");
            }
            StringBuilder pathImage = null;
            if(usr.ImageUser != null)
            {
                pathImage = new StringBuilder();
                pathImage.Append(_webHostEnvironment.WebRootPath + usr.ImageUser.Path);
            }
            try
            {
                if (usr.ImageUser != null)
                {
                    _websiteDBContext.ImageUsers.Remove(usr.ImageUser);
                }
                
                _websiteDBContext.UserInfos.Remove(usr);
                await _websiteDBContext.SaveChangesAsync();
                if (pathImage != null)
                {
                    File.Delete(pathImage.ToString());
                }
            }
            catch (Exception e)
            {

                return new ApiErrorResultVM<string>("Not success");
            }
            
            return new ApiSuccessResultVM<string>();

        }
        public async Task<ApiResultVM<UserVM>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if(user == null)
            {
                return new ApiErrorResultVM<UserVM>("Not found by Id");
            }
            ImageUser imageUser = null;
            if (user.IdImageAvatar != null)
            {
                imageUser = await _websiteDBContext.ImageUsers.FindAsync(user.IdImageAvatar);
            }
            var userVM = new UserVM()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                NickName = user.NickName,
                DoB = user.DoB,
                Gender = user.Gender,
                Phone = user.PhoneNumber,
                Email = user.Email,
                //IsActived = user.IsActive,
                PathImageAvatar = (imageUser != null) ? imageUser.Path : null,
            };
            return new ApiSuccessResultVM<UserVM>(userVM);
        }
        public async Task<PagedResult<UserVM>> GetUserPagingByRole(GetUserPagingRequest request, Guid idRole)
        {
            //1. Select join
            var query = from ui in _websiteDBContext.UserInfos
                        join h in _websiteDBContext.UserRoles on ui.Id equals h.UserId
                        join r in _websiteDBContext.WebRoles on h.RoleId equals r.Id
                        where r.Id == idRole
                        select ui;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.FirstName.Contains(request.Keyword) || x.LastName.Contains(request.Keyword));
            }
            //2. Paging
            int totalRow = await query.CountAsync();
            var data = await query.OrderByDescending(x => x.DateCreate).Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new UserVM()
                {
                    Id = x.Id,
                    LastName = x.LastName,
                    FirstName = x.FirstName,
                    NickName = x.NickName,
                    DoB = x.DoB,
                    Gender = x.Gender,
                    Phone = x.PhoneNumber,
                    Email = x.Email,
                    DateCreate = x.DateCreate
                    //IsActived = x.IsActive,
                    //PathImageAvatar = (x.ImageUser != null) ? x.ImageUser.Path : "Not found"
                }).ToListAsync();
            //3. Select and projection
            var pagedResult = new PagedResult<UserVM>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
        public async Task<ApiResultVM<string>> UpdateImage(ImageUserUpdateRequest request)
        {
            var user = await _websiteDBContext.UserInfos.FindAsync(request.Id);
            if (user.IdImageAvatar != null)//if image exist
            {
                try
                {
                    var imageUser = await _websiteDBContext.ImageUsers.FindAsync(user.IdImageAvatar);
                    try
                    {
                        if (imageUser.Path != null)
                        {
                            File.Delete(_webHostEnvironment.WebRootPath + imageUser.Path);//delete old image
                        }
                        
                    }
                    catch (Exception e)
                    {
                        string a = e.ToString();
                        return new ApiErrorResultVM<string>(e.ToString());
                    }
                    
                    String nameFile = RandomString.Result(10);
                    String newPathFile = SystemConstants.pathImageUser + nameFile + ".png";
                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + newPathFile))
                    {
                        await request.ImageFile.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();
                    }
                    
                    imageUser.Path = newPathFile;
                    _websiteDBContext.ImageUsers.Update(imageUser);
                    _websiteDBContext.UserInfos.Update(user);
                    await _websiteDBContext.SaveChangesAsync();
                    return new ApiSuccessResultVM<string>();
                }
                catch (Exception e)
                {

                    return new ApiErrorResultVM<string>(e.ToString());
                }
                
            }
            else//if image not exist
            {
                try
                {
                    var idImageUser = new Guid();
                    //create image of user
                    //first: create guid of image
                    ImageUser imageUser = null;
                    if (request.ImageFile != null)
                    {
                        if (!Directory.Exists(_webHostEnvironment.WebRootPath + SystemConstants.pathImageUser))
                        {
                            Directory.CreateDirectory(_webHostEnvironment.WebRootPath + SystemConstants.pathImageUser);
                        }
                        String nameFile = RandomString.Result(10);
                        String pathFile = SystemConstants.pathImageUser + nameFile + ".png";
                        using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + pathFile))
                        {
                            await request.ImageFile.CopyToAsync(fileStream);
                            await fileStream.FlushAsync();

                        }
                        imageUser = new ImageUser()
                        {
                            IdImage = idImageUser,
                            Path = pathFile
                        };
                        user.ImageUser = imageUser;
                        _websiteDBContext.UserInfos.Update(user);
                        await _websiteDBContext.SaveChangesAsync();
                        return new ApiSuccessResultVM<string>();
                    }
                }
                catch (Exception e)
                {

                    return new ApiErrorResultVM<string>(e.ToString());
                }
                
            }
            return new ApiErrorResultVM<string>("No image to update!");
        }
        public async Task<ApiResultVM<ImageUserVM>> GetImageUserById(Guid id) //id is user id, not id of image
        {
            var user = await _websiteDBContext.UserInfos.FindAsync(id);
            if(user == null)
            {
                return new ApiErrorResultVM<ImageUserVM>("Not found user");
            }    
            if(user.IdImageAvatar == null)
            {
                return new ApiErrorResultVM<ImageUserVM>("Không tìm thấy hình ảnh");
            }
            var imageUser = await _websiteDBContext.ImageUsers.FindAsync(user.IdImageAvatar);
            ImageUserVM imageUserVM = new ImageUserVM()
            {
                IdUser = user.Id,
                ImagePath = imageUser.Path
            };
            return new ApiSuccessResultVM<ImageUserVM>(imageUserVM);
        }
        public async Task<ApiResultVM<bool>> UpdateInfo(Guid id, UserUpdateRequest request)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
            {
                return new ApiErrorResultVM<bool>("Email đã tồn tại!");
            }
            if (await _userManager.Users.AnyAsync(x => x.PhoneNumber == request.Phone && x.Id != id))
            {
                return new ApiErrorResultVM<bool>("Số điện thoại đã tồn tại!");
            }
            var user = await _websiteDBContext.UserInfos.FindAsync(id);
            user.PhoneNumber = request.Phone;
            user.Email = request.Email;
            user.LastName = request.LastName;
            user.FirstName = request.FirstName;
            user.NickName = request.NickName;
            user.Gender = request.Gender;
            user.DoB = request.DoB;
            user.IsActive = request.IsActived;
            if(request.ImageUser != null)
            {
                if (user.IdImageAvatar != null)//if image exist
                {
                    try
                    {
                        var imageUser = await _websiteDBContext.ImageUsers.FindAsync(user.IdImageAvatar);
                        try
                        {
                            if (imageUser.Path != null)
                            {
                                File.Delete(_webHostEnvironment.WebRootPath + imageUser.Path);//delete old image
                            }

                        }
                        catch (Exception e)
                        {
                            string a = e.ToString();
                        }

                        String nameFile = RandomString.Result(10);
                        String newPathFile = SystemConstants.pathImageUser + nameFile + ".png";
                        using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + newPathFile))
                        {
                            await request.ImageUser.CopyToAsync(fileStream);
                            await fileStream.FlushAsync();
                        }

                        imageUser.Path = newPathFile;
                        _websiteDBContext.ImageUsers.Update(imageUser);
                        //_websiteDBContext.UserInfos.Update(user);
                        //await _websiteDBContext.SaveChangesAsync();
                        //return new ApiSuccessResultVM<string>();
                    }
                    catch (Exception e)
                    {

                    }

                }
                else//if image not exist
                {
                    try
                    {
                        var idImageUser = new Guid();
                        //create image of user
                        //first: create guid of image
                        ImageUser imageUser = null;
                        if (request.ImageUser != null)
                        {
                            if (!Directory.Exists(_webHostEnvironment.WebRootPath + SystemConstants.pathImageUser))
                            {
                                Directory.CreateDirectory(_webHostEnvironment.WebRootPath + SystemConstants.pathImageUser);
                            }
                            String nameFile = RandomString.Result(10);
                            String pathFile = SystemConstants.pathImageUser + nameFile + ".png";
                            using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + pathFile))
                            {
                                await request.ImageUser.CopyToAsync(fileStream);
                                await fileStream.FlushAsync();

                            }
                            imageUser = new ImageUser()
                            {
                                IdImage = idImageUser,
                                Path = pathFile
                            };
                            user.ImageUser = imageUser;
                        }
                    }
                    catch (Exception e)
                    {

                    }

                }
            }

            try
            {
                _websiteDBContext.UserInfos.Update(user);
                await _websiteDBContext.SaveChangesAsync();
                return new ApiSuccessResultVM<bool>();
                //var result = await _userManager.UpdateAsync(user);
                //if (result.Succeeded)
                //{
                //    return new ApiSuccessResultVM<bool>();
                //}
            }
            catch (Exception e)
            {
                return new ApiErrorResultVM<bool>("Cập nhật không thành công");
            }
        }
        public async Task<ApiResultVM<string>> UpdatePassword(Guid id, string password)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if (user == null)
                {
                    return new ApiErrorResultVM<string>("Tài khoản không tồn tại");
                }
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var hasher = new PasswordHasher<IdentityUser>();
                var result = await _userManager.ResetPasswordAsync(user, token, password);
                if (result.Succeeded)
                {
                    return new ApiSuccessResultVM<string>();
                }
                return new ApiErrorResultVM<string>("Change fail!");
            }
            catch (Exception)
            {

                return new ApiErrorResultVM<string>("Change fail!");
            }
        }

        public async Task<ApiResultVM<string>> CheckExistEmailAndPhone(string email, string phone)
        {
            bool checkPhone = false;
            bool checkEmail = false;
            if (await _userManager.Users.AnyAsync(x => x.Email == email))
            {
                checkEmail = true;
            }
            if (await _userManager.Users.AnyAsync(x => x.PhoneNumber == phone))
            {
                checkPhone = true;
            }
            if(checkPhone && checkEmail)
            {
                return new ApiErrorResultVM<string>("Số điện thoại và email này đã tồn tại!");
            }
            if(checkEmail && !checkPhone)
            {
                return new ApiErrorResultVM<string>("Email này đã tồn tại!");
            }
            if (!checkEmail && checkPhone)
            {
                return new ApiErrorResultVM<string>("Số điện thoại này đã tồn tại!");
            }
            return new ApiSuccessResultVM<string>();
        }
    }
}
