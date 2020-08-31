using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo.Data;
using Demo.Entities.PermisoE;
using Demo.Web.Models.PermisoModel;
using System;

namespace Demo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly DbContextDemo _context;

        public PermisosController(DbContextDemo context)
        {
            _context = context;
        }

        // GET: api/Permisos/GetPermisos
        [HttpGet("[action]")]
        public async Task <IEnumerable<PermisoViewModel>> GetPermisos()
        {
            var permiso = await _context.Permisos
                .Include(p => p.tipoPermiso).Where(p => p.estado == true).ToListAsync();

            return permiso.Select(p => new PermisoViewModel
            {
                id_permiso = p.id_permiso,
                id_tipo_permiso = p.id_tipo_permiso,
                permiso = p.tipoPermiso.nombre,
                nombre_empleado = p.nombre_empleado,
                apellido_empleado = p.apellido_empleado,
                fecha_permiso = p.fecha_permiso,
                estado = p.estado
            });
        }

        // GET: api/Permisos/GetPermiso/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetPermiso([FromRoute] int id)
        {

            var permiso = await _context.Permisos.Include(p => p.tipoPermiso)
                .SingleOrDefaultAsync(p => p.id_permiso == id);

            if (permiso == null)
            {
                return NotFound();
            }

            return Ok(new PermisoViewModel
            {
                id_permiso = permiso.id_permiso,
                id_tipo_permiso = permiso.id_tipo_permiso,
                permiso = permiso.tipoPermiso.nombre,
                nombre_empleado = permiso.nombre_empleado,
                apellido_empleado = permiso.apellido_empleado,
                fecha_permiso = permiso.fecha_permiso,
                estado = permiso.estado
            });
        }

        // PUT: api/Permisos/UpdatePermiso/5
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdatePermiso([FromBody] UpdatePermisoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.id_permiso < 0)
            {
                return BadRequest();
            }

            var permiso = await _context.Permisos
                .FirstOrDefaultAsync(p => p.id_permiso == model.id_permiso);

            if (permiso == null)
            {
                return NotFound();
            }

            permiso.nombre_empleado = model.nombre_empleado;
            permiso.apellido_empleado = model.apellido_empleado;
            permiso.id_tipo_permiso = model.id_tipo_permiso;

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

        // POST: api/Permisos/CreatePermiso
        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePermiso([FromBody] CreatePermisoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Permiso permiso = new Permiso
            {
                id_tipo_permiso = model.id_tipo_permiso,
                nombre_empleado = model.nombre_empleado,
                apellido_empleado = model.apellido_empleado,
                fecha_permiso = DateTime.Now,
                estado = true                
            };

            _context.Permisos.Add(permiso);

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

        // DELETE: api/Permisos/DeletePermiso/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeletePermiso([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var permiso = await _context.Permisos.FirstOrDefaultAsync(p => p.id_permiso == id);

            if (permiso == null)
            {
                return NotFound();
            }

            permiso.estado = false;

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

        private bool PermisoExists(int id)
        {
            return _context.Permisos.Any(e => e.id_permiso == id);
        }
    }
}