using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    public class GardenVM : SmallGardenVM
    {


        public virtual IEnumerable<GardenSensorVM> GardenSensors { get; set; }
    }
}
