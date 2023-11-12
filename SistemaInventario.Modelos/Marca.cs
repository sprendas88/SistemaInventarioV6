using System.ComponentModel.DataAnnotations;

namespace SistemaInventarioV6.Modelos
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es Requerido")]
        [MaxLength(60, ErrorMessage = "Nombre debe ser Maximo 60 Caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Descripcion es Requerido")]
        [MaxLength(100, ErrorMessage = "Descripci[on debe ser Maximo 60 caracteres")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Estado es Requerido")]
        public bool Estado { get; set; }
    }
}
