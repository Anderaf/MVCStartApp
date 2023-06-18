using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using MVCStartApp.Repositories;
using MVCStartApp.Models.Db;

namespace MVCStartApp.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context, IRequestRepository repository)
        {
            string requestURL = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}";
            Console.WriteLine(requestURL);
            await repository.AddRequest(requestURL);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
