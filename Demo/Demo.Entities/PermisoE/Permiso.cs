using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;
using Demo.Entities.PermisoTipo;

namespace Demo.Entities.PermisoE
{
    public class Permiso
    {
        public int id_permiso { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe  tener menos de 3 caracteres, o más de 50")]
        public string nombre_empleado { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El Apellido no debe  tener menos de 3 caracteres, o más de 50")]
        public string apellido_empleado { get; set; }
        public DateTime fecha_permiso { get; set; }
        public bool estado { get; set; }
        public int id_tipo_permiso { get; set; }

        public TipoPermiso tipoPermiso { get; set; }
    }
}


