using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Web.Models.PermisoModel
{
    public class PermisoViewModel
    {
        public int id_permiso { get; set; }
        public int id_tipo_permiso { get; set; }
        public string permiso { get; set; }
        public string nombre_empleado { get; set; }
        public string apellido_empleado { get; set; }
        public DateTime fecha_permiso { get; set; }
        public bool estado { get; set; }
        
    }
}
