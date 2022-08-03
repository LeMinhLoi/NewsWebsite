using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class ImageInNews
    {
        public Guid IdImageNews { get; set; }
        public ImageNews ImageNews { get; set; }
        public Guid IdNews { get; set; }
        public News News  { get; set; }
        public int Order { get; set; }
    }
}
