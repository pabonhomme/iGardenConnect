using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GardenDTO : SmallGardenDTO
    {
        public virtual IEnumerable<GardenSensorDTO> GardenSensors { get; set; }
    }
}
