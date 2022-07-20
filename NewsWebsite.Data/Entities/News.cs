using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class News
    {
        public int IdNews { get; set; }
        public string Tittle { get; set; }
        public DateTime DateCreate { get; set; }
        public int ViewCount { get; set; }
        public bool IsAccept { get; set; }
        public int IdContentNews { get; set; }
        public ContentNews ContentNews { get; set; }


    }

}
