using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.ViewModel.ApiResult
{
    public class ApiErrorResultVM<T> : ApiResultVM<T>
    {
        public string[] ValidationErrors { get; set; }

        public ApiErrorResultVM()
        {
        }

        public ApiErrorResultVM(string message)
        {
            IsSuccessed = false;
            Message = message;
        }

        public ApiErrorResultVM(string[] validationErrors)
        {
            IsSuccessed = false;
            ValidationErrors = validationErrors;
        }
    }
}
