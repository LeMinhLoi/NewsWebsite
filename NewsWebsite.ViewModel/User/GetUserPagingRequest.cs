using NewsWebsite.ViewModel.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.ViewModel.User
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
