using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.ViewModel.User
{
    public class LoginRequest
    {
        public string MyEmail { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
