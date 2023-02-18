using DTO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IGardenSensorService
    {
        public IEnumerable<GardenSensorDTO> Get(string idGarden);

        public GardenSensorDTO Get(string idGarden, int idSensor);
        public bool Add(string idGarden);

        /// <summary>
        /// Link a sensor to specific Garden
        /// </summary>
        /// <param name="idGarden"></param>
        /// <param name="idSensor"></param>
        /// <returns></returns>
        public bool Add(string idGarden, int idSensor);

        public bool Update(string idGarden, int idSensor, string value);
        public bool Remove(GardenSensorDTO gardenSensorDTO, string idGarden);
        public bool RemoveGardenSensors(IEnumerable<GardenSensorDTO> gardenSensors, string IdGarden);

    }
}
