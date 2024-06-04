using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Serilog;

namespace Test.MiddleWareError
{
    public class ManejoErrorMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
           try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var RespuestaError = new
                {
                    error = ex.Message,
                    stackTrace = ex.TargetSite
                };
                Log.Fatal(ex,ex.Message);
                string jsonResponse = JsonConvert.SerializeObject(RespuestaError);
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}