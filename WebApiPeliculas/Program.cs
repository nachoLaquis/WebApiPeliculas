using Microsoft.EntityFrameworkCore;
using WebApiPeliculas.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/**
 * Configuración del DbContext para SQL Server
 * Registra ApplicationDbContext como servicio scoped (una instancia por request).
 * La cadena de conexión se resuelve desde IConfiguration.
 * */
builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
