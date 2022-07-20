using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    class History
    {
        public int IdUser { get; set; }
        public int IdNews { get; set; }
        public int UserInfo { get; set; }
        public int News { get; set; }
        public DateTime DateView { get; set; }
    }
}
