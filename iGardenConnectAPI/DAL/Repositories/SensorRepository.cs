using DTO;
using DAL.Interfaces;
using DAL.Models;
using DAL.Extensions;
using System.Linq;

namespace DAL.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly iGardenConnectDBContext _dbcontext;

        public SensorRepository(iGardenConnectDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<SensorDTO> Get()
        {
            return _dbcontext.Sensors.ToList().Select(p => p.ToDTO()).ToList();
        }

        public SensorDTO Get(int id)
        {
            return _dbcontext.Sensors.FirstOrDefault(s => s.IdSensor == id).ToDTO();
        }


        #region POST
        /// <summary>
        /// Add a sensor into the database
        /// </summary>
        /// <param name="SensorDTO">sensor to add in the database</param>
        /// <returns>if the add went well</returns>
        public bool Add(SensorDTO sensorDTO)
        {
            try
            {
                var entity = sensorDTO.ToEntity(0);
                _dbcontext.Add(entity);
                _dbcontext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }
        #endregion

        public bool Update(SensorDTO sensorDTO)
        {
            try
            {
                var entity = sensorDTO.ToEntity(1);
                _dbcontext.Update(entity);
                _dbcontext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }


    }
}