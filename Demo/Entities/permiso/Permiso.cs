using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.permisos
{
    public class Permiso
    {
        public int id_permiso { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe  tener menos de 3 caracteres, o más de 50")]
        public string nombre_empleado { get; set; }
        public string apellido_empleado { get; set; }
        public DateTime fecha_permiso { get; set; }
        public bool estado { get; set; }
        public int id_tipo_permiso { get; set; }
    }
}
