using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.ViewModel.Pagination
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { set; get; }
    }
}
