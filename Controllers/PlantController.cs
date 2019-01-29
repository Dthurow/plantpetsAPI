using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using plantpetsAPI.Models;

namespace plantpetsAPI.Controllers
{
    //re-make the data context if I change the SQL db:
    //dotnet ef dbcontext scaffold "Database=PlantPets;User Id=<user>;Password=<password>" Microsoft.EntityFrameworkCore.SqlServer -o Models -f

    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly PlantPetsContext _context;

        public PlantController(PlantPetsContext context)
        {
            _context = context;


        }

        #region plants in general call
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plants>>> GetPlants()
        {
            return await _context.Plants.ToListAsync();
        }

        [HttpGet("{plantId}")]
        public async Task<ActionResult<Plants>> GetPlant(int plantId)
        {
            var plant = await _context.Plants.FindAsync(plantId);

            if (plant == null)
            {
                return NotFound();
            }

            return plant;
        }

        [HttpPost]
        public async Task<ActionResult<Plants>> PostPersonPlants(Plants plant)
        {
            _context.Plants.Add(plant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlant), new { plantId = plant.PlantId }, plant);
        }

        #endregion

        #region helper methods




        #endregion





    }
}