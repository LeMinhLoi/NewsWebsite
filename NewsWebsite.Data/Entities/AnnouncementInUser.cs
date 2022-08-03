using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class AnnouncementInUser
    {
        public Guid IdUser { get; set; }
        public Guid IdAnnouncement { get; set; }
        public UserInfo UserInfo { get; set; }
        public Announcement Announcement { get; set; }
        public bool IsViewed { get; set; }

    }

}
