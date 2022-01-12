using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Exceptions;
using Microsoft.AspNetCore.Http;

namespace iTechArtPizzaDelivery.WebUI.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpStatusCodeException ex)
            {
                await HandleHttpStatusCodeExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        #region Handlers

        private static Task HandleHttpStatusCodeExceptionAsync(HttpContext context, HttpStatusCodeException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception.StatusCode;

            return context.Response.WriteAsJsonAsync(new
            {
                StatusCode = exception.StatusCode,
                Error = exception.Message
            });
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            int statusCode = (int) HttpStatusCode.InternalServerError;

            return context.Response.WriteAsJsonAsync(new
            {
                StatusCode = statusCode,
                Error = exception.Message
            });
        }

        #endregion
    }
}