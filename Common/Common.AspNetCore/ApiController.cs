using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Common.AspNetCore
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected ApiResult CommandResult(OperationResult operationResult)
        {
            return new ApiResult()
            {
                IsSuccess = operationResult.Status == OperationResultStatus.Success,
                MetaData = new()
                {
                    AppStatusCode = operationResult.Status.MapOperationStatus()
                }
            };
        }

        protected ApiResult<TData?> CommandResult<TData>(OperationResult<TData?> operationResult, HttpStatusCode statusCode = HttpStatusCode.OK, string? locationUrl = null)
        {
            bool isSuccess = operationResult.Status == OperationResultStatus.Success;
            if (isSuccess)
            {
                HttpContext.Response.StatusCode = (int)statusCode;
                if (!string.IsNullOrWhiteSpace(locationUrl))
                {
                    HttpContext.Response.Headers.Add("location", locationUrl);
                }
            }

            return new ApiResult<TData?>()
            {
                IsSuccess = isSuccess,
                Data = isSuccess ? operationResult.Data : default,
                MetaData = new()
                {
                    AppStatusCode = operationResult.Status.MapOperationStatus(),
                    Message = operationResult.Message
                }
            };
        }

        protected ApiResult<TData> QueryResult<TData>(TData data)
        {
            return new ApiResult<TData>()
            {
                Data = data,
                IsSuccess = true,
                MetaData = new()
                {
                    AppStatusCode = Enums.StatusCode.Success,
                    Message = "عملیات با موفقیت انجام شد."
                }
            };
        }
    }
}