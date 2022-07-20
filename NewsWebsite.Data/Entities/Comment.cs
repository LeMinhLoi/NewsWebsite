using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class Comment
    {
        public int IdUser { get; set; }
        public int IdNews { get; set; }
        public int UserInfo { get; set; }
        public int News { get; set; }
        public string Content { get; set; }
    }
}
