using LocalFix.Api.Services; 
using LocalFix.Api.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ServiceRequestService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

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


app.Run();
