﻿using System.ComponentModel.DataAnnotations;

namespace SistemaInventarioV6.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Nombre es Requerido")]
        [MaxLength(60, ErrorMessage = "Nombre debe ser Maximo 60 Caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Descripcion es Requerido")]

        public string? Descripcion { get; set; }

        public bool Estado { get; set; }
    }
}
