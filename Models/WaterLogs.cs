using System;
using System.Collections.Generic;

namespace plantpetsAPI.Models
{
    public partial class WaterLogs
    {
        public int WaterLogsId { get; set; }
        public int? PersonId { get; set; }
        public int? PersonPlantId { get; set; }
        public DateTime WaterTime { get; set; }

        public Persons Person { get; set; }
        public PersonPlants PersonPlant { get; set; }
    }
}
