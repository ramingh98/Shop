using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.AspNetCore.Enums
{
    public enum StatusCode
    {
        Success = 1,
        NotFound = 2,
        BadRequest = 3,
        LogicError = 4,
        UnAuthorize = 5,
        ServerError
    }
}