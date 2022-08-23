using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.ViewModel.News
{
    public class NewsVM
    {
        public string Title { get; set; }
        public DateTime DateCreate { get; set; }
        public string NameAuthor { get; set; }
        public List<String> Catalogs { get; set; }
        //public string SrcCoverImage { get; set; }
        //public int CommentCount { get; set; }
        //public int ViewCount { get; set; }
        //public int LikeCount { get; set; }
        //public int DislikeCount { get; set; }
    }
}
