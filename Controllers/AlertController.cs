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
    public class AlertController : ControllerBase
    {
        private readonly PlantPetsContext _context;

        public AlertController(PlantPetsContext context)
        {
            _context = context;


        }

        #region alert calls
        [HttpGet("{personid}")]
        public async Task<ActionResult<IEnumerable<Alerts>>> GetAlerts(int personId)
        {
            List<Alerts> result = null;
            await Task.Run(() =>
            {
                result = _context.Alerts.Where(x => x.PersonId == personId).ToList();
            });

            return result;
        }

        [HttpGet("{personid}/personplant/{personplantid}")]
        public async Task<ActionResult<IEnumerable<Alerts>>> GetAPlantsAlerts(int personId, int personplantid)
        {
            List<Alerts> result = null;
            await Task.Run(() =>
            {
                result = _context.Alerts.Where(x => x.PersonId == personId && x.PersonPlantId == personplantid).ToList();
            });

            return result;
        }


        [HttpPut]
        public async Task<IActionResult> PutAlerts(Alerts alert)
        {

            var curAlert = _context.Alerts.Find(alert.AlertId);

            if (curAlert.AlertTime != alert.AlertTime)
            {
                curAlert.AlertTime = alert.AlertTime;
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }



        #endregion

        #region helper methods




        #endregion





    }
}