using DAL.Extensions;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GardenSensorRepository : IGardenSensorRepository
    {
        private readonly iGardenConnectDBContext _dbcontext;

        public GardenSensorRepository(iGardenConnectDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public bool Add(string idGarden, IEnumerable<SensorDTO> sensors)
        {
            try
            {
                GardenSensor entity = new GardenSensor();
                foreach (SensorDTO sensor in sensors)
                {

                    entity.IdGarden = idGarden;
                    entity.IdSensor = sensor.IdSensor;
                    entity.Value = "23";
                    entity.State = "OFF";


                    _dbcontext.Add(entity);
                    _dbcontext.SaveChanges();
                    return true;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public IEnumerable<GardenSensorDTO> Get(string idGarden)
        {
            return _dbcontext.GardenSensors.ToList().Where(s => s.IdGarden == idGarden).ToList().Select(s => s.ToDTO()).ToList();

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
