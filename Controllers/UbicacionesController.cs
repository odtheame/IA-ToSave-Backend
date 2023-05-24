using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IA_ToSave_Project.Models;
using IA_ToSave_Project.ModelViews;

namespace IA_ToSave_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionesController : ControllerBase
    {
        private readonly IaToSaveContext _context;

        public UbicacionesController(IaToSaveContext context)
        {
            _context = context;
        }

        // GET: api/Ubicaciones
        [HttpGet]
        public object GetUbicaciones()
        {

            //  segunda query

            var query = from ubi in _context.Ubicaciones
                        join user in _context.Usuarios on ubi.IdUbi equals user.IdUsr
                        select new UbicacionesMV
                        {
                            ID_Ubicacion = ubi.IdUbi,
                            Ciudad = ubi.Cdad,
                            Departamento = ubi.Dpto,
                            Localidad = ubi.Lcld,
                            Usuario = user.Usr

                        };
            // cierre de la segunda query
            return query;
        }

        // GET: api/Ubicaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ubicacione>> GetUbicacione(int id)
        {
            var ubicacione = await _context.Ubicaciones.FindAsync(id);

            if (ubicacione == null)
            {
                return NotFound();
            }

            return ubicacione;
        }

        // PUT: api/Ubicaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUbicacione(int id, Ubicacione ubicacione)
        {
            if (id != ubicacione.IdUbi)
            {
                return BadRequest();
            }

            _context.Entry(ubicacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbicacioneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ubicaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ubicacione>> PostUbicacione(Ubicacione ubicacione)
        {
            _context.Ubicaciones.Add(ubicacione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUbicacione", new { id = ubicacione.IdUbi }, ubicacione);
        }

        // DELETE: api/Ubicaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUbicacione(int id)
        {
            var ubicacione = await _context.Ubicaciones.FindAsync(id);
            if (ubicacione == null)
            {
                return NotFound();
            }

            _context.Ubicaciones.Remove(ubicacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UbicacioneExists(int id)
        {
            return _context.Ubicaciones.Any(e => e.IdUbi == id);
        }
    }
}
