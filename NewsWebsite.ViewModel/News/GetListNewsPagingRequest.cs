using NewsWebsite.ViewModel.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.ViewModel.News
{
    public class GetListNewsPagingRequest : PagingRequestBase
    {
        //public string Keyword { get; set; }
        public int CatalogID { get; set; }
    }
}
