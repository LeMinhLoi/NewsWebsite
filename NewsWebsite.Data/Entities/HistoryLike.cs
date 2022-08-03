using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class HistoryLike
    {
        public Guid IdUser { get; set; }
        public Guid IdNews { get; set; }
        public UserInfo UserInfo { get; set; }
        public News News { get; set; }
        public DateTime DateLike { get; set; }
        public bool IsLike { get; set; }
    }
}
