using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Common.AspNetCore.Enums;

namespace Common.AspNetCore
{
    public static class EnumHelper
    {
        public static StatusCode MapOperationStatus(this OperationResultStatus status)
        {
            switch (status)
            {
                case OperationResultStatus.Success:
                    return StatusCode.Success;
                case OperationResultStatus.NotFound:
                    return StatusCode.NotFound;
                case OperationResultStatus.Error:
                    return StatusCode.LogicError;
            }

            return StatusCode.LogicError;
        }
    }
}