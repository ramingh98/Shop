﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Validation;
using Common.AspNetCore.Enums;
using Common.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Common.AspNetCore.Middleware
{
    public class ApiCustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _env;
        private readonly ILogger<ApiCustomExceptionHandlerMiddleware> _logger;

        public ApiCustomExceptionHandlerMiddleware(RequestDelegate next,
            IHostingEnvironment env,
            ILogger<ApiCustomExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _env = env;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            string message = null;
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            StatusCode apiStatusCode = StatusCode.ServerError;

            try
            {
                await _next(context);
            }
            catch (InvalidDomainDataException exception)
            {
                _logger.LogError(exception, exception.Message);
                apiStatusCode = StatusCode.LogicError;
                SetErrorMessage(exception);
                await WriteToResponseAsync();
            }
            catch (InvalidCommandException exception)
            {
                _logger.LogError(exception, exception.Message);
                httpStatusCode = HttpStatusCode.BadRequest;
                SetErrorMessage(exception);
                await WriteToResponseAsync();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);

                SetErrorMessage(exception);
                await WriteToResponseAsync();
            }

            void SetErrorMessage(Exception exception)
            {
                message = exception.Message;
                if (_env.IsDevelopment())
                {
                    var dic = new Dictionary<string, string>
                    {
                        ["Exception"] = exception.Message,
                        ["StackTrace"] = exception.StackTrace,
                    };
                    if (exception.InnerException != null)
                    {
                        dic.Add("InnerException.Exception", exception.InnerException.Message);
                        dic.Add("InnerException.StackTrace", exception.InnerException.StackTrace);
                    }

                    message = JsonConvert.SerializeObject(dic);
                }
            }
            async Task WriteToResponseAsync()
            {
                if (context.Response.HasStarted)
                    throw new InvalidOperationException("The response has already started, the http status code middleware will not be executed.");

                var result = new ApiResult()
                {
                    IsSuccess = false,
                    MetaData = new()
                    {
                        AppStatusCode = apiStatusCode,
                        Message = message
                    }
                };
                var json = JsonConvert.SerializeObject(result);

                context.Response.StatusCode = (int)httpStatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
        }
    }
}