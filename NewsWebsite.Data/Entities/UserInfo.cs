using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Phone { get; set; }
        public DateTime DoB { get; set; }
        public bool Gender { get; set; }
        public int IdImageAvatar { get; set; }
        public ImageUser ImageUser { get; set; }
        public bool IsActive { get; set; }

    }
}
