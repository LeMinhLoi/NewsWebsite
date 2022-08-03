using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class News
    {
        public Guid IdNews { get; set; }
        public string Tittle { get; set; }
        public DateTime DateCreate { get; set; }
        public int ViewCount { get; set; }
        public bool IsAccept { get; set; }
        public string Content { get; set; }
        public Guid IdAuthor { get; set; }
        //public UserInfo UserInfo { get; set; }
        public List<HistoryLike> HistoryLikes { get; set; }
        public List<HistoryView> HistoryViews{ get; set; }
        public List<Comment> Comments{ get; set; }
        public List<NewsInCatalog> NewsInCatalogs { get; set; }
        public List<ImageInNews> ImageInNews{ get; set; }
    }

}
