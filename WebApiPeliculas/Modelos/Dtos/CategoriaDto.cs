using System.ComponentModel.DataAnnotations;

// [CAT-DTO] Modelo de transferencia para la entidad Categoría
namespace WebApiPeliculas.Modelos.Dtos
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [MaxLength(60,ErrorMessage ="El número máximo de caracteres es de 100.")]
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
