using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class ImageNews
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
        public List<ImageInNews> ImageInNewss { get; set; }
    }
}
