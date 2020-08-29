using System;
using Demo.Entities.PermisoE;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Entities.PermisoTipo
{
    public class TipoPermiso
    {
        public int id_tipopermiso { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre del permiso no debe  tener menos de 3 caracteres, o más de 50")]
        public string nombre { get; set; }
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La description del permiso no debe  tener menos de 3 caracteres, o más de 50")]
        public string descripcion { get; set; }
        public bool estado { get; set; }

        public ICollection<Permiso> permisos { get; set; }
    }
}
