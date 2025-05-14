using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkPeddler.Common.RequestAndResponses
{
    public class BaseRequest { }

    public class BaseActiveRequest { }

    public class BaseResponse
    {
        public bool Success { get; set; } = false;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
