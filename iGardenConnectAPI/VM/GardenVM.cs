using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    public class GardenVM
    {
        public string IdGarden { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public DateTime? WateringDuration { get; set; }
        public short? Watered { get; set; }
        public DateTime? LastWatered { get; set; }
        public int? IdPlant { get; set; }
        public int? IdUser { get; set; }

        public virtual ICollection<SensorVM> GardenSensors { get; set; }
    }
}
