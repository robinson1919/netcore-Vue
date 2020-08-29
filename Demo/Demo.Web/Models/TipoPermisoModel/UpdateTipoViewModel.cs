using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Web.Models.TipoPermisoModel
{
    public class UpdateTipoViewModel
    {
        [Required]
        public int id_tipopermiso { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre del permiso no debe  tener menos de 3 caracteres, o más de 50")]
        public string nombre { get; set; }
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La description del permiso no debe  tener menos de 3 caracteres, o más de 50")]
        public string descripcion { get; set; }
    }
}
