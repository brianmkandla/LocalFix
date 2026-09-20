using LocalFix.Api.Services;
using LocalFix.Api.DTOs;

namespace LocalFix.Api.Endpoints;

public static class ServiceRequestEndpoints
{
    public static void MapWebApplication(this WebApplication app)
    {
        app.MapGet("/api/requests", (ServiceRequestService service) =>
        {
            // handler function
            return service.GetAllRequests(); 
        });

        app.MapPost("/api/requests", (ServiceRequestService service, CreateServiceRequestDto requestDto) =>
        {
            var request = service.CreateRequest(requestDto.Title, requestDto.Category, requestDto.Description);

            return Results.Created($"/api/requests/{request.Id}", request);
        });

        // Get one request by ID
        app.MapGet("/api/requests/{id}", (ServiceRequestService service, int id) =>
        {
            var serviceRequest = service.GetById(id);

            
            if (serviceRequest is null)
            {
                return Results.NotFound(new { message = $"Request with ID {id} not found." });
            }
            
            return Results.Ok(serviceRequest);
        }) ;

        // 
        app.MapPut("/api/requests/{id}", (ServiceRequestService service, int id, UpdateServiceRequestDto requestDto) =>
        {
            var request = service.UpdateRequest(id, requestDto.Title, requestDto.Description, requestDto.Category, requestDto.Status);

            if (request is null)
            {
                return Results.NotFound(new { message = $"Request with ID {id} not found." });
            }

            return Results.Ok(request);
        });

        // Delete endpoint
        app.MapDelete("/api/requests/{id}", (ServiceRequestService service, int id) =>
        {
            var requestDel = service.DeleteRequest(id);

            if (requestDel is false)
            {
                return Results.NotFound(new { message = $"Request with ID {id} not found." });
            }

            return Results.NoContent();
        });
    }
}