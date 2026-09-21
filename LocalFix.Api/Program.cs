using LocalFix.Api.Endpoints; 
using LocalFix.Api.Services;
using LocalFix.Api.DTOs;
using Microsoft.EntityFrameworkCore;
using LocalFix.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ServiceRequestService>();
builder.Services.AddDbContext<LocalFixDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LocalFixDbContext>();
    
    Console.WriteLine(dbContext.Database.CanConnect());
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapWebApplication();

app.Run();
