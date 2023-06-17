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
        private readonly IRequestRepository _repository;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, IRequestRepository request)
        {
            _next = next;
            _repository = request;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            string requestURL = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}";
            Console.WriteLine(requestURL);
            await _repository.AddRequest(requestURL);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
