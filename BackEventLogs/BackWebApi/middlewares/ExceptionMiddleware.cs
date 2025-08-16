using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using BackWebApi.Utils;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BackWebApi.Middlewares
{
    public class ExceptionMiddleware : IExceptionFilter
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            _logger.LogError(ex, "Una excepción ha ocurrido");

            int status;
            string message;

            if (ex is CustomException custom)
            {
                status = custom.StatusCode;
                message = custom.Message;
            }
            else
            {
                (status, message) = ex switch
                {
                    ArgumentNullException => ((int)HttpStatusCode.BadRequest, "Falta un argumento requerido."),
                    ArgumentException => ((int)HttpStatusCode.BadRequest, "El argumento proporcionado no es válido."),
                    KeyNotFoundException => ((int)HttpStatusCode.NotFound, "Recurso no encontrado."),
                    DbUpdateException => ((int)HttpStatusCode.InternalServerError, "Ocurrió un error al actualizar la base de datos."),
                    _ => ((int)HttpStatusCode.InternalServerError, "Ocurrió un error inesperado.")
                };


            }
            var errorResponse = new
            {
                title = status.ToString(),
                message = ex.Message
            };

            context.Result = new ObjectResult(errorResponse)
            {
                StatusCode = status,
                ContentTypes = { "application/json" }
            };

            context.ExceptionHandled = true;
        }
    }
}