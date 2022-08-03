using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class ImageUser
    {
        public Guid IdImage { get; set; }
        public string Path { get; set; }
        public UserInfo UserInfo { get; set; }
    }

}
