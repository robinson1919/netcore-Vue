using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Web.Models.TipoPermiso
{
    public class TipoPermisoViewModel
    {
        public int id_tipopermiso { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
    }
}
