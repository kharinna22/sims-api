using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SimsAPI.Data;
using SimsAPI.Models;
using System.Text;

namespace SimsAPI.Controllers
{
    [Route("api/sims")]
    [ApiController]
    public class SimController : ControllerBase
    {

        private readonly DataContext _context;
        public SimController(DataContext context)
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

        [HttpPost]
        [Route("upload")]
        public IActionResult UploadFile()
        {

            var file = Request.Form.Files[0];
            if (file == null || file.Length == 0)
            {
                return BadRequest("No se ha enviado ningún archivo");
            }

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                // Aquí puedes realizar el procesamiento deseado con el archivo CSV
                // Por ejemplo, leer los datos del archivo y realizar operaciones

                // Ejemplo: Leer las líneas del archivo CSV
                var csvData = reader.ReadToEnd();
                // Aquí puedes procesar los datos como desees

                return Ok("Archivo CSV recibido correctamente");
            }
        }

        private readonly List<DataItem> _dataItems = new List<DataItem>
        {
            new DataItem { Id = 1, Name = "John Doe", Age = 30 },
            new DataItem { Id = 2, Name = "Jane Smith", Age = 25 },
            // Add more data items as needed
        };

        [HttpGet]
        [Route("getcsv")]
        public IActionResult GetCsv()
        {
            // Create the CSV content
            var csvContent = new StringBuilder();
            csvContent.AppendLine("Id,Name,Age");

            foreach (var dataItem in _dataItems)
            {
                csvContent.AppendLine($"{dataItem.Id},{dataItem.Name},{dataItem.Age}");
            }

            // Set the response headers
            var bytes = Encoding.UTF8.GetBytes(csvContent.ToString());
            var result = new FileContentResult(bytes, "text/csv")
            {
                FileDownloadName = "data.csv"
            };

            return result;
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

    public class DataItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
