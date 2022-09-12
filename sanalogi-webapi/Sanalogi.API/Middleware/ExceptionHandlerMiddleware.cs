﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Sanalogi.Core.Entities;
using Sanalogi.Service.Exceptions;
using Serilog;
using System.Text.Json;

namespace Sanalogi.API.Middleware
{
    public static class ExceptionHandlerMiddleware
    {
        public static void CustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientException => 400,
                        _ => 500
                    };
                    if (statusCode == 400)
                        Log.Information(exceptionFeature.Error.Message);
                    else
                        Log.Error(exceptionFeature.Error.Message);
                    context.Response.StatusCode = statusCode;
                    var response = new ResponseEntity(errorMessage: exceptionFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
