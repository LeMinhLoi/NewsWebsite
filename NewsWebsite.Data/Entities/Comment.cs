using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdNews { get; set; }
        public UserInfo UserInfo { get; set; }
        public News News { get; set; }
        public string Content { get; set; }
        public DateTime DateComment { get; set; }
        public int? ParentId { get; set; }// to conduct function reply in facebook
        public List<UserInfo> UserInfos { get; set; }
        //public List<ReportComment> ReportComments { get; set; }
    }
}
