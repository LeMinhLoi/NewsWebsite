using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.ViewModel.User
{
    public class UserVM
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public DateTime DoB { get; set; }
        public DateTime DateCreate { get; set; }
        public bool Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PathImageAvatar { get; set; }
    }
}
