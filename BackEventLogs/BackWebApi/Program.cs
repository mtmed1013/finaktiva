using System.ComponentModel.Design;
using BackWebApi.Data;
using BackWebApi.Interfaces;
using BackWebApi.Middlewares;
using BackWebApi.Repositories;
using BackWebApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(); // Registra SwaggerGen
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IEventLogsAddRepository, EventLogsRepository>();
builder.Services.AddScoped<IEventLogsGetRepository, EventLogsRepository>();
builder.Services.AddScoped<IEventLogsServiceAdd, EventLogsService>();
builder.Services.AddScoped<IEventLogsServiceGet, EventLogsService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// REGISTRA LOS CONTROLADORES
builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); // Habilita Swagger
    app.UseSwaggerUI(); // Habilita la UI de Swagger
}

app.UseHttpsRedirection();
app.UseCors("AllowAngular");

// MAPEADO DE CONTROLADORES
app.MapControllers();

app.Run();

