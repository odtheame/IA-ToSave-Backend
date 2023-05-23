using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IA_ToSave.Models;

namespace IA_ToSave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformesController : ControllerBase
    {
        private readonly IaToSaveContext _context;

        public InformesController(IaToSaveContext context)
        {
            _context = context;
        }

        // GET: api/Informes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Informe>>> GetInformes()
        {
            return await _context.Informes.ToListAsync();
        }

        // GET: api/Informes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Informe>> GetInforme(int id)
        {
            var informe = await _context.Informes.FindAsync(id);

            if (informe == null)
            {
                return NotFound();
            }

            return informe;
        }

        // PUT: api/Informes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInforme(int id, Informe informe)
        {
            if (id != informe.IdInf)
            {
                return BadRequest();
            }

            _context.Entry(informe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformeExists(id))
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

        // POST: api/Informes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Informe>> PostInforme(Informe informe)
        {
            _context.Informes.Add(informe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInforme", new { id = informe.IdInf }, informe);
        }

        // DELETE: api/Informes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInforme(int id)
        {
            var informe = await _context.Informes.FindAsync(id);
            if (informe == null)
            {
                return NotFound();
            }

            _context.Informes.Remove(informe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InformeExists(int id)
        {
            return _context.Informes.Any(e => e.IdInf == id);
        }
    }
}
