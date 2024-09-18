using GloboTicket.TicketManagement.Api;
using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Application.Models.Mail;
using GloboTicket.TicketManagement.Infrastructure;
using GloboTicket.TicketManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(configuration);
builder.Services.AddPersistenceServices(configuration);

builder.Services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

builder.Services.AddControllers();

builder.Services.AddCors(ops =>
{
    ops.AddPolicy("open", policy =>
    {
        policy.WithOrigins([configuration["ApiUrl"] ?? "https://localhost:7020", configuration["BlazorUrl"] ?? "https://localhost:7080"])
              .AllowAnyMethod()
              .SetIsOriginAllowed(p => true)
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

builder.Services.AddSwaggerGen();



var app = builder.Build();

app.UseCors("open");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

//await app.ResetDatabaseAsync();

app.Run();
