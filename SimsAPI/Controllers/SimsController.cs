using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimsAPI.Data;
using SimsAPI.Models;

namespace SimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimsController : ControllerBase
    {

        private readonly DataContext _context;
        public SimsController(DataContext context)
        {
            _context = context;
        }

        // Devuelve la lista de sims
        [HttpGet]
        public async Task<IActionResult> GetSims()
        {
            return Ok(await _context.Sims.ToListAsync());
        }

        // Buscar Sim por Id
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetSim(int id)
        {
            var sim = await _context.Sims.FindAsync(id);

            if (sim == null)
                return NotFound();

            return Ok(sim);
        }

        // Agrega un nuevo sim a la BD
        [HttpPost]
        public async Task<IActionResult> AddSim(AddSimRequest sim)
        {
            Sim newSim = new Sim()
            {
                Nombre = sim.Nombre,
                Apellido = sim.Apellido,
                Edad = sim.Edad,
                IsMuerto = sim.IsMuerto,
                IsMujer = sim.IsMujer
            };

            await _context.Sims.AddAsync(newSim);
            await _context.SaveChangesAsync();

            return Created("",await _context.Sims.ToListAsync());
        }


        // Edita un sim 
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateSim([FromRoute] int id, AddSimRequest updateRequest)
        {
            var foundedSim = await _context.Sims.FindAsync(id);

            if (foundedSim == null)
                return NotFound();

            foundedSim.Nombre = updateRequest.Nombre;
            foundedSim.Apellido = updateRequest.Apellido;
            foundedSim.Edad = updateRequest.Edad;
            foundedSim.IsMuerto = updateRequest.IsMuerto;
            foundedSim.IsMujer = updateRequest.IsMujer;

            await _context.SaveChangesAsync();

            return Ok(await _context.Sims.ToListAsync());
        }

        // Eliminar un sim de la lista
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteSim(int id)
        {
            var sim = await _context.Sims.FindAsync(id);
            
            if (sim == null)
                return NotFound();
            
            _context.Sims.Remove(sim);
            await _context.SaveChangesAsync();

            return Ok(await _context.Sims.ToListAsync());
        }

    }
}
