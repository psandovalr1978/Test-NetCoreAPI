using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;

namespace Test.MiddleWareError
{
    public class ManejoErrorMiddleware : IMiddleware
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

                var errorDetails = GetError(ex);

                var respuestaError = new
                {
                    error = ex.Message,
                    detalles = errorDetails
                };

                Log.Fatal(ex, "Detalles del error: {ErrorDetails}", errorDetails);

                string jsonResponse = JsonConvert.SerializeObject(respuestaError);
                await context.Response.WriteAsync(jsonResponse);
            }
        }

        private string GetError(Exception ex)
        {
            var stackTrace = new StackTrace(ex, true);
            var frame = stackTrace.GetFrame(0);
            var method = frame?.GetMethod();
            var declaringType = method?.DeclaringType;
            var lineNumber = frame?.GetFileLineNumber();

            return $"Error en {declaringType?.FullName}.{method?.Name} en la linea {lineNumber}.";
        }
    }
}
