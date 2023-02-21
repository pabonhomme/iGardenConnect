using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PlantDTO
    {
        public int IdPlant { get; set; }
        public string  Name { get; set; }
        public string Species { get; set; }
        public DateTime? WateringInterval { get; set; }
    }
}
