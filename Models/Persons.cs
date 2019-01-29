using System;
using System.Collections.Generic;

namespace plantpetsAPI.Models
{
    public partial class Persons
    {
        public Persons()
        {
            Alerts = new HashSet<Alerts>();
            PersonPlants = new HashSet<PersonPlants>();
            WaterLogs = new HashSet<WaterLogs>();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Alerts> Alerts { get; set; }
        public ICollection<PersonPlants> PersonPlants { get; set; }
        public ICollection<WaterLogs> WaterLogs { get; set; }
    }
}
