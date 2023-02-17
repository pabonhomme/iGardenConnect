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

        public SensorService(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }
        public IEnumerable<SensorDTO> Get()
        {
            return _sensorRepository.Get();
        }

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
    }
}
