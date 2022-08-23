using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class UserInfo : IdentityUser<Guid>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public DateTime DoB { get; set; }
        public bool Gender { get; set; }
        public Guid? IdImageAvatar { get; set; }
        public ImageUser ImageUser { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreate { get; set; }
        public List<AnnouncementInUser> AnnouncementInUsers { get; set; }
        public List<CatalogInUser> CatalogInUsers { get; set; }
        public List<HistoryLike> HistoryLikes { get; set; }
        public List<HistoryView> HistoryViews { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ReportComment> ReportComments { get; set; }
        public List<Permission> Permissions{get; set;}
    }
}
