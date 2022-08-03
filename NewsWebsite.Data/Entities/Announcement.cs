using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class Announcement
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        public List<AnnouncementInUser> AnnouncementInUsers  { get; set; }
    }
}
