﻿using System;
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
    public class IncidenciasController : ControllerBase
    {
        private readonly IaToSaveContext _context;

        public IncidenciasController(IaToSaveContext context)
        {
            _context = context;
        }
            
        // GET: api/Incidencias
        [HttpGet]

        public object GetIncidencias()
        {

            //  segunda query

            var query = from inc in _context.Incidencias
                        join ubi in _context.Ubicaciones on inc.IdIcdc equals ubi.IdUbi
                        select new IncidenciasMV
                        {
                            ID_Incidencia = inc.IdIcdc,
                            Ciudad = ubi.Cdad,
                            Localidad = ubi.Lcld,
                            Arma = inc.Anmla

                        };
            // cierre de la segunda query
            return query;
        }

        // GET: api/Incidencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Incidencia>> GetIncidencia(int id)
        {
            var incidencia = await _context.Incidencias.FindAsync(id);

            if (incidencia == null)
            {
                return NotFound();
            }

            return incidencia;
        }

        // PUT: api/Incidencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidencia(int id, Incidencia incidencia)
        {
            if (id != incidencia.IdIcdc)
            {
                return BadRequest();
            }

            _context.Entry(incidencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidenciaExists(id))
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

        // POST: api/Incidencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Incidencia>> PostIncidencia(Incidencia incidencia)
        {
            _context.Incidencias.Add(incidencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncidencia", new { id = incidencia.IdIcdc }, incidencia);
        }

        // DELETE: api/Incidencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidencia(int id)
        {
            var incidencia = await _context.Incidencias.FindAsync(id);
            if (incidencia == null)
            {
                return NotFound();
            }

            _context.Incidencias.Remove(incidencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncidenciaExists(int id)
        {
            return _context.Incidencias.Any(e => e.IdIcdc == id);
        }
    }
}
