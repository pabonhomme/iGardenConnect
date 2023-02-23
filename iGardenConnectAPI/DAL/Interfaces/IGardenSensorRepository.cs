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
        public IEnumerable<GardenSensorDTO> GetByIdSensor(int idSensor);

        public GardenSensorDTO Get(string idGarden, SensorDTO s);

        public bool Add(string idGarden, IEnumerable<SensorDTO> sensors);
        public bool Update(GardenSensorDTO gardenSensorDTO, string idGarden, string value);
        public bool Remove(GardenSensorDTO gardenSensorDTO, string idGarden);
        public bool RemoveGardenSensorByIdSensor(int idSensor, string idGarden);
    }

}
