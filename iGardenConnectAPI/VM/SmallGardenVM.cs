using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    public class SmallGardenVM
    {
        public string IdGarden { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public DateTime? WateringDuration { get; set; }
        public short? Watered { get; set; }
        public DateTime? LastWatered { get; set; }
        public PlantVM Plant { get; set; }

    }
}
