using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.ViewModel.Pagination
{
    public class PagingRequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
