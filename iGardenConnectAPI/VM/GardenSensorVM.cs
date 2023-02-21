using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    public class GardenSensorVM : SensorVM
    {
        public string? Value { get; set; }
        public string? State { get; set; }
    }
}
