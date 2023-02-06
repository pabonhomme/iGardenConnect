using DTO;
using DAL.Interfaces;
using DAL.Models;
using DAL.Extensions;

namespace DAL.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly iGardenConnectDBContext _dbcontext;

        public SensorRepository(iGardenConnectDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool Add(SensorDTO dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SensorDTO> Get()
        {
            return _dbcontext.Sensors.ToList().Select(p => p.ToDTO()).ToList();
        }

        public SensorDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(SensorDTO sensorDTO)
        {
            throw new NotImplementedException();
        }

        public bool Update(SensorDTO sensorDTO)
        {
            throw new NotImplementedException();
        }
    }
}