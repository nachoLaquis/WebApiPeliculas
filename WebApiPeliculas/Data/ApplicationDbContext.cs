using Microsoft.EntityFrameworkCore;
using WebApiPeliculas.Modelos;

namespace WebApiPeliculas.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Entidades
        public DbSet<Categoria> Categoria { get; set; }
    }
} 