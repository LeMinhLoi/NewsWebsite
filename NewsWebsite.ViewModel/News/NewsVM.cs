using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.ViewModel.News
{
    public class NewsVM
    {
        public Guid IdNews { get; set; }
        public string Title { get; set; }
        public DateTime DateCreate { get; set; }
        public string NameAuthor { get; set; }
        public List<String> Catalogs { get; set; }
    }
}
