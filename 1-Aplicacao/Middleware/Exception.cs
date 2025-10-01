
using Newtonsoft.Json;
using SistemVenda.Models;
using System.Net;
using System.Text;

namespace SistemaVendas.Middleware;

public class ExceptionHandler
{
    private readonly RequestDelegate _next;
    public ExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var response = context.Response;
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            response.ContentType = "application/json";
            var r = new ApiResponse<bool>(false, ex.Message, false);
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            var json = JsonConvert.SerializeObject(r);
            var b = Encoding.UTF8.GetBytes(json);

            await response.Body.WriteAsync(b).AsTask();
            await response.StartAsync();
        }
    }
}