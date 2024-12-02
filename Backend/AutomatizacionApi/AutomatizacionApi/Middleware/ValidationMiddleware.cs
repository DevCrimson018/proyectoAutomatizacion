using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text;
using AutomatizacionApi.Domain.Entities.User;
using AutomatizacionApi.Domain.Entities;

namespace AutomatizacionApi.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        [Obsolete]
        public async Task InvokeAsync(HttpContext context, IValidatorFactory validatorFactory)
        {
            if (context.Request.ContentType?.Contains("application/json") == true)
            {
                context.Request.EnableBuffering(); // Habilita el re-lectura del cuerpo de la solicitud

                // Lee el cuerpo de la solicitud
                var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
                context.Request.Body.Position = 0; // Resetea la posición para que otros middleware puedan leerlo

                try
                {
                    // Determina el tipo basado en la ruta
                    var type = DetermineTypeFromRoute(context);
                    if (type != null)
                    {
                        // Busca el validador para el tipo
                        var validator = validatorFactory.GetValidator(type);
                        if (validator != null)
                        {
                            // Deserializa el modelo
                            var model = JsonSerializer.Deserialize(requestBody, type);

                            // Valida el modelo
                            var validationResult = await validator.ValidateAsync(new ValidationContext<object>(model));
                            if (!validationResult.IsValid)
                            {
                                // Retorna errores de validación
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                await context.Response.WriteAsJsonAsync(validationResult.Errors);
                                return;
                            }
                        }
                    }
                }
                catch (JsonException ex)
                {
                    // Manejo de errores de deserialización
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsJsonAsync(new { Error = "Invalid JSON format", Details = ex.Message });
                    return;
                }
            }

            await _next(context); // Llama al siguiente middleware
        }

        private Type DetermineTypeFromRoute(HttpContext context)
        {
            // Implementa lógica para determinar el tipo basado en la ruta
            var path = context.Request.Path.Value.ToLower();

            if (path.Contains("Auth")) return typeof(ApplicationUser); // Ruta de usuarios
            if (path.Contains("Bus")) return typeof(Bus); // Ruta de Buses
            if (path.Contains("Location")) return typeof(Location); // Ruta de Localizacion
            if (path.Contains("Reservation")) return typeof(Reservation); // Ruta de Reservacion
            if (path.Contains("BusStatus")) return typeof(BusStatus); // Ruta de Reservacion
            if (path.Contains("Ticket")) return typeof(Ticket); // Ruta de Ticket
            if (path.Contains("TicketCode")) return typeof(TicketsCode); // Ruta de TicketCode

            return null; // Si no se encuentra un tipo
        }
    }
}
