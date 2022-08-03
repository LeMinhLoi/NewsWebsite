using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class HistoryView
    {
        public Guid IdUser { get; set; }
        public Guid IdNews { get; set; }
        public UserInfo UserInfo { get; set; }
        public News News { get; set; }
        public DateTime DateView { get; set; }
    }
}
