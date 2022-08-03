using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.ViewModel.ApiResult
{
    public class ApiResultVM<T>
    {
        public bool IsSuccessed { get; set; }

        public string Message { get; set; }

        public T ResultObj { get; set; }
    }
}
