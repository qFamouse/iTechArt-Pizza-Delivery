﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing.Constraints;

namespace iTechArtPizzaDelivery.Core.Exceptions
{
    public class HttpStatusCodeException : Exception
    {
        public int StatusCode { get; set; }

        public HttpStatusCodeException(int statusCode) : base(GetDefaultMessage(statusCode))
        {
            this.StatusCode = statusCode;
        }

        public HttpStatusCodeException(HttpStatusCode statusCode) : base(GetDefaultMessage((int)statusCode))
        {
            this.StatusCode = (int)statusCode;
        }

        public HttpStatusCodeException(int statusCode, string message) : base(message)
        {
            this.StatusCode = statusCode;
        }

        public HttpStatusCodeException(HttpStatusCode statusCode, string message) : base(message)
        {
            this.StatusCode = (int)statusCode;
        }

        private static string GetDefaultMessage(int statusCode)
        {
            switch (statusCode)
            {
                case 404: return "Not Found";
                default: return "";
            }
        }
    }
}