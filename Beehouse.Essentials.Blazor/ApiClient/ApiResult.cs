using System;
using System.Collections.Generic;
using System.Text;

namespace Beehouse.Essentials.Blazor.ApiClient
{
    public class ApiResult<TResult>
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public bool Error { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
        public TResult Result { get; set; }
    }
}
