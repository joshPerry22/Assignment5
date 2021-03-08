using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Infrastructure
{
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) =>   //if request has value set to request path and query string otherwise path to string
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();  
    }
}
