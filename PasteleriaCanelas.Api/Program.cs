// capas necesarias
using Microsoft.EntityFrameworkCore;
using PasteleriaCanelas.Data.Context;
using PasteleriaCanelas.Services;
using PasteleriaCanelas.Services.Interfaces;
using PasteleriaCanelas.Services.Services;


var builder = WebApplication.CreateBuilder(args);

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200", "http://localhost:3000") // Añade aquí el origen de tu frontend (Angular, React, etc.)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// inyección de dependencias para el DbContext
builder.Services.AddDbContext<PasteleriaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// servicio de producto al contenedor de inyección de dependencias.
// Esto enlaza la interfaz (IProductoService) con su implementación (ProductoService).
// AddScoped significa que se crea una nueva instancia por cada petición HTTP.
builder.Services.AddScoped<IProductoService, ProductoService>();
// service de categorias
builder.Services.AddScoped<ICategoriaService, CategoriaService>();


// añadir los servicios al controlador.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar CORS
app.UseCors(myAllowSpecificOrigins);

// permite hacer peticiones http y procesarlas
app.MapControllers();

app.Run();
    