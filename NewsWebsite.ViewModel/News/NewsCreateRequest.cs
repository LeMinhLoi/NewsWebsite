using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.ViewModel.News
{
    public class NewsCreateRequest
    {
        public string Tittle { get; set; }
        public string SrcCoverImage { get; set; }
        public string Content { get; set; }
        public Guid IdAuthor { get; set; }
        public List<int> Catalogs{ get; set; }
    }
}
