using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGardenSensorRepository
    {
        public IEnumerable<GardenSensorDTO> Get(string idGarden);

        public GardenSensorDTO Get(string idGarden, int idSensor);
        public bool Add(string idGarden, IEnumerable<SensorDTO> sensors);
        public bool Update(GardenSensorDTO gardenSensorDTO, float value);
        public bool Remove(GardenSensorDTO gardenSensorDTO);
    }
}
