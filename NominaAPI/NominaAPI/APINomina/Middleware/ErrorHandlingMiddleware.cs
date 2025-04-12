using APINomina.Extensions;
using DatosNomina;
using System.Net;

namespace APINomina.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessException ex)
            {
                    _logger.LogWarning(ex, "Se interceptó una excepción de negocio.");
                await HandleBusinessExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Se ha producido un error en la solicitud.");

                await HandleExceptionAsync(context);
            }
        }
        private Task HandleBusinessExceptionAsync(HttpContext context, BusinessException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            var response = new
            {
                codigoError = "003",
                mensaje = ex.Message
            };

            return context.Response.WriteAsJsonAsync(response);
        }

        private Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new
            {
                message = "Ocurrió un error inesperado. Por favor, inténtelo más tarde."
            };

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
