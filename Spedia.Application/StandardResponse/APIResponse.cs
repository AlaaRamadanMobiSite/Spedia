using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spedia.Application.StandardResponse
{
    public class APIResponse<T>
    {
        public int StausCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
    }
}
