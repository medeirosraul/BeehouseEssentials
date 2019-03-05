using System;
using System.Collections.Generic;
using System.Text;

namespace Beehouse.Essentials.Web.Api
{
    public class ApiResult<TResult>
    {
        public ApiResultStatus Status { get; set; }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
        public TResult Content { get; set; }
    }
}
