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
    public class GardenService : IGardenService
    {
        private readonly IGardenRepository _gardenRepository;
        private readonly ISensorService _sensorService;
        private readonly IGardenSensorService _gardenSensorService;

        public GardenService(IGardenRepository gardenRepository, ISensorService sensorService, IGardenSensorService gardenSensorService)
        {
            _gardenRepository = gardenRepository;
            _sensorService = sensorService;
            _gardenSensorService = gardenSensorService;
        }


        //Small
        public IEnumerable<GardenDTO> Get()
        {
           return _gardenRepository.Get();
        }

        public GardenDTO Get(string id)
        {
            var garden = _gardenRepository.Get(id);
            garden.GardenSensors = _gardenRepository.GetGardenSensors(id);
            foreach(GardenSensorDTO g in garden.GardenSensors)
            {
                var sensor = _sensorService.Get((int)g.IdSensor);
                g.Type = sensor.Type;
                g.Name = sensor.Name;
                g.Brand = sensor.Brand;
                g.Price = sensor.Price;

            }
            return garden;
        }
        public bool Add(GardenDTO gardenDTO, int idUser, int idPlant)
        {

            _gardenSensorService.Add(gardenDTO.IdGarden);
            return _gardenRepository.Add(gardenDTO, idUser, idPlant);
        }
        public bool Update(GardenDTO plantDTO)
        {
            throw new NotImplementedException();
        }

        public bool Remove(GardenDTO plant)
        {
            throw new NotImplementedException();
        }

  
    }
}
