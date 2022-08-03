using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.ViewModel.User
{
    public class UserCreateRequest
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public string UserName { get; set; }
        public DateTime DoB { get; set; }
        public bool Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActived { get; set; }
        public string Password { get; set; }
        public Guid RoleID { get; set; }
        public IFormFile ImageUser { get; set; }

    }
}
