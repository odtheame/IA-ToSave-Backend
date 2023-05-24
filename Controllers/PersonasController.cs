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
    public class PersonasController : ControllerBase
    {
        private readonly IaToSaveContext _context;

        public PersonasController(IaToSaveContext context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]


        public object GetPersonas()
        {

            //  segunda query

            var query = from prs in _context.Personas                        
                        select new PersonasMV
                        {
                            ID_Persona = prs.IdPrsn,
                            Primer_Nombre = prs.PrNom,
                            Segundo_Nombre = prs.SdNom,
                            Primer_Apellido = prs.PrApe,
                            Segundo_Apellido = prs.SdApe,
                            Correo = prs.Correo,
                            Num_Documento = prs.NDcmt,
                            Telefono = prs.Telef,
                            Fecha_Nacimiento = prs.FeNaci,
                            Fecha_Ingreso = prs.FeIngr

                        };
            // cierre de la segunda query
            return query;
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // PUT: api/Personas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            if (id != persona.IdPrsn)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.IdPrsn }, persona);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.IdPrsn == id);
        }
    }
}
