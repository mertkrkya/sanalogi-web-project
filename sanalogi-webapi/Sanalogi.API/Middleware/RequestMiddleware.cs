using Microsoft.AspNetCore.Http;
using Serilog;
using System.Threading.Tasks;

namespace Sanalogi.API.Middleware
{
    public class RequestMiddleware
    {
        private RequestDelegate _requestDelegate;
        public RequestMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            Log.Information(context.Request.Body.ToString());
            await _requestDelegate(context);
        }
    }
}
