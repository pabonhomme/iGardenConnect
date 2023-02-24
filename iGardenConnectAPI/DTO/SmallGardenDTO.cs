using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SmallGardenDTO
    {
        public string IdGarden { get; set; }
        public string Name { get; set; }
        public short? Watered { get; set; }
        public DateTime? LastWatered { get; set; }
        public int? WateringDuration { get; set; }

        public PlantDTO Plant { get; set; }

    }
}
