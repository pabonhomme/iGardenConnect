using BL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SensorService : ISensorService
    {
        private readonly ISensorRepository _sensorRepository;
        private readonly IGardenSensorRepository _gardensensorRepository;
        private readonly IGardenRepository _gardenRepository;


        public SensorService(ISensorRepository sensorRepository, IGardenSensorRepository gardenSensorRepository,  IGardenRepository gardenRepository)
        {
            _sensorRepository = sensorRepository;
            _gardensensorRepository = gardenSensorRepository;
            _gardenRepository = gardenRepository;


        }

        /// <summary>
        /// Get all existent sensors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SensorDTO> Get()
        {
            return _sensorRepository.Get();
        }


        /// <summary>
        /// Get sensor by idSensor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SensorDTO Get(int id)
        {
            return _sensorRepository.Get(id);
        }

        #region POST
        public bool Add(SensorDTO dto)
        {
            return _sensorRepository.Add(dto);
        }
        #endregion


        #region PUT
        public bool Update(SensorDTO dto)
        {
            return _sensorRepository.Update(dto);
        }
        #endregion

        public bool Remove(SensorDTO dto)
        {
            bool state;
            bool state2;
            var gardens = _gardenRepository.Get();
            foreach(GardenDTO g in gardens)
            {
                state = _gardensensorRepository.RemoveGardenSensorByIdSensor(dto.IdSensor, g.IdGarden);

            }

            state2 = _sensorRepository.Remove(dto);

            return state2;
        }
    }
}
