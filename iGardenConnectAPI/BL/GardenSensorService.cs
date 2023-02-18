using BL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
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

        public bool Add(string idGarden, int idSensor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GardenSensorDTO> Get(string idGarden)
        {
            var sensors = _sensorService.Get();
            var gs = _gardenSensorRepository.Get(idGarden);
            foreach(GardenSensorDTO g in gs)
            {
                var stemp = sensors.FirstOrDefault(s => g.IdSensor == s.IdSensor);
                g.Name = stemp.Name;
                g.Price = stemp.Price;
                g.Brand = stemp.Brand;
                g.Type = stemp.Type;


            }
            return gs;
        }

        public GardenSensorDTO Get(string idGarden, int idSensor)
        {
           SensorDTO s = _sensorService.Get(idSensor);
            return _gardenSensorRepository.Get(idGarden, s);
        }
        public bool Update(string idGarden, int idSensor, string value)
        {
            GardenSensorDTO gsDTO = this.Get(idGarden, idSensor);
            return _gardenSensorRepository.Update(gsDTO, idGarden, value);
        }
        public bool Remove(GardenSensorDTO gardenSensorDTO, string idGarden)
        {
            return _gardenSensorRepository.Remove(gardenSensorDTO,idGarden);
        }

        public bool RemoveGardenSensors(IEnumerable<GardenSensorDTO> gardenSensors, string idGarden)
        {
            var state = false;
            foreach(GardenSensorDTO g in gardenSensors)
            {
                 state = this.Remove(g, idGarden);
            }
            return state;
        }
    }
}
