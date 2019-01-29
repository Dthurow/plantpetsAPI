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
    public class PersonPlantController : ControllerBase
    {
        private readonly PlantPetsContext _context;

        public PersonPlantController(PlantPetsContext context)
        {
            _context = context;


        }


        #region personPlants calls


        [HttpGet("{personid}")]
        public async Task<IEnumerable<PersonPlants>> GetPersonsPlants(int personid)
        {
            List<PersonPlants> result = null;
            await Task.Run(() =>
            {
                result = _context.PersonPlants.Where(x => x.PersonId == personid).ToList();
            });

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Plants>> PostPersonPlants(PersonPlants personPlant)
        {
            _context.PersonPlants.Add(personPlant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonsPlants), new { personId = personPlant.PersonId }, personPlant);
        }


        [HttpPut]
        public async Task<IActionResult> PutPersonPlants(PersonPlants personPlant)
        {

            var curPersonPlant = _context.PersonPlants.Find(personPlant.PersonPlantId);

            if (curPersonPlant.NickName != personPlant.NickName)
            {
                curPersonPlant.NickName = personPlant.NickName;
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

       
        #region helper methods




        #endregion





    }
}