using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo.Data;
using Demo.Entities.PermisoTipo;
using Demo.Web.Models.TipoPermiso;
using Demo.Web.Models.TipoPermisoModel;

namespace Demo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPermisosController : ControllerBase
    {
        private readonly DbContextDemo _context;

        public TipoPermisosController(DbContextDemo context)
        {
            _context = context;
        }

        // GET: api/TipoPermisos/GetTipoPermisos
        [HttpGet("[action]")]
        public async Task <IEnumerable<TipoPermisoViewModel>> GetTipoPermisos()
        {
            var tipoPermiso = await _context.TipoPermisos.Where(a => a.estado == true).ToListAsync();

            return tipoPermiso.Select(t => new TipoPermisoViewModel
            {
                id_tipopermiso = t.id_tipopermiso,
                nombre = t.nombre,
                descripcion = t.descripcion,
                estado = t.estado
            });
        }

        // GET: api/TipoPermisos/GetTipoPermiso/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetTipoPermiso([FromRoute] int id)
        {

            var tipoPermiso = await _context.TipoPermisos.FindAsync(id);

            if (tipoPermiso == null)
            {
                return NotFound();
            }

            return Ok(new TipoPermisoViewModel
            {
                id_tipopermiso = tipoPermiso.id_tipopermiso,
                nombre = tipoPermiso.nombre,
                descripcion = tipoPermiso.descripcion,
                estado = tipoPermiso.estado
            });
        }

        // PUT: api/TipoPermisos/UpdateTipoPermiso
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateTipoPermiso([FromBody] UpdateTipoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id_tipopermiso < 0)
            {
                return BadRequest();
            }

            var tipoPermiso = await _context.TipoPermisos
                .FirstOrDefaultAsync(t => t.id_tipopermiso == model.id_tipopermiso);

            if(tipoPermiso == null)
            {
                return NotFound();
            }

            tipoPermiso.nombre = model.nombre;
            tipoPermiso.descripcion = model.descripcion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/TipoPermisos/CreateTipoPermiso
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTipoPermiso([FromBody] CreateTipoPermisoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TipoPermiso tipoPermiso = new TipoPermiso
            {
                nombre = model.nombre,
                descripcion = model.descripcion,
                estado = true
            };

            _context.TipoPermisos.Add(tipoPermiso);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/TipoPermisos/DeleteTipoPermiso/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteTipoPermiso([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoPermiso = await _context.TipoPermisos.FirstOrDefaultAsync(p => p.id_tipopermiso == id);

            if (tipoPermiso == null)
            {
                return NotFound();
            }

            tipoPermiso.estado = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        private bool TipoPermisoExists(int id)
        {
            return _context.TipoPermisos.Any(e => e.id_tipopermiso == id);
        }
    }
}