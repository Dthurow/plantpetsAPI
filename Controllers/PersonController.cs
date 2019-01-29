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
    public class PersonController : ControllerBase
    {
        private readonly PlantPetsContext _context;

        public PersonController(PlantPetsContext context)
        {
            _context = context;


        }


        #region person calls


        [HttpGet("{personid}")]
        public async Task<ActionResult<Persons>> GetPerson(int personid)
        {
            return await _context.Persons.FindAsync(personid);
        }

        [HttpPost]
        public async Task<ActionResult<Plants>> PostPerson(Persons person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPerson), new { personId = person.PersonId }, person);
        }


        [HttpPut]
        public async Task<IActionResult> PutPerson(Persons persons)
        {

            var curPerson = _context.Persons.Find(persons.PersonId);

            if (curPerson.FirstName != persons.FirstName)
            {
                curPerson.FirstName = persons.FirstName;
            }
            if (curPerson.LastName != persons.LastName){
                curPerson.LastName = persons.LastName;
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

       
        #region helper methods




        #endregion





    }
}