using System;
using System.Collections.Generic;

namespace plantpetsAPI.Models
{
    public partial class Plants
    {
        public Plants()
        {
            PersonPlants = new HashSet<PersonPlants>();
        }

        public int PlantId { get; set; }
        public string Name { get; set; }
        public int WaterScheduleInHours { get; set; }

        public ICollection<PersonPlants> PersonPlants { get; set; }
    }
}
