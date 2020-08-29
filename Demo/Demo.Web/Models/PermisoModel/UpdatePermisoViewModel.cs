using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Web.Models.PermisoModel
{
    public class UpdatePermisoViewModel
    {
        [Required]
        public int id_permiso { get; set; }
        [Required]
        public int id_tipo_permiso { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe  tener menos de 3 caracteres, o más de 50")]
        public string nombre_empleado { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El Apellido no debe  tener menos de 3 caracteres, o más de 50")]
        public string apellido_empleado { get; set; }
        
    }
}
