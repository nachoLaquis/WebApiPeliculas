using System.ComponentModel.DataAnnotations;

// [CAT-ENTITY] Define la entidad Categoría para la base de datos
namespace WebApiPeliculas.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}
