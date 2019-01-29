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
    public class WaterLogController : ControllerBase
    {
        private readonly PlantPetsContext _context;

        public WaterLogController(PlantPetsContext context)
        {
            _context = context;


        }

        #region water log calls
        [HttpGet("{personid}")]
        public async Task<ActionResult<IEnumerable<WaterLogs>>> GetWaterLogs(int personId)
        {
            List<WaterLogs> result = null;
            await Task.Run(() =>
            {
                result = _context.WaterLogs.Where(x => x.PersonId == personId).ToList();
            });

            return result;
        }

        [HttpGet("{personid}/personplant/{personplantid}")]
        public async Task<ActionResult<IEnumerable<WaterLogs>>> GetAPlantsWaterLogs(int personId, int personplantid)
        {
            List<WaterLogs> result = null;
            await Task.Run(() =>
            {
                result = _context.WaterLogs.Where(x => x.PersonId == personId && x.PersonPlantId == personplantid).ToList();
            });

            return result;
        }


        [HttpPost]
        public async Task<IActionResult> PostWaterLog(WaterLogs log)
        {

            _context.WaterLogs.Add(log);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAPlantsWaterLogs), new { personId = log.PersonId, personplantid = log.PersonPlantId }, log);
        }



        #endregion

        #region helper methods




        #endregion





    }
}