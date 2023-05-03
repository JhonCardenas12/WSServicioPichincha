using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text.Json;
using WSServicioPichincha.Domain.Exceptions;

namespace WSServicioPichincha.Domain.Middlewares
{
    public class ExceptionMiddleware
    {
        private ResponseExeption responseExeption;
        private readonly RequestDelegate _requestDelegate;
        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
            responseExeption = new ResponseExeption();
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = (int)PichinchaStatusCode.GetExceptionStatusCode(ex);
                responseExeption.Message = ex.Message;
                httpContext.Response.ContentType= "application/json";
                await httpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(responseExeption));
            }
        }

    }
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
