using BL.Interfaces;
using DAL.Interfaces;
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

        public SensorService(ISensorRepository sensorRepository, IGardenSensorService gardenSensorService)
        {
            _sensorRepository = sensorRepository;
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
            //bool state = _gardenSensorService.RemoveGardenSensorByIdSensor(dto.IdSensor);
            bool state2 = _sensorRepository.Remove(dto);
           
            return state2;
        }
    }
}
