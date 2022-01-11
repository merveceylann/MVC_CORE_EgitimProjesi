using CoreApp102.Api.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp102.Api.Extensions
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;
                        if (ex != null)
                        {
                            ErrosDto errosDto = new ErrosDto();
                            errosDto.Status = 500;
                            errosDto.Errors.Add(ex.Message);
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(errosDto));
                        }
                    }
                });
            });
        }
    }
}
