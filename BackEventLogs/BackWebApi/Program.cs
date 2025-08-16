using System.ComponentModel.Design;
using System.Reflection;
using BackWebApi.Data;
using BackWebApi.Interfaces;
using BackWebApi.Middlewares;
using BackWebApi.Repositories;
using BackWebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Event Logs API",
        Version = "v1",
        Description = "API para gestión de logs de eventos"
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IEventLogsAddRepository, EventLogsRepository>();
builder.Services.AddScoped<IEventLogsGetRepository, EventLogsRepository>();
builder.Services.AddScoped<IEventLogsTypeGetRepository, EventLogsTypeRepository>();
builder.Services.AddScoped<IEventLogsServiceAdd, EventLogsService>();
builder.Services.AddScoped<IEventLogsServiceGet, EventLogsService>();
builder.Services.AddScoped<IEventLogsTypeGetService, EventLogsTypeService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});


builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionMiddleware>(); // Register the exception middleware as a global filter
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngular");


app.MapControllers();

app.Run();

