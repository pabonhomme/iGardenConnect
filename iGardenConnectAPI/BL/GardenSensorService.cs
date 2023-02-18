using BL.Interfaces;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GardenSensorService : IGardenSensorService
    {
        private readonly IGardenSensorRepository _gardenSensorRepository;
        private readonly ISensorService _sensorService;


        public GardenSensorService(IGardenSensorRepository gardenSensorRepository, ISensorService sensorService)
        {
            _gardenSensorRepository = gardenSensorRepository;
            _sensorService = sensorService;
        }

        public bool Add(string idGarden)
        {
            var sensors = _sensorService.Get();
            return  _gardenSensorRepository.Add(idGarden, sensors);
        }

        public IEnumerable<GardenSensorDTO> Get(string idGarden)
        {
            return _gardenSensorRepository.Get(idGarden);
        }

        public GardenSensorDTO Get(string idGarden, int idSensor)
        {
            throw new NotImplementedException();
        }

        public bool Remove(GardenSensorDTO gardenSensorDTO)
        {
            throw new NotImplementedException();
        }

        public bool Update(GardenSensorDTO gardenSensorDTO, float value)
        {
            throw new NotImplementedException();
        }
    }
}
