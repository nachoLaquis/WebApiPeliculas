using System.ComponentModel.DataAnnotations;

// [CAT-DTO] Modelo de transferencia para la entidad Categoría
namespace WebApiPeliculas.Modelos.Dtos
{
    public class CategoriaCrearDto
    {
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [MaxLength(60, ErrorMessage = "El número máximo de caracteres permitido es 100.")]
        public string Nombre { get; set; }
    }
}
