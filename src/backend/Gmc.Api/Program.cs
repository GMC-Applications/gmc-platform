using Gmc.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ChurchDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration
            .GetConnectionString("Postgres"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("Clients", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Clients");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/api/v1/health", () =>
{
    return Results.Ok(new
    {
        status = "ok",
        service = "GMC API",
        utc = DateTime.UtcNow
    });
});

app.MapGet("/", () =>
{
    return Results.Ok(new
    {
        message = "GMC API is running",
        documentation = "/swagger",
        health = "/api/v1/health"
    });
});


app.MapControllers();

app.Run();