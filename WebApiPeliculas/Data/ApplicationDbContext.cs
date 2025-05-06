using Microsoft.EntityFrameworkCore;
using WebApiPeliculas.Modelos;

namespace WebApiPeliculas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // [CAT-ENTITY] Define modelo Categoria para tabla 'Categorias' en BD
        public DbSet<Categoria> Categorias { get; set; }
    }
}