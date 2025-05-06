using Microsoft.EntityFrameworkCore;
using WebApiPeliculas.Data;
using WebApiPeliculas.PeliculasMapper;
using WebApiPeliculas.Repositorio;
using WebApiPeliculas.Repositorio.IRepositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// [CORE-DB] Configura DbContext con SQL Server (ConnectionStrings:ConexionSql)
builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// [CORE-MAPPER] Configura AutoMapper con perfil principal
builder.Services.AddAutoMapper(typeof(PeliculasMapper));
// [CAT-REPO] Registra repositorio de categorías (Scoped)
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();

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
