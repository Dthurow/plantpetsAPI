using System;
using System.Collections.Generic;

namespace plantpetsAPI.Models
{
    public partial class PersonPlants
    {
        public PersonPlants()
        {
            Alerts = new HashSet<Alerts>();
            WaterLogs = new HashSet<WaterLogs>();
        }

        public int PersonPlantId { get; set; }
        public string NickName { get; set; }
        public int? PlantId { get; set; }
        public int? PersonId { get; set; }

        public Persons Person { get; set; }
        public Plants Plant { get; set; }
        public ICollection<Alerts> Alerts { get; set; }
        public ICollection<WaterLogs> WaterLogs { get; set; }
    }
}
