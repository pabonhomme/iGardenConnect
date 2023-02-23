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
        private readonly IPlantService _plantService;
        public GardenService(IGardenRepository gardenRepository, ISensorService sensorService, IGardenSensorService gardenSensorService, IPlantService plantService)
        {
            _gardenRepository = gardenRepository;
            _sensorService = sensorService;
            _gardenSensorService = gardenSensorService;
            _plantService = plantService;
        }


        //Small
        public IEnumerable<GardenDTO> Get()
        {
           return _gardenRepository.Get();
        }


        public IEnumerable<GardenDTO> Get(int idUser)
        {
            return _gardenRepository.Get(idUser);
        }

        public GardenDTO GetByIdGarden(string id)
        {
            var garden = _gardenRepository.Get(id);
            garden.GardenSensors = _gardenSensorService.Get(id);
            foreach (GardenSensorDTO g in garden.GardenSensors)
            {
                var sensor = _sensorService.Get((int)g.IdSensor);
                g.Type = sensor.Type;
                g.Name = sensor.Name;
                g.Brand = sensor.Brand;
                g.Price = sensor.Price;

            }
            return garden;
        }
        public bool Add(GardenDTO gardenDTO, int idUser)
        {

            bool state = _gardenRepository.Add(gardenDTO, idUser, gardenDTO.Plant.IdPlant);
            _gardenSensorService.Add(gardenDTO.IdGarden);
            return state;
        }


        public bool UpdateByName(GardenDTO gardenDTO, string name)
        {
           return _gardenRepository.UpdateByName(gardenDTO, name);
        }
        public bool UpdateByPlant(GardenDTO gardenDTO, int idPlant)
        {
            return _gardenRepository.UpdateByPlant(gardenDTO, idPlant);

        }


        public bool Remove(GardenDTO gardenDTO)
        {
            var gardenSensorsDTO = _gardenSensorService.Get(gardenDTO.IdGarden);
            var state = _gardenSensorService.RemoveGardenSensors(gardenSensorsDTO, gardenDTO.IdGarden);
            var state2 =  _gardenRepository.Remove(gardenDTO);
            if(state && state2)
            {
                return state;
            }
            return false;
        }

        public bool UpdateByNamePlant(GardenDTO gardenDTO, string name, int idPlant)
        {
            return _gardenRepository.UpdateByNamePlant(gardenDTO, name, idPlant);
        }


    }
}
