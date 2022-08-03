using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.ViewModel.ApiResult
{
    public class ApiSuccessResultVM<T> : ApiResultVM<T>
    {
        public ApiSuccessResultVM(T resultObj)
        {
            IsSuccessed = true;
            ResultObj = resultObj;
        }

        public ApiSuccessResultVM()
        {
            IsSuccessed = true;
        }
    }
}
