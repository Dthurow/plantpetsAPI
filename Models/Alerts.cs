using System;
using System.Collections.Generic;

namespace plantpetsAPI.Models
{
    public partial class Alerts
    {
        public int AlertId { get; set; }
        public int? PersonId { get; set; }
        public int? PersonPlantId { get; set; }
        public DateTime AlertTime { get; set; }

        public Persons Person { get; set; }
        public PersonPlants PersonPlant { get; set; }
    }
}
